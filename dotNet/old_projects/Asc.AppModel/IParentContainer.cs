using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace Asc.AppModel {
	public interface IParentContainer {
		IUnityContainer CreateChildContainer();
	}
}
