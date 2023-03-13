using System.Threading;
using AutomationFramework.Resources;

namespace SeleniumWebdriver.ComponentHelper
{
    public class WindowHelper
    {
        public static string GetTitle()
        {
            return ObjectRepository.Driver.Title;
        }

        public static void SwitchBetweenTabs(int index)
        {
            ObjectRepository.Driver.SwitchTo().Window(ObjectRepository.Driver.WindowHandles[index]);
        }

        public static void ScrollUp()
        {
            //JavaScriptExecutor js = ((JavaScriptExecutor)ObjectRepository.Driver);
            JavaScriptExecutor.ExecuteScript("window.scrollTo(0, -document.body.scrollHeight);");
            Thread.Sleep(2000);
        }
    }
}
