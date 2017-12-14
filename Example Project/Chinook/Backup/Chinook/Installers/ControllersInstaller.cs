using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using Chinook.Controllers;

namespace Chinook.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(FindControllers().Configure(ConfigureControllers()));
        }

        private ConfigureDelegate ConfigureControllers()
        {
            return c => c.LifeStyle.Transient;
        }

        private BasedOnDescriptor FindControllers()
        {
            return AllTypes.FromThisAssembly()
              .BasedOn<IController>()
              .If(Component.IsInSameNamespaceAs<HomeController>())
              .If(t => t.Name.EndsWith("Controller"));
        }
    }
}