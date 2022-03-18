using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumAutomation.Tests.TestClassContext
{
    [TestClass]
    public class TestClassContext
    {
        //public TestContext TestContext { get; set; }

        //private static TestContext _testContext;

        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"F:\Vishnu_udemy\BDD with Selenium Webdriver and Specflow using C#\11. DataDriven Framework\ddt.csv",
            "ddt#csv",
            DataAccessMethod.Sequential)]
        public void TestMethod1()
        {

            var bugSeverity = TestContext.DataRow["Severity"].ToString();
            var createdBy = TestContext.DataRow["Name"].ToString();
            Console.WriteLine("Test Name : {0}", TestContext.TestName);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            @"C:\Users\user\Documents\ddt.xml",
            "Row",
            DataAccessMethod.Sequential)]
        public void TestMethod2()
        {
            var bugSeverity = TestContext.DataRow["Severity"].ToString();
            var createdBy = TestContext.DataRow["Name"].ToString();
            Console.WriteLine("Severity : {0} , Name : {1}", bugSeverity, createdBy);
            Console.WriteLine("Test Name : {0}", TestContext.TestName);
        }
        [TestCleanup]
        public void TestMethod3()
        {
            Console.WriteLine("Test Result : {0}", TestContext.CurrentTestOutcome);
        }
    }
}
