using System;
using System.Collections.Generic;

namespace Asc.AppModel {
	/// <summary>
	/// Предоставляет доступ к сервисам
	/// </summary>
	public interface IServiceLocator {
		/// <summary>
		/// Возвращает зарегистрированный в среде исполнения сервис
		/// </summary>
		T GetService<T>();

		/// <summary>
		/// Возвращает зарегистрированный в среде исполнения сервис с учетом имени указанного при регистрации.
		/// </summary>
		T GetService<T>( string name );

		/// <summary>
		/// Возвращает все зарегистрированные сервисы с указанными типом.
		/// </summary>
		/// <typeparam name="T">тип сервисов</typeparam>
		/// <returns></returns>
		IEnumerable<T> GetAllServices<T>();

		/// <summary>
		/// Passes the existing object of type T through the container and performs all configured injection upon it.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="existing"></param>
		T BuildUp<T>( T existing );

		/// <summary>
		/// Passes the existing object of type T with the specified name through the container and performs all configured injection upon it.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="existing"></param>
		/// <param name="name"></param>
		T BuildUp<T>( T existing, string name );
	}
}
