using OpenQA.Selenium;
using SeleniumAutomation.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumAutomation.PageObjects
{
    public class HomePage
    {
        #region WebElement

        private By QuickSearchTextBox = By.XPath("//input[@title='search' and @name='q']");
        private By QuickSearchButton = By.XPath("//input[@title='search' and @class='gsc-search-button']");
        private By Links = By.XPath("//div[@class='widget-content']//a[contains(.,'SoapUI')]");

        #endregion

        #region Actions

        public void QuickSeaarch(string text)
        {
            ObjectRepository.Driver.FindElement(QuickSearchTextBox).SendKeys(text);
            ObjectRepository.Driver.FindElement(QuickSearchButton).Click();
        }

        #endregion

        #region Navigation

        public LP NavigateToLogin()
        {
            ObjectRepository.Driver.FindElement(Links).Click();
            return new LP();
        }

        #endregion
    }
}
