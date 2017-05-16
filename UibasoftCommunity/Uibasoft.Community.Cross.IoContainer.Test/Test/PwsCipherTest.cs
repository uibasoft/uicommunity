using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uibasoft.Community.Comunes.Security;
using Uibasoft.Community.Cross.IoContainer.Test.Dependency;
using Uibasoft.Community.Cross.IoContainer.Test.Services;

namespace Uibasoft.Community.Cross.IoContainer.Test.Test
{
    /// <summary>
    /// Descripción resumida de PwsCipherTest
    /// </summary>
    [TestClass]
    public class PwsCipherTest
    {

        [TestMethod]
        public void EncryptTest()
        {
            #region Arrange

            var cipher = new PwsCipher();

            var pws = "uibasoft";

            #endregion

            #region Act

            var cipherPws = cipher.Encrypt(pws);
            var date = new DateTime(2017,12,31).AddDays(90);            

            #endregion

            #region Assert

            Assert.IsTrue(pws!= cipherPws, "Error: No se cumple la logica de cifrado en EncryptTest");

            #endregion
        }

        [TestMethod]
        public void ValidatePasswordTest()
        {
            #region Arrange

            var cipher = new PwsCipher();

            var pws = "uibasoft";
            var pwsValidate = "uibasoft";

            #endregion

            #region Act

            var cipherPws = cipher.Encrypt(pws);

            var validate = cipher.ValidatePassword(pwsValidate, cipherPws);

            #endregion

            #region Assert

            Assert.IsTrue(validate, "Error: No se cumple la logica de cifrado en ValidatePasswordTest");

            #endregion
        }
    }
}
