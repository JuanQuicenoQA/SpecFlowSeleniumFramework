using System;
using AutomationFramework.Configuration;
using OpenQA.Selenium;

namespace SeleniumWebdriver.ComponentHelper
{
    public class LinkHelper
    {
        private static IWebElement element;

        public static void clickLink(By locator, string elementName)
        {
            GenericHelper.WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
            element = GenericHelper.GetElement(locator, elementName);
            element.Click();
        }

        public static bool visible(By locator, string elementName)
        {
            GenericHelper.WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
            return GenericHelper.IsElementPresent(locator);
        }
    }
}
