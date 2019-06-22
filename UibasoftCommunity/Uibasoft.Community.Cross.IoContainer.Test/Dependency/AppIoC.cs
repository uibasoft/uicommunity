using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Uibasoft.Community.Cross.IoContainer.Test.Entities;
using Uibasoft.Community.Cross.IoContainer.Unity;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Uibasoft.Community.Cross.IoContainer.Test.Dependency
{
    public class AppIoC : UnityIoC
    {
        public AppIoC() : base()
        {
            Initialize();
        }
        public void Initialize()
        {
            var unity = base.RootContainer;

            var objeto = new
            {
                Id = "fuente-digital",
                Name = "Fuente Digital",
                Description = "Descripcion Fuente Digital"
            };

            var fuente = new FuenteDigital();
            fuente.Id = objeto.Id;
            fuente.Name = objeto.Name;

            unity.RegisterInstance("FUENTEDIG",fuente,new ContainerControlledLifetimeManager());

            unity.RegisterType<FuenteDigital>(new ContainerControlledLifetimeManager(),
                new InjectionProperty("Id", objeto.Id), new InjectionProperty("Name", objeto.Name));

            unity.RegisterType<IClase, Demo>(new ContainerControlledLifetimeManager());
            unity.RegisterType<IClase, Demo>("Singleton", new ContainerControlledLifetimeManager());
            unity.RegisterType<IClase, Demo>("Transient", new TransientLifetimeManager());

        }
    }
}
