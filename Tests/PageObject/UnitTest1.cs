using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAutomation.ComponentHelpers;
using SeleniumAutomation.Settings;
using SeleniumAutomation.PageObjects;

namespace SeleniumAutomation.Tests.PageObject
{
    [TestClass]
    public class TestPageObject
    {
        [TestMethod]
        public void TestPage()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());

            HomePage homePage = new HomePage();
            homePage.QuickSeaarch("Test");
            LP lp = homePage.NavigateToLogin()
                .NavigateNextPrevious();


        }
    }
}
