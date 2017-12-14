using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using Chinook.Plumbing;

using Chinook.Domain;
using Chinook.Persistence;
using Chinook.Persistence.Interfaces;
using Chinook.Persistence.Impl;

namespace Chinook.Installers
{
    public class PersistenceInstaller : IWindsorInstaller
    {
        #region IWindsorInstaller Members

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IDbConnectionFactory))
                            .ImplementedBy(typeof(DbConnectionFactory))
                            .DependsOn(Property.ForKey("connectionName").Eq("Chinook"))
                            .LifeStyle.Singleton
            );

            container.Register(
                Component.For(typeof(IEntityDao<Track, int>))
                            .ImplementedBy(typeof(TrackDao))
                            .Named("genericTrackDao")
                            .LifeStyle.Transient
            );

            container.Register(
                Component.For(typeof(ITrackDao))
                            .ImplementedBy(typeof(TrackDao))
                            .LifeStyle.Transient
            );
        }

        #endregion
    }
}