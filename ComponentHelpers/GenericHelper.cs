using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomation.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.ComponentHelpers
{
    public class GenericHelper
    {
        public static bool IsElementPresent(By locator)
        {
            try
            {
                var tt = ObjectRepository.Driver.FindElements(locator).Count;
                return ObjectRepository.Driver.FindElements(locator).Count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static IWebElement GetElement(By locator)
        {
            if (IsElementPresent(locator))
                return ObjectRepository.Driver.FindElement(locator);
            else
                throw new NoSuchElementException("Element Not found : " + locator.ToString());
        }

        public static void TakeScreenshot(string filename = "Screen")
        {
            ITakesScreenshot screenshot = ObjectRepository.Driver as ITakesScreenshot;
            Screenshot screenshot1 = screenshot.GetScreenshot();
            if (filename.Equals("Screen"))
            {
                string name = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
                screenshot1.SaveAsFile(name, ScreenshotImageFormat.Jpeg);
            }
            else
            {
                screenshot1.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
            }
        }

        public static bool WaitForWebElement(By locator, TimeSpan timout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(5));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            bool flag = wait.Until(waitForWebElementFunc(locator));

            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeout());
            return flag;
        }

        private static Func<IWebDriver, bool> waitForWebElementFunc(By locator)
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for element {0}", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss:ffff"));
                if (x.FindElements(locator).Count == 1)
                    return true;
                return false;
            });
        }

        public static IWebElement WaitForWebElementInPage(By locator, TimeSpan timout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(5));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            IWebElement flag = wait.Until(waitForWebElementInPageFunc(locator));

            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeout());
            return flag;
        }

        private static Func<IWebDriver, IWebElement> waitForWebElementInPageFunc(By locator)
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for element {0}", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss:ffff"));
                if (x.FindElements(locator).Count == 1)
                    return x.FindElement(locator);
                return null;
            });
        }
    }
}
