using System;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System.ComponentModel;

namespace Asc.Utils.Validation {
	internal class ValidatableImplementation : IValidatable {

		private ValidationResults results;
		private readonly object instance;

		private bool continuously;
		private bool tracked;

		public ValidatableImplementation( object instance ) {
			this.instance = instance;
		}

		#region IValidatable Members

		public bool IsValid {
			get {
				if ( results == null ) {
					ValidateCore();
				}
				return results.IsValid;
			}
		}

		public ValidationResults Results {
			get {
				return results;
			}
		}

		public bool Validate() {
			continuously = false;
			ValidateCore();
			return IsValid;
		}

		public bool ValidateContinuously() {
			continuously = true;
			ValidateCore();
			return IsValid;
		}

		public void ClearValidation() {
			continuously = false;
			results = null;
			EndTrackObject();
		}

		protected virtual void ValidateCore() {
			Validator validator = Microsoft.Practices.EnterpriseLibrary.Validation.
				ValidationFactory.CreateValidator( instance.GetType() );
			if ( validator == null ) {
				return;
			}

			results = validator.Validate( instance );

			if ( !results.IsValid ) {
				BeginTrackObject();
			}
			else if ( !continuously ) {
				EndTrackObject();
			}
		}

		private void BeginTrackObject() {
			if ( !tracked && instance is INotifyPropertyChanged ) {
				( (INotifyPropertyChanged)instance ).PropertyChanged += Instance_PropertyChanged;
				tracked = true;
			}
		}

		private void Instance_PropertyChanged( object sender, PropertyChangedEventArgs e ) {
			ValidateCore();
		}

		private void EndTrackObject() {
			if ( tracked ) {
				( (INotifyPropertyChanged)instance ).PropertyChanged -= Instance_PropertyChanged;
				tracked = false;
			}
		}
		#endregion

		#region IDataErrorInfo Members

		public string Error {
			get {
				if ( results != null && !results.IsValid ) {
					ValidationResult res = results.FirstOrDefault( r => String.IsNullOrEmpty( r.Key ) );
					if ( res != null ) {
						return res.Message;
					}
				}
				return string.Empty;
			}
		}

		public string this[ string propertyName ] {
			get {
				if ( results != null && !results.IsValid ) {
					ValidationResult result = results.FirstOrDefault( 
						r => String.CompareOrdinal( r.Key, propertyName ) == 0 
					);
					if ( result != null ) {
						return result.Message;
					}
				}
				return string.Empty;
			}
		}

		#endregion
	}
}
