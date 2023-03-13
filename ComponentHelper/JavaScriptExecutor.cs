using System.Threading;
using AutomationFramework.Resources;
using OpenQA.Selenium;

namespace SeleniumWebdriver.ComponentHelper
{
    public class JavaScriptExecutor
    {
        public static object ExecuteScript(string script)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);
            return executor.ExecuteScript(script);

        }

        public static object ExecuteScript(string script, params object[] args)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);
            return executor.ExecuteScript(script, args);
        }

        public static void ScrollToAndClick(IWebElement element)
        {
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(300);
            element.Click();
        }

        public static void ScrollToAndClick(By locator)
        {
            IWebElement element = GenericHelper.GetElement(locator);
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(300);
            element.Click();
        }


    }
}
