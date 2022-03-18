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

namespace SeleniumAutomation.Tests.TextBox
{
    [TestClass]
    public class TestTextBox
    {
        [TestMethod]
        public void TextBox()
        {
            Console.WriteLine("Test method Started");

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());

            Console.WriteLine("Title of the Page is : {0}", WindowHelper.GetTitle());

            LinkHelper.ClickLink(By.LinkText("Home"));

            Thread.Sleep(2000);

            TextBoxHelper.ClearTextBox(By.XPath("//td[@class='gsc-input']//input[@class='gsc-input']"));

            TextBoxHelper.TypeInTextBox(By.XPath("//td[@class='gsc-input']//input[@class='gsc-input']"), ObjectRepository.Config.GetUserName());

            TextBoxHelper.ClearTextBox(By.XPath("//td[@class='gsc-input']//input[@class='gsc-input']"));

            TextBoxHelper.TypeInTextBox(By.XPath("//td[@class='gsc-input']//input[@class='gsc-input']"), ObjectRepository.Config.GetPassword());

            //IWebElement element = ObjectRepository.Driver.FindElement(By.XPath("//td[@class='gsc-input']//input[@class='gsc-input']"));
            //element.SendKeys(ObjectRepository.Config.GetUserName());

            Thread.Sleep(2000);

            Console.WriteLine("Test method Ended");
        }
    }
}
