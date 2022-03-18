using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumAutomation.Configuration;
using SeleniumAutomation.CustomException;
using SeleniumAutomation.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.BaseClasses
{
    [TestClass]
    public class BaseClass
    {
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            //option.AddArgument("--headless"); 
            return option;
        }
        private static FirefoxOptions GetFirefoxoptions()
        {
            FirefoxOptions options = new FirefoxOptions();

            FirefoxProfile profile = new FirefoxProfile();
            FirefoxProfileManager manager = new FirefoxProfileManager();
            options.Profile = manager.GetProfile("default");

            return options;
        }
        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions option = new InternetExplorerOptions();
            option.IntroduceInstabilityByIgnoringProtectedModeSettings=true;
            option.EnsureCleanSession = true;
            return option;
        }
        private static IWebDriver GetFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver(GetFirefoxoptions());
            return driver;
        }
        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }
        private static IWebDriver GetIEDriver()
        {
            IWebDriver driver = new InternetExplorerDriver(GetIEOptions());
            return driver;
        }

        [AssemblyInitialize]
        public static void InitWebDriver(TestContext tc)
        {
            ObjectRepository.Config = new AppConfigReader();

            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFirefoxDriver();
                    break;
                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    break;
                case BrowserType.IExplorer:
                    ObjectRepository.Driver = GetIEDriver();
                    break;
                default:
                    throw new NoSuitableDriverFound("Driver Not Found : " + ObjectRepository.Config.GetBrowser().ToString());
            }
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeout());
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeout());
        }



        [AssemblyCleanup]
        public static void TearDown()
        {
            if(ObjectRepository.Driver!=null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }
        }
    }
}
