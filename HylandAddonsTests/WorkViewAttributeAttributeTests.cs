using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HylandAddons.WorkView;

namespace HylandAddonsTests
{
    [TestClass]
    public class WorkViewAttributeAttributeTests
    {
        [TestMethod]
        public void DefinedAttributeAddress()
        {
            var ageProperty = typeof(Person).GetProperty("Age");

            Assert.AreEqual("Parent.Age", WorkViewAttributeAttribute.GetAddress(ageProperty));
        }

        [TestMethod]
        public void UndefinedAttributeAddress()
        {
            var nameProperty = typeof(Person).GetProperty("Name");

            Assert.AreEqual("Name", WorkViewAttributeAttribute.GetAddress(nameProperty));
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
    }
}
