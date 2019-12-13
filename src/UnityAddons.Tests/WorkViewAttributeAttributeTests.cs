using Hyland.Unity;
using UnityAddons.WorkView;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace UnityAddons.Tests
{
    [TestClass]
    public class WorkViewAttributeAttributeTests
    {
        [TestMethod]
        public void DefinedAttributeAddress()
        {
            var ageProperty = typeof(Person).GetProperty("Age");

            Assert.AreEqual("Parent.Age", WorkViewAttributeAttribute.GetStringAddress(ageProperty));
        }

        [TestMethod]
        public void UndefinedAttributeAddress()
        {
            var nameProperty = typeof(Person).GetProperty("Name");

            Assert.AreEqual("Name", WorkViewAttributeAttribute.GetStringAddress(nameProperty));
        }

        [TestMethod]
        public void IsWorkViewAttributeNotDefined()
        {
            var dobProperty = typeof(Person).GetProperty("Birthday");

            Assert.IsFalse(WorkViewAttributeAttribute.IsDefined(dobProperty));
        }

        [TestMethod]
        public void IsWorkViewAttributeDefined()
        {
            var dobProperty = typeof(Person).GetProperty("Name");

            Assert.IsTrue(WorkViewAttributeAttribute.IsDefined(dobProperty));
        }

        [TestMethod]
        public void IsWorkViewAttributeOptional()
        {
            var bfProperty = typeof(Person).GetProperty("BestfriendName");

            Assert.IsTrue(WorkViewAttributeAttribute.IsOptional(bfProperty));
        }

        [TestMethod]
        public void IsWorkViewAttributeNotOptional()
        {
            var nameProperty = typeof(Person).GetProperty("Name");

            Assert.IsFalse(WorkViewAttributeAttribute.IsOptional(nameProperty));
        }

        [TestMethod]
        public void SerializeObject()
        {
            long testObjectId = 8163157;

            using (var app = Application.Connect(Application.CreateOnBaseAuthenticationProperties(
                ConfigurationManager.AppSettings["ServiceUrl"],
                ConfigurationManager.AppSettings["LoginUsername"],
                ConfigurationManager.AppSettings["LoginPassword"],
                ConfigurationManager.AppSettings["Datasource"])))
            {
                var wvObject = app.WorkView.Applications.Find("APA").Classes.Find("InvoiceXMessage").GetObjectByID(testObjectId);



                var invoiceXMessage = WorkViewObjectConvert.DeserializeWorkViewObject<InvoiceXMessage>(wvObject);

                var invoiceObject = wvObject.GetRelatedObject("LinkToInvoice");
                var messageObject = wvObject.GetRelatedObject("LinkToMessage");


                Assert.AreEqual(wvObject.AttributeValues.Find("IsHandled").BooleanValue, invoiceXMessage.IsHandled);
                Assert.AreEqual(invoiceObject.AttributeValues.Find("InvoiceNum").AlphanumericValue, invoiceXMessage.InvoiceNum);
            }
        }
    }
}
