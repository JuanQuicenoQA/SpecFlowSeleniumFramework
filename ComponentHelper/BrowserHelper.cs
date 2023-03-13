using System.Collections.ObjectModel;
using System.Threading;
using AutomationFramework.Resources;
using OpenQA.Selenium;

namespace SeleniumWebdriver.ComponentHelper
{
    public class BrowserHelper
    {
        public static void BrowserMaximize()
        {
            ObjectRepository.Driver.Manage().Window.Maximize();
        }

        public static void Maximize()
        {
            ObjectRepository.Driver.Manage().Window.Maximize();
        }

        public static void GoBack()
        {
            ObjectRepository.Driver.Navigate().Back();

        }

        public static void Forward()
        {
            ObjectRepository.Driver.Navigate().Forward();
        }

        public static void RefreshPage()
        {
            ObjectRepository.Driver.Navigate().Refresh();
        }

        public static void SwitchToWindow(int index = 0)
        {
            ReadOnlyCollection<string> windows = ObjectRepository.Driver.WindowHandles;

            if ((windows.Count - 1) < index)
            {
                throw new NoSuchWindowException("Invalid Browser Window Index" + index);
            }


            ObjectRepository.Driver.SwitchTo().Window(windows[index]);
            BrowserMaximize();

        }

        public static void SwitchToParent()
        {
            var windowids = ObjectRepository.Driver.WindowHandles;


            for (int i = windowids.Count - 1; i > 0;)
            {
                ObjectRepository.Driver.Close();
                i = i - 1;
                Thread.Sleep(2000);
                ObjectRepository.Driver.SwitchTo().Window(windowids[i]);
            }
            ObjectRepository.Driver.SwitchTo().Window(windowids[0]);

        }

        public static void SwitchToFrame(By locatot)
        {
            ObjectRepository.Driver.SwitchTo().Frame(ObjectRepository.Driver.FindElement(locatot));
        }
    }
}
