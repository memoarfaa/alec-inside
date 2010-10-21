using System;
using System.Linq;
using Microsoft.Practices.Unity;
using Asc.Utils.CollectionExtensions;
using Asc.Messaging;

namespace Asc.AppModel {
	/// <summary>
	/// Среда исполнения приложения
	/// </summary>
	/// <remarks>
	/// Обрабатывает приходящие сообщения, создает и выполняет соответствующие им действия.
	/// Для получения сообщений необходимо зарегистрировать одну или несколько служб IAsyncMessageReceiverService.
	/// Для создания действий необходимо зарегистрировать службу IActionFactoryService.	
	/// </remarks>
	public class ApplicationRuntime : IDisposable {
		/// <summary>
		/// Контейнер для регистрации служб. 
		/// </summary>
		private IUnityContainer serviceContainer = new UnityContainer();


		/// <summary>
		/// Контейнер для создания служб.
		/// </summary>
		// Для использования такого сценария нужен специальное расширение google:HierachicalLifetimeManager
		// потому что на самом деле если тип зарегистрирован в родительском контейнере, а разрешается (Resolve) 
		// в дочернем, то ссылка на объект все равно хранится в том контейнере, в котором зарегистрирован тип
		// Так как HierachicalLifetimeManager - непротестированный самопал и наши текущие задачи не требуют
		// уничтожения контейнера с объектами, то пока откажемся от дочернего контейнера.
		//private IUnityContainer serviceLocationContainer;		


		/// <summary>
		/// Возникает при возбуждении исключения
		/// </summary>
		public event EventHandler<ErrorEventArgs> OnMessageReceiveErrorOccured;


		public ApplicationRuntime() {
			serviceContainer.AddNewExtension<TypeTrackingExtension>();			
		}

		#region Service registration

		/// <summary>
		/// Регистрирует сервис
		/// </summary>
		/// <typeparam name="TFrom">Интерфейс сервиса</typeparam>
		/// <typeparam name="TTo">Тип сервиса</typeparam>
		/// <param name="lifetimeManager">Менеджер времени жизни</param>
		public void RegisterService<TFrom, TTo>( LifetimeManager lifetimeManager ) where TTo : TFrom {
			serviceContainer.RegisterType<TFrom, TTo>( lifetimeManager );
		}

		/// <summary>
		/// Регистрирует сервис
		/// </summary>
		/// <typeparam name="TFrom">Интерфейс сервиса</typeparam>
		/// <typeparam name="TTo">Тип сервиса</typeparam>
		/// <param name="name">Имя регистрации</param>
		/// <param name="lifetimeManager">Менеджер времени жизни</param>
		public void RegisterService<TFrom, TTo>( string name, LifetimeManager lifetimeManager ) where TTo : TFrom {
			serviceContainer.RegisterType<TFrom, TTo>( name, lifetimeManager );
		}

		/// <summary>
		/// Регистрирует сервис
		/// </summary>		
		/// <typeparam name="T">Тип сервиса</typeparam>
		/// <param name="lifetimeManager">Менеджер времени жизни</param>
		public void RegisterService<T>( LifetimeManager lifetimeManager ) {
			serviceContainer.RegisterType<T>( lifetimeManager );
		}

		/// <summary>
		/// Регистрирует сервис
		/// </summary>	
		/// <typeparam name="T">Тип сервиса</typeparam>
		/// <param name="name">Имя регистрации</param>
		/// <param name="lifetimeManager">Менеджер времени жизни</param>
		public void RegisterService<T>( string name, LifetimeManager lifetimeManager ) {
			serviceContainer.RegisterType<T>( name, lifetimeManager );
		}

		/// <summary>
		/// Регистрирует экземпляр сервиса
		/// </summary>		
		/// <typeparam name="TInterface">Интерфейс сервиса</typeparam>
		/// <param name="instance">Экземпляр сервиса</param>
		/// <param name="lifetimeManager">Менеджер времени жизни</param>
		public void RegisterServiceInstance<TInterface>( TInterface instance, LifetimeManager lifetimeManager ) {
			serviceContainer.RegisterInstance<TInterface>( instance, lifetimeManager );
		}

		/// <summary>
		/// Регистрирует экземпляр сервиса
		/// </summary>	
		/// <typeparam name="TInterface">Интерфейс сервиса</typeparam>
		/// <param name="name">Имя регистрации</param>
		/// <param name="lifetimeManager">Менеджер времени жизни</param>
		public void RegisterServiceInstance<TInterface>( string name, TInterface instance, LifetimeManager lifetimeManager ) {
			serviceContainer.RegisterInstance<TInterface>( name, instance, lifetimeManager );
		}

		/// <summary>
		/// Конфигурирует иньекцию зависимостей
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name"></param>
		/// <param name="injectionMembers"></param>
		public void ConfigureInjectionFor<T>( string name, params InjectionMember[] injectionMembers ) {
			serviceContainer.Configure<InjectedMembers>()
				.ConfigureInjectionFor<T>( name, injectionMembers );
		}

		/// <summary>
		/// Конфигурирует иньекцию зависимостей
		/// </summary>
		/// <typeparam name="T"></typeparam>		
		/// <param name="injectionMembers"></param>
		public void ConfigureInjectionFor<T>( params InjectionMember[] injectionMembers ) {
			serviceContainer.Configure<InjectedMembers>()
				.ConfigureInjectionFor<T>( injectionMembers );
		}

		#endregion

		/// <summary>
		/// Предоставляет доступ к контейнеру служб
		/// </summary>
		protected internal IUnityContainer ServiceLocationContainer {
			get {
				//return serviceLocationContainer;
				return serviceContainer;
			}
		}

		public bool IsStarted {
			get;
			private set;
		}

		/// <summary>
		/// Запускает среду исполнения.
		/// </summary>
		/// <remarks>
		/// Метод открывает получателей сообщений и возвращает управление.
		/// Если не зарегистрированы службы <b>IAsyncMessageReceiverService</b> и <b>IActionFactoryService</b>
		/// то будет вызвано исключение ServiceNotFoundException
		/// </remarks>
		public void StartRuntime() {
			if ( disposed ) {
				throw new ObjectDisposedException( GetType().Name );
			}

			CheckMainServicesExists();

			ConfigureContainerForDefaultServices();			

			StartRuntimeCore();
			IsStarted = true;
		}

		/// <summary>
		/// Реализует запуск среды
		/// </summary>
		protected virtual void StartRuntimeCore() {
			ProcessMessage( new BeforeStartUpMessage() );
			StartListenMessageReceivers();
			OnApplicationStart();
		}
		

		/// <summary>
		/// Конфигурирует контейнер службами по умолчанию
		/// </summary>
		protected virtual void ConfigureContainerForDefaultServices() {
			//serviceLocationContainer = serviceContainer.CreateChildContainer();
			//ServiceLocationContainer.AddNewExtension<TypeTrackingExtension>();
			var unityLocator = new UnityServiceLocator( ServiceLocationContainer );
			ServiceLocationContainer.RegisterInstance<IServiceLocator>( unityLocator,
				new ContainerControlledLifetimeManager() );
			ServiceLocationContainer.RegisterInstance<IParentContainer>( unityLocator,
				new ContainerControlledLifetimeManager() );

			var exceptionService = new ExceptionReceiverService();
			ServiceLocationContainer.RegisterInstance<IExceptionHandlerService>( exceptionService,
				new ContainerControlledLifetimeManager() );
			ServiceLocationContainer.RegisterInstance<IAsyncMessageReceiverService>(
				"ExceptionReceiver", exceptionService,
				new ContainerControlledLifetimeManager() );

		}
		/// <summary>
		/// Проверяет регистрацию жизненно необходимых служб
		/// </summary>
		protected virtual void CheckMainServicesExists() {
			if ( !serviceContainer.CanResolve<IActionFactoryService>() ) {
				throw new ServiceNotFoundException( typeof( IActionFactoryService ).Name );
			}
			if ( !serviceContainer.CanResolve<IAsyncMessageReceiverService>() ) {
				throw new ServiceNotFoundException( typeof( IAsyncMessageReceiverService ).Name );
			}
		}

		/// <summary>
		/// Выполняется при получении сообщения
		/// </summary>
		private void OnMessageReceived( object sender, MessageEventArgs e ) {			
			ProcessMessage( e.Message );
		}



		/// <summary>
		/// Обрабатывает сообщение
		/// </summary>
		/// <param name="message">Сообщение</param>
		protected void ProcessMessage( Message message ) {
			var actionExecutionContext = new ActionExecutionContext( this );

			var actionFactories = ServiceLocationContainer
				.ResolveAbsolutelyAll<IActionFactoryService>()
				.OrderByDescending( actf => Convert.ToInt32( actf.Priority ) );

			actionExecutionContext.Run();

			foreach ( var actionFactory in actionFactories ) {
				var action = actionFactory.Create( message );
				if ( action == null ) {
					continue;
				}

				if ( !AllowExecute( actionExecutionContext.State, action ) ) {
					continue;
				}

				try {
					ExecuteAction( action, actionExecutionContext );
				}
				catch ( Exception ex ) {
					OnErrorOccured( this, new ErrorEventArgs( ex ) );
					actionExecutionContext.Fault();
				}
				finally {
					GC.Collect();
				}
			}
		}

		private bool AllowExecute( ExecutionState state, IAction action ) {
			if ( state == ExecutionState.Cancellation ) {
				return action is IFinallyAction;
			}
			return true;
		}

		protected virtual void ExecuteAction( IAction action, ActionExecutionContext context ) {
			action.Execute( context );
		}

		/// <summary>
		/// Обработка поведений при запуске
		/// </summary>
		protected void OnApplicationStart() {
			var appBehaviors = ServiceLocationContainer.ResolveAbsolutelyAll<IApplicationBehavior>();
			if ( appBehaviors != null ) {
				appBehaviors.ForEach( behavior => behavior.OnStart() );
			}
		}

		/// <summary>
		/// Обработка поведений при завершении
		/// </summary>
		private void OnApplicationStop() {
			var appBehaviors = ServiceLocationContainer.ResolveAbsolutelyAll<IApplicationBehavior>();
			if ( appBehaviors != null ) {
				appBehaviors.ForEach( behavior => behavior.OnStop() );
			}
		}

		/// <summary>
		/// Запускает службы получения сообщений
		/// </summary>
		protected void StartListenMessageReceivers() {
			var messageReceivers = ServiceLocationContainer
				.ResolveAbsolutelyAll<IAsyncMessageReceiverService>()
				.OrderByDescending( receiver => Convert.ToInt32( receiver.Priority ) );
			if ( messageReceivers != null ) {
				foreach ( var messageReceiver in messageReceivers ) {
					messageReceiver.MessageReceived += OnMessageReceived;
					messageReceiver.ErrorOccured += OnErrorOccured;
					messageReceiver.Open();
				}
			}
		}

		/// <summary>
		/// Вызывается при возбуждении исключения 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnErrorOccured( object sender, ErrorEventArgs e ) {
			if ( OnMessageReceiveErrorOccured != null ) {
				OnMessageReceiveErrorOccured( null, e );
			}
			else {
				throw e.Exception;
			}
		}

		/// <summary>
		/// Прекращает работу служб получения сообщений
		/// </summary>
		private void StopListenMessageReceivers() {
			var messageReceivers = ServiceLocationContainer.ResolveAbsolutelyAll<IAsyncMessageReceiverService>();
			if ( messageReceivers != null ) {
				foreach ( var messageReceiver in messageReceivers ) {
					messageReceiver.Close();
					messageReceiver.MessageReceived -= OnMessageReceived;
				}
			}
		}


		/// <summary>
		/// Останавливает среду исполнения
		/// </summary>
		public void StopRuntime() {
			IsStarted = false;
			StopRuntimeCore();
		}

		/// <summary>
		/// Реализует прекращение работы среды 
		/// </summary>
		protected virtual void StopRuntimeCore() {
			OnApplicationStop();
			StopListenMessageReceivers();
		}


		#region IDisposable Members
		private bool disposed;
		public virtual void Dispose() {
			if ( !disposed ) {
				StopRuntime();
				serviceContainer.Dispose();
				serviceContainer = null;
				//serviceLocationContainer = null;
			}
			disposed = true;
		}

		#endregion
	}
}
