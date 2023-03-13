using System;
using System.Collections.Generic;
using System.Linq;
using AutomationFramework.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebdriver.ComponentHelper
{
    public class DropdownHelper
    {
        private static SelectElement select;

        public static void SelectElementByIndex(By locator, int index, string elementName)
        {
            GenericHelper.WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
            select = new SelectElement(GenericHelper.GetElement(locator, elementName));
            select.SelectByIndex(index);
        }

        public static void SelectElementByVisibleText(By locator, string visibleText, string elementName)
        {
            select = new SelectElement(GenericHelper.GetElement(locator, elementName));
            select.SelectByText(visibleText);
        }


        public static void SelectElementByValue(By locator, string value, string elementName)
        {
            select = new SelectElement(GenericHelper.GetElement(locator, elementName));
            select.SelectByValue(value);
        }


        public static IList<string> GetAllElements(By locator, string elementName)
        {
            GenericHelper.WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
            select = new SelectElement(GenericHelper.GetElement(locator, elementName));
            return select.Options.Select((x) => x.Text).ToList();
        }

        public static void SelectElement(IWebElement element, string visibletext)
        {
            select = new SelectElement(element);
            select.SelectByValue(visibletext);
        }

        public static string GetSelectedOptionText(By locator, string elementName)
        {
            GenericHelper.WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
            select = new SelectElement(GenericHelper.GetElement(locator, elementName));
            return select.SelectedOption.Text;
        }
    }
}
