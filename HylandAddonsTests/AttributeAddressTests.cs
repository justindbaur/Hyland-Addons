using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HylandAddons;

namespace HylandAddonsTests
{
    [TestClass]
    public class AttributeAddressTests
    {
        [TestMethod]
        public void MultiDepth()
        {
            var attributeAddress = new AttributeAddress("Item", "Thing", "Place");

            Assert.AreEqual(2, attributeAddress.Depth);
        }

        [TestMethod]
        public void SingleDepth()
        {
            var attributeAddress = new AttributeAddress("Item");

            Assert.AreEqual(0, attributeAddress.Depth);
        }

        [TestMethod]
        public void MultiPath()
        {
            var attributeAddress = new AttributeAddress("Item", "Thing", "Place");

            Assert.AreEqual("Item.Thing", attributeAddress.NavigationPath);
            Assert.AreEqual("Place", attributeAddress.FinalAttribute);
        }
    }
}
