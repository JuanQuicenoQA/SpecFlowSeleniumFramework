using System;
using AutomationFramework.Configuration;
using OpenQA.Selenium;

namespace SeleniumWebdriver.ComponentHelper
{
    public class RadioButtonHelper
    {
        private static IWebElement element;

        public static void SelectRadioButton(By locator, string elementName)
        {
            GenericHelper.WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
            element = GenericHelper.GetElement(locator, elementName);
            element.Click();
        }

        public static bool IsRadioButtonSelected(By locator, string elementName)
        {
            GenericHelper.WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
            element = GenericHelper.GetElement(locator, elementName);
            //GetAttribute permite obtener el valor de cualquier atributo en un etiqueta HTML
            string flag = element.GetAttribute("checked");

            if (flag == null)
            {
                return false;
            }
            else
            {
                return flag.Equals("true") || flag.Equals("checked");
            }
        }

    }
}
