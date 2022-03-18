using OpenQA.Selenium;
using SeleniumAutomation.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.PageActions
{
    public class LoginAction
    {
        public IWebDriver driver;
        LoginPage loginPage;

        public LoginAction(IWebDriver driver)
        {
            loginPage = new LoginPage(driver);
        }

        public void EnterUserName(string userName)
        {
            loginPage.UsernameTextField.Clear();
            loginPage.UsernameTextField.SendKeys(userName);
        }
        public void EnterPassword(string password)
        {
            loginPage.PasswordTextField.Clear();
            loginPage.PasswordTextField.SendKeys(password);
        }
        public void ClickOnSignInButton()
        {
            loginPage.LoginButton.Click();
        }
    }
}
