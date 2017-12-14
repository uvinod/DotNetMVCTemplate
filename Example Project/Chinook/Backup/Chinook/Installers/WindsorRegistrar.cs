using System;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using Chinook.Plumbing;

namespace Chinook.Installers
{
    public class WindsorRegistrar
    {
        public static void RegisterSingleton(IWindsorContainer container, Type interfaceType, Type implementationType)
        {
            container.Register(Component.For(interfaceType).ImplementedBy(implementationType).LifeStyle.Singleton);
        }

        public static void Register(IWindsorContainer container, Type interfaceType, Type implementationType)
        {
            container.Register(Component.For(interfaceType).ImplementedBy(implementationType).LifeStyle.PerWebRequest);
        }
    }
}