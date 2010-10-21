/*
 * http://code.msdn.microsoft.com/entitybag/
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Data;
using System.Diagnostics;
using System.Data.Metadata.Edm;
using System.Reflection;

namespace Asc.Utils.EntityFramework {
	// General purpose extension methods for working with object services.

	public static class UtilityExtensionMethods {
		//
		// just type a little less
		//

		public static EntityState GetEntityState( this ObjectContext context, EntityKey key ) {
			var entry = context.ObjectStateManager.GetObjectStateEntry( key );
			return entry.State;
		}

		public static string GetFullEntitySetName( this EntityKey key ) {
			return key.EntityContainerName + "." + key.EntitySetName;
		}

		public static IEntityWithKey GetEntityByKey( this ObjectContext context, EntityKey key ) {
			return (IEntityWithKey)context.ObjectStateManager.GetObjectStateEntry( key ).Entity;
		}

		//
		// ObjectStateEntry
		//

		public static IExtendedDataRecord UsableValues( this ObjectStateEntry entry ) {
			switch ( entry.State ) {
				case EntityState.Added:
				case EntityState.Detached:
				case EntityState.Unchanged:
				case EntityState.Modified:
					return (IExtendedDataRecord)entry.CurrentValues;
				case EntityState.Deleted:
					return (IExtendedDataRecord)entry.OriginalValues;
				default:
					throw new InvalidOperationException( "This entity state should not exist." );
			}
		}

		public static EdmType EdmType( this ObjectStateEntry entry ) {
			return entry.UsableValues().DataRecordInfo.RecordType.EdmType;
		}

		public static bool IsManyToMany( this AssociationType associationType ) {
			foreach ( RelationshipEndMember endMember in associationType.RelationshipEndMembers ) {
				if ( endMember.RelationshipMultiplicity != RelationshipMultiplicity.Many ) {
					return false;
				}
			}
			return true;
		}

		//
		// RelationshipEntry
		//

		public static bool IsRelationshipForKey( this ObjectStateEntry entry, EntityKey key ) {
			if ( entry.IsRelationship == false ) {
				return false;
			}
			return ( (EntityKey)entry.UsableValues()[ 0 ] == key ) || ( (EntityKey)entry.UsableValues()[ 1 ] == key );
		}

		public static EntityKey OtherEndKey( this ObjectStateEntry relationshipEntry, EntityKey thisEndKey ) {
			Debug.Assert( relationshipEntry.IsRelationship );
			Debug.Assert( thisEndKey != null );

			if ( (EntityKey)relationshipEntry.UsableValues()[ 0 ] == thisEndKey ) {
				return (EntityKey)relationshipEntry.UsableValues()[ 1 ];
			}
			else if ( (EntityKey)relationshipEntry.UsableValues()[ 1 ] == thisEndKey ) {
				return (EntityKey)relationshipEntry.UsableValues()[ 0 ];
			}
			else {
				throw new InvalidOperationException( "Neither end of the relationship contains the passed in key." );
			}
		}

		public static string OtherEndRole( this ObjectStateEntry relationshipEntry, EntityKey thisEndKey ) {
			Debug.Assert( relationshipEntry != null );
			Debug.Assert( relationshipEntry.IsRelationship );
			Debug.Assert( thisEndKey != null );

			if ( (EntityKey)relationshipEntry.UsableValues()[ 0 ] == thisEndKey ) {
				return relationshipEntry.UsableValues().DataRecordInfo.FieldMetadata[ 1 ].FieldType.Name;
			}
			else if ( (EntityKey)relationshipEntry.UsableValues()[ 1 ] == thisEndKey ) {
				return relationshipEntry.UsableValues().DataRecordInfo.FieldMetadata[ 0 ].FieldType.Name;
			}
			else {
				throw new InvalidOperationException( "Neither end of the relationship contains the passed in key." );
			}
		}

		//
		// IRelatedEnd methods
		//

		public static bool IsEntityReference( this IRelatedEnd relatedEnd ) {
			Type relationshipType = relatedEnd.GetType();
			return ( relationshipType.GetGenericTypeDefinition() == typeof( EntityReference<> ) );
		}

		public static EntityKey GetEntityKey( this IRelatedEnd relatedEnd ) {
			Debug.Assert( relatedEnd.IsEntityReference() );
			Type relationshipType = relatedEnd.GetType();
			PropertyInfo pi = relationshipType.GetProperty( "EntityKey" );
			return (EntityKey)pi.GetValue( relatedEnd, null );
		}

		public static void SetEntityKey( this IRelatedEnd relatedEnd, EntityKey key ) {
			Debug.Assert( relatedEnd.IsEntityReference() );
			Type relationshipType = relatedEnd.GetType();
			PropertyInfo pi = relationshipType.GetProperty( "EntityKey" );
			pi.SetValue( relatedEnd, key, null );
		}

		public static bool Contains( this IRelatedEnd relatedEnd, EntityKey key ) {
			foreach ( object relatedObject in relatedEnd ) {
				Debug.Assert( relatedObject is IEntityWithKey );
				if ( ( (IEntityWithKey)relatedObject ).EntityKey == key ) {
					return true;
				}
			}
			return false;
		}

		//
		// queries over the context
		//

		public static IEnumerable<IEntityWithKey> GetEntities( this ObjectContext context, EntityState state ) {
			return from e in context.ObjectStateManager.GetObjectStateEntries( state )
				   where e.IsRelationship == false && e.Entity != null
				   select (IEntityWithKey)e.Entity;
		}

		public static IEnumerable<ObjectStateEntry> GetRelationships( this ObjectContext context, EntityState state ) {
			return from e in context.ObjectStateManager.GetObjectStateEntries( state )
				   where e.IsRelationship == true
				   select e;
		}

		public static IEnumerable<ObjectStateEntry> GetUnchangedManyToManyRelationships( this ObjectContext context ) {
			return context.GetRelationships( EntityState.Unchanged )
				.Where( e => ( (AssociationType)e.EdmType() ).IsManyToMany() );
		}

		public static IEnumerable<ObjectStateEntry> GetRelationshipsForKey( this ObjectContext context, EntityKey key, EntityState state ) {
			return context.GetRelationships( state ).Where( e => e.IsRelationshipForKey( key ) );
		}

		public static IEnumerable<IGrouping<IRelatedEnd, ObjectStateEntry>> GetRelationshipsByRelatedEnd( this ObjectContext context,
			IEntityWithKey entity, EntityState state ) {
			return from entry in context.GetRelationshipsForKey( entity.EntityKey, state )
				   group entry by ( (IEntityWithRelationships)entity ).RelationshipManager
								   .GetRelatedEnd( ( (AssociationType)( entry.EdmType() ) ).Name,
												  entry.OtherEndRole( entity.EntityKey ) );
		}

		//
		// original values
		//

		// Extension method for the ObjectContext which will create an object instance that is essentially equivalent
		// to the original object that was added or attached to the context before any changes were performed.
		// NOTE: This object will have no relationships--just the original value properties.
		public static object CreateOriginalValuesObject( this ObjectContext context, object source ) {
			// Get the state entry of the source object
			//     NOTE: For now we require the object to implement IEntityWithKey.
			//           This is something we should be able to relax later.
			Debug.Assert( source is IEntityWithKey );
			EntityKey sourceKey = ( (IEntityWithKey)source ).EntityKey;
			// This method will throw if the key is null or an entry isn't found to match it.  We
			// could throw nicer exceptions, but this will catch the important invalid cases.
			ObjectStateEntry sourceStateEntry = context.ObjectStateManager.GetObjectStateEntry( sourceKey );

			// Return null for added entities & throw an exception for detached ones.  In other cases we can
			// always make a new object with the original values.
			switch ( sourceStateEntry.State ) {
				case EntityState.Added:
					return null;
				case EntityState.Detached:
					throw new InvalidOperationException( "Can't get original values when detached." );
			}

			// Create target object and add it to the context so that we can easily set properties using 
			// the StateEntry.  Since objects in the added state use temp keys, we know this won't
			// conflict with anything already in the context.
			object target = Activator.CreateInstance( source.GetType() );
			string fullEntitySetName = sourceKey.EntityContainerName + "." + sourceKey.EntitySetName;
			context.AddObject( fullEntitySetName, target );
			EntityKey targetKey = context.CreateEntityKey( fullEntitySetName, target );
			
			ObjectStateEntry targetStateEntry = context.ObjectStateManager.GetObjectStateEntry( targetKey );

			// Copy original values from the sourceStateEntry to the targetStateEntry.  This will
			// cause the corresponding properties on the object to be set.
			for ( int i = 0; i < sourceStateEntry.OriginalValues.FieldCount; i++ ) {
				// TODO: For best perf we should have a switch on the type here so that we could call 
				// the type-specific methods and avoid boxing.
				targetStateEntry.CurrentValues.SetValue( i, sourceStateEntry.OriginalValues[ i ] );
			}

			// Detach the object we just created since we only attached it temporarily in order to use 
			// the stateEntry.
			context.Detach( target );

			// Set the EntityKey property on the object (if it implements IEntityWithKey).
			IEntityWithKey targetWithKey = target as IEntityWithKey;
			if ( targetWithKey != null ) {
				targetWithKey.EntityKey = sourceKey;
			}

			return target;
		}

		public static object CreateOriginalValuesObjectWithReferences( this ObjectContext context, object source ) {
			object target = context.CreateOriginalValuesObject( source );
			EntityKey srcKey = ( (IEntityWithKey)source ).EntityKey;
			IEntityWithRelationships sourceWithRelationships = source as IEntityWithRelationships;
			if ( sourceWithRelationships == null ) {
				return target;
			}

			foreach ( var relationshipGroup in context.GetRelationshipsByRelatedEnd( (IEntityWithKey)target,
																				   EntityState.Unchanged | EntityState.Deleted ) ) {
				IRelatedEnd tgtRelatedEnd = (IRelatedEnd)relationshipGroup.Key;
				foreach ( ObjectStateEntry srcEntry in relationshipGroup ) {
					if ( tgtRelatedEnd.IsEntityReference() ) {
						tgtRelatedEnd.SetEntityKey( srcEntry.OtherEndKey( srcKey ) );
					}
				}
			}

			return target;
		}
	}
}