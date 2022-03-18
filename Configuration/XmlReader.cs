using SeleniumAutomation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Configuration
{
    public class XmlReader : IConfig
    {
        public BrowserType GetBrowser()
        {
            throw new NotImplementedException();
        }

        public int GetElementLoadTimeout()
        {
            throw new NotImplementedException();
        }

        public int GetPageLoadTimeout()
        {
            throw new NotImplementedException();
        }

        public string GetPassword()
        {
            throw new NotImplementedException();
        }

        public string GetUserName()
        {
            throw new NotImplementedException();
        }

        public string GetWebsite()
        {
            throw new NotImplementedException();
        }
    }
}
