using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumAutomation.ComponentHelpers;
using SeleniumAutomation.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAutomation.Tests.PageNavigation
{
    [TestClass]
    public class TestHyperLink
    {
        [TestMethod]
        public void TestHyperLinkPage()
        {
            Console.WriteLine("Test method Started");

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());

            Thread.Sleep(2000);

            Console.WriteLine("Title of the Page is : {0}", WindowHelper.GetTitle());

            IWebElement element = ObjectRepository.Driver.FindElement(By.PartialLinkText("SoapUI"));

            LinkHelper.ClickLink(By.LinkText("Home"));

            Console.WriteLine("Test method Ended");
        }
    }
}
