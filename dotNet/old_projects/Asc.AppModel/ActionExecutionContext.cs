using System;
using System.Collections.Generic;

namespace Asc.AppModel {
	/// <summary>
	/// Контекст выполнения действия
	/// </summary>
	public class ActionExecutionContext : IServiceLocator {
		private readonly ApplicationRuntime appRuntime;
		protected internal ActionExecutionContext( ApplicationRuntime appRuntime ) {
			this.appRuntime = appRuntime;
		}

		/// <summary>
		/// Возвращает зарегистрированный в среде исполнения сервис
		/// </summary>
		public T GetService<T>() {
			return appRuntime.ServiceLocationContainer.Resolve<T>();
		}

		/// <summary>
		/// Возвращает зарегистрированный в среде исполнения сервис с учетом имени указанного при регистрации.
		/// </summary>
		public T GetService<T>(string name) {
			return appRuntime.ServiceLocationContainer.Resolve<T>( name );
		}

		/// <summary>
		/// Возвращает все зарегистрированные сервисы с указанными типом.
		/// </summary>
		/// <typeparam name="T">тип сервисов</typeparam>
		/// <returns></returns>
		public IEnumerable<T> GetAllServices<T>() {
			return appRuntime.ServiceLocationContainer.ResolveAbsolutelyAll<T>( );
		}

		/// <summary>
		/// Passes the existing object of type T through the container and performs all configured injection upon it.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="existing"></param>
		public T BuildUp<T>( T existing ) {
			return appRuntime.ServiceLocationContainer.BuildUp( existing );
		}

		/// <summary>
		/// Passes the existing object of type T with the specified name through the container and performs all configured injection upon it.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="existing"></param>
		/// <param name="name"></param>
		public T BuildUp<T>( T existing, string name ) {
			return appRuntime.ServiceLocationContainer.BuildUp( existing, name );
		}

		/// <summary>
		/// Состояние выполнения
		/// </summary>
		public ExecutionState State {
			get;
			private set;
		}

		public void CancelExecution() {
			State = ExecutionState.Cancellation;
		}

		internal void Run() {
			State = ExecutionState.Execution;
		}

		internal void Fault() {
			State = ExecutionState.Faulting;
		}

		/// <summary>
		/// Сброс состояния
		/// </summary>
		internal void Reset() {
			State = ExecutionState.Initialization;
		}
	}
}
