using System;
using AutomationFramework.Resources;
using OpenQA.Selenium;

namespace SeleniumWebdriver.ComponentHelper
{
    public class JavaScriptPopHelper
    {
        public static bool IsPopupPresent()
        {
            try
            {
                ObjectRepository.Driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public static string GetPopUpText()
        {
            if (!IsPopupPresent())
                return String.Empty;
            return ObjectRepository.Driver.SwitchTo().Alert().Text;
        }

        public static void ClickOkOnPopup()
        {
            if (!IsPopupPresent())
                return;
            ObjectRepository.Driver.SwitchTo().Alert().Accept();
        }

        public static void ClickCancelOnPopup()
        {
            if (!IsPopupPresent())
                return;
            ObjectRepository.Driver.SwitchTo().Alert().Dismiss();
        }

        public static void SendKeys(string text)
        {
            if (!IsPopupPresent())
                return;
            ObjectRepository.Driver.SwitchTo().Alert().SendKeys(text);
        }
    }
}
