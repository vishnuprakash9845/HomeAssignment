using OpenQA.Selenium;
using SeleniumAutomation.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAutomation.PageObjects
{
    public class LP
    {
        #region WebElement
        private By NextButton = By.XPath("//a[@class='member-next' and .='Next']");
        private By PreviousButton = By.XPath("//a[@class='member-prev' and .='Previous']");
        private By HomeLinks = By.XPath("//div[@class='widget-content']//a[contains(.,'Home')]");
        #endregion

        #region Actions

        public LP NavigateNextPrevious()
        {
            ObjectRepository.Driver.FindElement(NextButton).Click();
            Thread.Sleep(2000);
            ObjectRepository.Driver.FindElement(PreviousButton).Click();
            return this;
        }

        #endregion

        #region Navigation
        public void NavigateToLogin()
        {
            ObjectRepository.Driver.FindElement(HomeLinks).Click();
        }

        #endregion
    }
}
