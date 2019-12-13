using System;
using Hyland.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using UnityAddons.WorkView;
using Hyland.Unity.WorkView;

namespace UnityAddons.Tests
{
    [TestClass]
    public class FilterHelperTests
    {
        [TestMethod]
        public void GroupThreeLongConstraints()
        {
            using (var app = Hyland.Unity.Application.Connect(Hyland.Unity.Application.CreateOnBaseAuthenticationProperties(
                ConfigurationManager.AppSettings["ServiceUrl"],
                ConfigurationManager.AppSettings["LoginUsername"],
                ConfigurationManager.AppSettings["LoginPassword"],
                ConfigurationManager.AppSettings["Datasource"])))
            {
                var wvQuery = app.WorkView.Applications.Find("APA")?.Filters.Find("FB_All Messages").CreateFilterQuery();

                wvQuery.AddGroupedConstraints("UsedCount", Operator.Equal, 10L, 20L, 30L);

                // Count check
                Assert.AreEqual(3, wvQuery.Constraints.Count);

                // Grouping check
                Assert.AreEqual(Grouping.OpenParenthesis, wvQuery.Constraints[0].Grouping);
                Assert.AreEqual(Grouping.NoParenthesis, wvQuery.Constraints[1].Grouping);
                Assert.AreEqual(Grouping.CloseParenthesis, wvQuery.Constraints[2].Grouping);

                // Value check
                Assert.AreEqual(10L, wvQuery.Constraints[0].IntegerValue);
                Assert.AreEqual(20L, wvQuery.Constraints[1].IntegerValue);
                Assert.AreEqual(30L, wvQuery.Constraints[2].IntegerValue);

                // Operator check
                Assert.AreEqual(Operator.Equal, wvQuery.Constraints[0].Operator);
                Assert.AreEqual(Operator.Equal, wvQuery.Constraints[1].Operator);
                Assert.AreEqual(Operator.Equal, wvQuery.Constraints[2].Operator);

                // Connector check
                Assert.AreEqual(Connector.OrConnector, wvQuery.Constraints[0].Connector);
                Assert.AreEqual(Connector.OrConnector, wvQuery.Constraints[1].Connector);
            }
        }

        [TestMethod]
        public void GroupThreeStringConstraints()
        {
            using (var app = Hyland.Unity.Application.Connect(Hyland.Unity.Application.CreateOnBaseAuthenticationProperties(
                ConfigurationManager.AppSettings["ServiceUrl"],
                ConfigurationManager.AppSettings["LoginUsername"],
                ConfigurationManager.AppSettings["LoginPassword"],
                ConfigurationManager.AppSettings["Datasource"])))
            {
                var wvQuery = app.WorkView.Applications.Find("APA")?.Filters.Find("FB_All Messages").CreateFilterQuery();

                wvQuery.AddGroupedConstraints("Message", Operator.Equal, "This", "That", "Thing");

                // Count check
                Assert.AreEqual(3, wvQuery.Constraints.Count);

                // Grouping check
                Assert.AreEqual(Grouping.OpenParenthesis, wvQuery.Constraints[0].Grouping);
                Assert.AreEqual(Grouping.NoParenthesis, wvQuery.Constraints[1].Grouping);
                Assert.AreEqual(Grouping.CloseParenthesis, wvQuery.Constraints[2].Grouping);

                // Value check
                Assert.AreEqual("This", wvQuery.Constraints[0].AlphanumericValue);
                Assert.AreEqual("That", wvQuery.Constraints[1].AlphanumericValue);
                Assert.AreEqual("Thing", wvQuery.Constraints[2].AlphanumericValue);

                // Operator check
                Assert.AreEqual(Operator.Equal, wvQuery.Constraints[0].Operator);
                Assert.AreEqual(Operator.Equal, wvQuery.Constraints[1].Operator);
                Assert.AreEqual(Operator.Equal, wvQuery.Constraints[2].Operator);

                // Connector check
                Assert.AreEqual(Connector.OrConnector, wvQuery.Constraints[0].Connector);
                Assert.AreEqual(Connector.OrConnector, wvQuery.Constraints[1].Connector);
            }
        }

        [TestMethod]
        public void GroupThreeDecimalConstraints()
        {
            using (var app = Hyland.Unity.Application.Connect(Hyland.Unity.Application.CreateOnBaseAuthenticationProperties(
                ConfigurationManager.AppSettings["ServiceUrl"],
                ConfigurationManager.AppSettings["LoginUsername"],
                ConfigurationManager.AppSettings["LoginPassword"],
                ConfigurationManager.AppSettings["Datasource"])))
            {
                var wvQuery = app.WorkView.Applications.Find("APA")?.Filters.Find("FB_All Invoices").CreateFilterQuery();

                wvQuery.AddGroupedConstraints("InvoiceAmount", Operator.Equal, 100.00M, 15.00M, 10.00M);

                // Count check
                Assert.AreEqual(3, wvQuery.Constraints.Count);

                // Grouping check
                Assert.AreEqual(Grouping.OpenParenthesis, wvQuery.Constraints[0].Grouping);
                Assert.AreEqual(Grouping.NoParenthesis, wvQuery.Constraints[1].Grouping);
                Assert.AreEqual(Grouping.CloseParenthesis, wvQuery.Constraints[2].Grouping);

                // Value check
                Assert.AreEqual(100.00M, wvQuery.Constraints[0].CurrencyValue);
                Assert.AreEqual(15.00M, wvQuery.Constraints[1].CurrencyValue);
                Assert.AreEqual(10.00M, wvQuery.Constraints[2].CurrencyValue);

                // Operator check
                Assert.AreEqual(Operator.Equal, wvQuery.Constraints[0].Operator);
                Assert.AreEqual(Operator.Equal, wvQuery.Constraints[1].Operator);
                Assert.AreEqual(Operator.Equal, wvQuery.Constraints[2].Operator);

                // Connector check
                Assert.AreEqual(Connector.OrConnector, wvQuery.Constraints[0].Connector);
                Assert.AreEqual(Connector.OrConnector, wvQuery.Constraints[1].Connector);
            }
        }

        [TestMethod]
        public void GroupTwoBooleanConstraints()
        {
            using (var app = Hyland.Unity.Application.Connect(Hyland.Unity.Application.CreateOnBaseAuthenticationProperties(
                ConfigurationManager.AppSettings["ServiceUrl"],
                ConfigurationManager.AppSettings["LoginUsername"],
                ConfigurationManager.AppSettings["LoginPassword"],
                ConfigurationManager.AppSettings["Datasource"])))
            {
                var wvQuery = app.WorkView.Applications.Find("APA")?.Filters.Find("FB_All Invoices").CreateFilterQuery();

                wvQuery.AddGroupedConstraints("Posted", Operator.Equal, true, false);

                // Count check
                Assert.AreEqual(2, wvQuery.Constraints.Count);

                // Grouping check
                Assert.AreEqual(Grouping.OpenParenthesis, wvQuery.Constraints[0].Grouping);
                Assert.AreEqual(Grouping.CloseParenthesis, wvQuery.Constraints[1].Grouping);

                // Value check
                Assert.AreEqual(true, wvQuery.Constraints[0].BooleanValue);
                Assert.AreEqual(false, wvQuery.Constraints[1].BooleanValue);

                // Operator check
                Assert.AreEqual(Operator.Equal, wvQuery.Constraints[0].Operator);
                Assert.AreEqual(Operator.Equal, wvQuery.Constraints[1].Operator);

                // Connector check
                Assert.AreEqual(Connector.OrConnector, wvQuery.Constraints[0].Connector);
            }
        }
    }
}
