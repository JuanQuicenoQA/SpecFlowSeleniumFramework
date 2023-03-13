using System;
using AutomationFramework.Configuration;
using AutomationFramework.Resources;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumWebdriver.ComponentHelper
{
    public class ButtonHelper
    {
        private static IWebElement element;
        IWebElement addVisitButton;
        Actions actions = new Actions(ObjectRepository.Driver);



        public static string ClickButton(By locator, string elementName)
        {
            try
            {
                GenericHelper.WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
                element = GenericHelper.GetElement(locator, elementName);
                element.Click();
                return "Clickable";
            }
            catch (ElementClickInterceptedException e)
            {
                return "Not Clickable";
            }
        }

        public static bool IsButtonEnabled(By locator, string elementName)
        {
            GenericHelper.WaitForElementVisibility(locator, 5, nameof(elementName));
            element = GenericHelper.GetElement(locator, elementName);
            return element.Enabled;
        }

        public static string GetButtonName(By locator, string elementName)
        {
            GenericHelper.WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
            element = GenericHelper.GetElement(locator, elementName);
            if (element.GetAttribute("value") == null)
            {
                return string.Empty;
            }
            else
            {
                return element.GetAttribute("value");
            }
        }

        public static string GetTextboxText(By locator, string elementName)
        {
            GenericHelper.WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
            element = GenericHelper.GetElement(locator, elementName);
            return element.GetAttribute("value");
        }
    }
}

