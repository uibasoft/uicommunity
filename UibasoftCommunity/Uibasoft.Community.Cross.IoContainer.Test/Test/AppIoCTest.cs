using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uibasoft.Community.Cross.IoContainer.Test.Dependency;
using Uibasoft.Community.Cross.IoContainer.Test.Entities;
using Uibasoft.Community.Cross.IoContainer.Test.Services;

namespace Uibasoft.Community.Cross.IoContainer.Test.Test
{
    /// <summary>
    /// Descripción resumida de AppIoCTest
    /// </summary>
    [TestClass]
    public class AppIoCTest
    {
        [TestMethod]
        public void ResolverTypeTest()
        {

            #region Arrange

            var container = new AppIoC();

            var entidad = new FuenteDigital();
            var typeEntidad = entidad.GetType();

            #endregion

            #region Act

            var typeFuente = container.Resolver(typeEntidad);
            var entidadResolved = typeFuente as FuenteDigital;

            #endregion

            #region Assert

            Assert.IsNotNull(typeFuente, "Error. Se ha producido un error al Resolver en ResolverTypeTest");
            Assert.IsNotNull(entidadResolved, "Error. Se ha producido un error al convertir en ResolverTypeTest");
            Assert.IsTrue(entidadResolved.Id == "fuente-digital", "Error. La propiedad Id del objeto FuenteDigital no corresponde al registrado en el container");

            #endregion           

        }
        [TestMethod]
        public void ResolverAllTest()
        {

            #region Arrange

            var containerUnity = new AppIoC();
            #endregion

            #region Act

            var clasesResolved = containerUnity.ResolverAll<IClase>();
            var listIds = new List<string>();
            foreach (var implementation in clasesResolved)
            {
                var demo = (Demo)implementation;
                demo.Id += 1;
                listIds.Add(demo.Id);
            }
            #endregion

            #region Assert

            Assert.IsNotNull(clasesResolved, "Error. Se ha producido un error al Resolver en ResolverAllTest");
            Assert.IsNotNull(listIds.Count > 0, "Error. Se ha producido un error al Resolver en ResolverAllTest");

            #endregion

        }
        [TestMethod]
        public void RegisterTypeTest()
        {

            #region Arrange

            var containerUnity = new AppIoC();
            #endregion

            #region Act
            containerUnity.RegisterType(typeof(Fenix));
            var resolverFenix = containerUnity.Resolver(typeof(Fenix));
            var fenixInstance = resolverFenix as Fenix;

            if (fenixInstance != null)
            {
                fenixInstance.Id = 100.ToString();

                #endregion

                #region Assert

                Assert.IsNotNull(resolverFenix, "Error. Se ha producido un error al Resolver " + typeof(Fenix));
                Assert.IsTrue(fenixInstance.Id == 100.ToString(), "Error. El identificador no corresponde al asignado.");
            }

            Assert.IsInstanceOfType(resolverFenix, typeof(Fenix), "Error: La instancia no corresponde al tipo especificado.");

            #endregion

        }
        [TestMethod]
        public void RegisterInstanceTest()
        {

            #region Arrange

            var container = new AppIoC();
            var demoService = new DemoService();

            #endregion

            #region Act

            container.RegisterInstance(typeof(IDemoService), demoService);
            var service = container.Resolver<DemoService>();
            var fecha = service.GetDateNowUtc();

            #endregion

            #region Assert

            Assert.IsNotNull(service, "Error. Se ha producido un error al Resolver " + typeof(DemoService).ToString());
            Assert.IsInstanceOfType(service, typeof(DemoService), "Error: La instancia no corresponde al tipo especificado.");
            Assert.IsTrue(!string.IsNullOrEmpty(fecha), "Error: La no contiene fecha especificada.");

            #endregion

        }

        [TestMethod]
        public void RegisterTypeByIoC()
        {
            #region Arrange

            var containerUnity = new AppIoC();
            IoC.SetContainer(containerUnity);
            var container = IoC.Container as AppIoC;

            #endregion

            #region Act

            if (container == null) return;

            container.RegisterType(typeof(IDemoService), typeof(DemoService));
            var service = container.Resolver<IDemoService>();
            var fechaNowUtc = service.GetDateNowUtc();

            #endregion

            #region Assert

            Assert.IsNotNull(service, "Error. Se ha producido un error al Resolver " + typeof(DemoService));
            Assert.IsInstanceOfType(service, typeof(DemoService), "Error: La instancia no corresponde al tipo especificado.");
            Assert.IsTrue(!string.IsNullOrEmpty(fechaNowUtc), "Error: La no contiene fecha especificada.");

            #endregion
        }
    }
}
