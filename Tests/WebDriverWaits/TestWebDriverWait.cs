using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomation.ComponentHelpers;
using SeleniumAutomation.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Tests.WebDriverWaits
{
    [TestClass]
    public class TestWebDriverWait
    {
        [TestMethod]
        public void TestWait()
        {
            //ObjectRepository.Driver.Manage().Timeouts().PageLoad= TimeSpan.FromSeconds(2);
            //ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            NavigationHelper.NavigateToUrl("https://www.tutorialspoint.com/how-to-set-page-load-timeout-using-chash-using-selenium-webdriver");

            TextBoxHelper.TypeInTextBox(By.XPath("//Input[@class='textxt']"), "Test");

        }
        [TestMethod]
        public void TestDynamicWait()
        {
            NavigationHelper.NavigateToUrl("https://www.tutorialspoint.com/how-to-set-page-load-timeout-using-chash-using-selenium-webdriver");
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(5));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            //wait.Until(waitForSearchBox());
            //Console.WriteLine(wait.Until(waitForTitle()));
            //IWebElement ele = wait.Until(waitForElement());
            //ele.Click();

            bool tt = GenericHelper.WaitForWebElement(By.XPath("//a[contains(.,'RDBMS')]"),TimeSpan.FromSeconds(50));

            IWebElement ele = GenericHelper.WaitForWebElementInPage(By.XPath("//a[contains(.,'RDBMS')]"), TimeSpan.FromSeconds(50));

        }

        [TestMethod]
        public void TestExpectedCondition()
        {
            NavigationHelper.NavigateToUrl("https://www.tutorialspoint.com/how-to-set-page-load-timeout-using-chash-using-selenium-webdriver");
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(5));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//span[text()='Login']"))).Click();
        }


        private Func<IWebDriver,bool> waitForSearchBox()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for search box {0}",DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss:ffff"));
                return x.FindElements(By.XPath("//a[contains(.,'RDBMS123')]")).Count > 0;
            });
        }

        private Func<IWebDriver,string> waitForTitle()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for title {0}", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss:ffff"));
                if (x.Title.Contains("Load"))
                    return x.Title;
                else
                    return null;
            });
        }

        private Func<IWebDriver, IWebElement> waitForElement()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for Element {0}", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss:ffff"));
                if (x.FindElements(By.XPath("//a[contains(.,'RDBMS')]")).Count > 0)
                    return x.FindElement(By.XPath("//a[contains(.,'RDBMS')]"));
                else
                    return null;
            });
        }
    }
}
