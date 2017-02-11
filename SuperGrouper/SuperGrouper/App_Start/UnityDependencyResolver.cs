using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace SuperGrouper.App_Start
{
    public class UnityDependencyResolver: UnityScopeContainer, IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private readonly IUnityContainer container;
        public UnityDependencyResolver(IUnityContainer container): base(container)
        {
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityScopeContainer(child);
        }
    }
}