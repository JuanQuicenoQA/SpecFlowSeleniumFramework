using System;
using AutomationFramework.Configuration;
using OpenQA.Selenium;

namespace SeleniumWebdriver.ComponentHelper
{
    public class CheckBoxHelper
    {
        private static IWebElement element;

        public static void SelectCheckBox(By locator, string elementName)
        {
            GenericHelper.WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
            element = GenericHelper.GetElement(locator, elementName);
            element.Click();
        }

        //Metodo que permite verificar si un checkbox está seleccionado o no
        public static bool IsCheckBoxChecked(By locator, string elementName)
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

