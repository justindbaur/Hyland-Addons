using System;
using HylandAddons.WorkView;
using Hyland.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace HylandAddonsTests
{
    [TestClass]
    public class AttributeValueTests
    {
        [TestMethod]
        public void AlphanumericAttributeValue()
        {
            long testObjectId = 8163157;

            using (var app = Application.Connect(Application.CreateOnBaseAuthenticationProperties(
                ConfigurationManager.AppSettings["ServiceUrl"],
                ConfigurationManager.AppSettings["LoginUsername"],
                ConfigurationManager.AppSettings["LoginPassword"],
                ConfigurationManager.AppSettings["Datasource"])))
            {
                var wvObject = app.WorkView.Applications.Find("APA").Classes.Find("InvoiceXMessage").GetObjectByID(testObjectId);

                var messageAttributeValue = wvObject.AttributeValueByAddress("LinkToMessage.Message");

                Assert.IsNotNull(messageAttributeValue);
                Assert.AreEqual("Duplicate Invoice", messageAttributeValue.GetAlphanumericValue());
            }
        }
    }
}
