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

namespace SeleniumAutomation.Tests.WebElement
{
    [TestClass]
    public class TestWebElement
    {
        [TestMethod]
        public void GetElement()
        {
            Console.WriteLine("Test method Started");

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());

            Thread.Sleep(10000);

            Console.WriteLine("Title of the Page is : {0}", WindowHelper.GetTitle());
           
            try
            {
                ObjectRepository.Driver.FindElement(By.XPath("//td[@class='gsc-input']//input[@name='q']"));
                ObjectRepository.Driver.FindElement(By.XPath("//td[@class='gsc-search-button']//input[@title='search']"));
                //ObjectRepository.Driver.FindElement(By.XPath("//td[@class='gsc-search-button']//input[@title='search121']"));

                IList<string> list = new List<string>();
                list.Add("Task 1");
                list.Add("Task 2");
                list.Add("Task 3");
                list.Add("Task 4");
                Console.WriteLine("Size : {0}",list.Count);

                list.Remove("Task 2");

                Console.WriteLine("Size : {0}", list.Count);

            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2.Message);
            }

            Console.WriteLine("Test method Ended");
        }
    }
}
