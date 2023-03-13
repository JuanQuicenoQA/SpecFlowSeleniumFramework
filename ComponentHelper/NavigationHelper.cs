using AutomationFramework.Resources;

namespace SeleniumWebdriver.ComponentHelper
{
    public class NavigationHelper
    {
        public static void NavigateToUrl(string Url)
        {
            ObjectRepository.Driver.Navigate().GoToUrl(Url);
        }

        public static void RefreshPage()
        {
            ObjectRepository.Driver.Navigate().Refresh();
        }

        public static string getUrl()
        {
            return ObjectRepository.Driver.Url;
        }
    }
}
