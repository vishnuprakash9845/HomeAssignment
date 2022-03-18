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

namespace SeleniumAutomation.Tests.Screenshots
{
    [TestClass]
    public class TakeScreenshots
    {
        [TestMethod]
        public void ScreenShots()
        {
            Console.WriteLine("Test method Started");

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());

            Console.WriteLine("Title of the Page is : {0}", WindowHelper.GetTitle());

            Thread.Sleep(2000);

            //ITakesScreenshot screenshot = ObjectRepository.Driver as ITakesScreenshot;
            //Screenshot screenshot1 = screenshot.GetScreenshot();
            //screenshot1.SaveAsFile(@"C:\Users\user\Desktop\Others\Resume Preparation\vip2.jpeg", ScreenshotImageFormat.Jpeg);

            GenericHelper.TakeScreenshot("Test.jpeg");

            GenericHelper.TakeScreenshot();

            Console.WriteLine("Test method Ended");
        }
    }
}
