using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Uibasoft.Community.Cross.IoContainer.Test.Entities;
using Uibasoft.Community.Cross.IoContainer.Unity;

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

            unity.RegisterType<FuenteDigital>(new ContainerControlledLifetimeManager(),
                new InjectionProperty("Id", objeto.Id), new InjectionProperty("Name", objeto.Name));
            unity.RegisterType<IClase, Demo>(new ContainerControlledLifetimeManager());
            unity.RegisterType<IClase, Demo>("Singleton", new ContainerControlledLifetimeManager());
            unity.RegisterType<IClase, Demo>("Transient", new TransientLifetimeManager());

        }
    }
}
