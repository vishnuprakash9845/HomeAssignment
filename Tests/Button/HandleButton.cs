using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAutomation.ComponentHelpers;
using System.Threading;
using SeleniumAutomation.Settings;
using OpenQA.Selenium;

namespace SeleniumAutomation.Tests.Button
{
    [TestClass]
    public class HandleButton
    {
        [TestMethod]
        public void TestButton()
        {
            Console.WriteLine("Test method Started");

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());

            Console.WriteLine("Title of the Page is : {0}", WindowHelper.GetTitle());

            Thread.Sleep(2000);

            //IWebElement element = ObjectRepository.Driver.FindElement(By.XPath("//td[@class='gsc-input']//input[@class='gsc-input']"));
            //element.Click();

            ButtonHelper.ClickButton(By.XPath("//td[@class='gsc-search-button']//input[@class='gsc-search-button']"));

            Thread.Sleep(2000);

            Console.WriteLine("Enabled : {0}", ButtonHelper.IsButtonEnabled(By.XPath("//td[@class='gsc-search-button']//input[@class='gsc-search-button']")));

            Console.WriteLine("Button Text : {0}", ButtonHelper.GetButtonText(By.XPath("//td[@class='gsc-search-button']//input[@class='gsc-search-button']")));

            Console.WriteLine("Test method Ended");
        }
    }
}
