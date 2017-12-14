using System;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using Chinook.Plumbing;

using Chinook.Core.Security;
using Chinook.Controllers;

using Chinook.Domain;

namespace Chinook.Installers
{
    public class GenericInstallers : IWindsorInstaller
    {
        #region IWindsorInstaller Members

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            WindsorRegistrar.Register(container, typeof(IFormsAuthentication), typeof(FormAuthService));
        }

        #endregion
    }
}