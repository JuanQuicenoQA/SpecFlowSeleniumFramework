using System;
using AutomationFramework.Configuration;
using OpenQA.Selenium;

namespace SeleniumWebdriver.ComponentHelper
{
    public class TextBoxHelper
    {
        private static IWebElement element;

        public static void TypeInTextBox(By locator, string Text, string elementName)
        {
            GenericHelper.WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
            element = GenericHelper.GetElement(locator, elementName);
            element.SendKeys(Text);
        }

        public static void ClearTextBox(By locator, string elementName)
        {
            GenericHelper.WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
            element = GenericHelper.GetElement(locator, elementName);
            element.Clear();
        }

        public static void SelectAll(By locator, string elementName)
        {
            GenericHelper.WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
            element = GenericHelper.GetElement(locator, elementName);
            element.SendKeys(Keys.Control + "a");
        }

        public static void DeleteText(By locator, string elementName)
        {
            GenericHelper.WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
            element = GenericHelper.GetElement(locator, elementName);
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
        }

        public static string GetTextboxText(By locator, string elementName)
        {
            GenericHelper.WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
            element = GenericHelper.GetElement(locator, elementName);
            return element.GetAttribute("value");
        }

        public static bool IsTextBoxEnabled(By locator, string elementName)
        {
            GenericHelper.WaitForElementVisibility(locator, 5, nameof(elementName));
            element = GenericHelper.GetElement(locator, elementName);
            return element.Enabled;
        }
    }
}
