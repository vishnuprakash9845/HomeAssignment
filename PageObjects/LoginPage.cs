using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.PageObjects
{
    public class LoginPage
    {
        public IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement UsernameTextField => driver.FindElement(By.XPath("//input[@title='Search']"));
        public IWebElement PasswordTextField => driver.FindElement(By.Id(""));
        public IWebElement LoginButton => driver.FindElement(By.Id(""));
    }

}

