using SeleniumAutomation.Interface;
using SeleniumAutomation.Settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Configuration
{
    public class AppConfigReader : IConfig
    {
        public BrowserType GetBrowser()
        {
            string browser = ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
            return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
        }

        public int GetElementLoadTimeout()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.ElementLoadTimeout);
            if (timeout == null)
            {
                return 30;
            }
            else
            {
                return Convert.ToInt32(timeout);
            }
        }

        public int GetPageLoadTimeout()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.PageLoadTimeout);
            if(timeout==null)
            {
                return 30;
            }
            else
            {
                return Convert.ToInt32(timeout);
            }
        }

        public string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Password);
        }
        public string GetUserName()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.UserName);
        }
        public string GetWebsite()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Website);
        }
    }
}
