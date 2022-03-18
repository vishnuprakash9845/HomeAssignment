using SeleniumAutomation.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.ComponentHelpers
{
    public class NavigationHelper
    {
        public static void NavigateToUrl(string url)
        {
            ObjectRepository.Driver.Navigate().GoToUrl(url);
        }
    }
}
