using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using AutomationFramework.Configuration;
using AutomationFramework.Resources;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumWebdriver.ComponentHelper
{
    public class GenericHelper
    {

        public static void Focus()
        {
            ObjectRepository.Driver.SwitchTo().ActiveElement();
        }

        public static void ActiveElement()
        {
            ObjectRepository.Driver.SwitchTo().ActiveElement();
        }

        public static bool IsElementPresent(By Locator)
        {
            try
            {
                return ObjectRepository.Driver.FindElements(Locator).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool isElementEnabled(By Locator)
        {
            try
            {
                return ObjectRepository.Driver.FindElement(Locator).Enabled;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private static Func<IWebDriver, bool> WaitForWebElementFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1 || x.FindElements(locator).Count > 1)
                    return true;
                return false;
            });
        }


        private static Func<IWebDriver, IList<IWebElement>> GetAllElements(By locator)
        {
            return ((x) =>
            {
                return x.FindElements(locator);
            });
        }

        private static Func<IWebDriver, IWebElement> WaitForWebElementInPageFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return x.FindElement(locator);
                return null;
            });
        }

        public static WebDriverWait GetWebdriverWait(TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            return wait;
        }

        public static bool IsElemetPresent(By locator)
        {
            try
            {
                return ObjectRepository.Driver.FindElements(locator).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static IList<IWebElement> GetElements(By locator)
        {
            WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), "Multiple Elements");
            return ObjectRepository.Driver.FindElements(locator);
        }

        public static ReadOnlyCollection<IWebElement> CountElements(By Locator)
        {
            return ObjectRepository.Driver.FindElements(Locator);
        }

        public static IWebElement GetElement(By locator)
        {
            WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), "Single Element");
            if (IsElemetPresent(locator))
                return ObjectRepository.Driver.FindElement(locator);
            else
                throw new NoSuchElementException("Element Not Found : " + locator.ToString());
        }

        public static IWebElement GetElement(By Locator, string elementName)
        {
            try
            {
                return ObjectRepository.Driver.FindElement(Locator);
            }
            catch (Exception)
            {
                throw new NoSuchElementException("The element " + elementName + " doesn't exists: " + Locator.ToString());
            }
        }

        public static MediaEntityModelProvider captureScreenshot(string fileName)
        {
            var screenshot = ((ITakesScreenshot)ObjectRepository.Driver).GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build();
        }

        public static void saveScreenShot(string fileName = "Screen")
        {
            //getting actual directory path
            var directory_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

           // String evidence_path_html = ".\\Evidences\\";
            String full_path = directory_path + @"\Reports\Evidences\";

            //if the directory /evidences/ does NOT exist, then create one.
            if (!Directory.Exists(full_path))
                Directory.CreateDirectory(full_path);

            Screenshot screen = ((ITakesScreenshot)ObjectRepository.Driver).GetScreenshot();
            if (fileName.Equals("Screen"))
            {

                string name = fileName + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";
                screen.SaveAsFile(full_path + name, ScreenshotImageFormat.Png);
            }
            else
            {
                try
                {
                    screen.SaveAsFile(full_path + fileName + ".png", ScreenshotImageFormat.Png);
                }
                catch (Exception e)
                {
                    String[] newName = fileName.Split('"');
                    screen.SaveAsFile(full_path + newName[0] + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png", ScreenshotImageFormat.Png);
                }

            }
        }

        private static Func<IWebDriver, bool> WaitForElementFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return true;
                return false;
            });
        }

        public static bool WaitForWebElement(By locator, TimeSpan timeout, string elementName)
        {
            try
            {
                Thread.Sleep(800);
                ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(ConfigClass.ElementLoadTimeout);
                WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout);
                wait.PollingInterval = TimeSpan.FromMilliseconds(3000);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(InvalidElementStateException), typeof(InvalidOperationException));
                bool flag = wait.Until(WaitForWebElementFunc(locator));
                ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(ConfigClass.ElementLoadTimeout);
                return flag;
            }
            catch (Exception)
            {
                //GenericHelper.TakeScreenShot();
                throw new Exception("The element " + elementName + " is not present: " + locator.ToString());
            }

        }

        public static void WaitForElementVisibility(By locator, int timeout, string elementName)
        {
            try
            {
                new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (TimeoutException)
            {
                throw new TimeoutException("The element " + elementName + " is not visible: " + locator.ToString());
            }
        }

        public static void WaitForElementUntilIsNotPresent(By locator, int timeout, string elementName)
        {
            try
            {
                new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
            }
            catch (TimeoutException)
            {
                throw new TimeoutException("The Element " + elementName + "never gets disapeared ->" + locator.ToString());
            }
        }

        public static void WaitForElementToBeEnable(By locator, int timeout, string elementName)
        {
            try
            {
                new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (Exception)
            {
                throw new TimeoutException("The element " + elementName + " is not clickable: " + locator.ToString());
            }
        }

        public static void WaitForElementLoaded(int timeout)
        {
            new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(timeout));
        }

        public static IWebElement WaitForWebElementInPage(By locator, TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            var wait = GetWebdriverWait(timeout);
            var flag = wait.Until(WaitForWebElementInPageFunc(locator));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout));
            return flag;
        }

        public static IWebElement Wait(Func<IWebDriver, IWebElement> conditions, TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            var wait = GetWebdriverWait(timeout);
            var flag = wait.Until(conditions);
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout));
            return flag;
        }

        public static void PressTabKey()
        {
            Actions action = new Actions(ObjectRepository.Driver);
            action.SendKeys(Keys.Tab).Build().Perform();
        }

        public static void PressUpArrowKey()
        {
            Actions action = new Actions(ObjectRepository.Driver);
            action.SendKeys(Keys.ArrowUp).Build().Perform();
        }

        public static void PressDownArrowKey()
        {
            Actions action = new Actions(ObjectRepository.Driver);
            action.SendKeys(Keys.ArrowDown).Build().Perform();
        }

        public static void PressEnterKey()
        {
            Actions action = new Actions(ObjectRepository.Driver);
            action.SendKeys(Keys.Enter).Build().Perform();
        }

        public static void PressUpKey()
        {
            Actions action = new Actions(ObjectRepository.Driver);
            action.SendKeys(Keys.ArrowUp).Build().Perform();
        }

        public static void PressShiftKey()
        {
            Actions action = new Actions(ObjectRepository.Driver);
            action.SendKeys(Keys.Shift).Build().Perform();
        }

        public static void PressControlKey()
        {
            Actions action = new Actions(ObjectRepository.Driver);
            action.SendKeys(Keys.Control).Build().Perform();
        }

        public static void PressInsertKey()
        {
            Actions action = new Actions(ObjectRepository.Driver);
            action.SendKeys(Keys.Insert).Build().Perform();
        }

        public static void PressSpaceKey(By locator)
        {
            IWebElement element;
            element = GenericHelper.GetElement(locator, nameof(locator));
            element.SendKeys(Keys.Space);
        }

        public static void PressEscapeKey()
        {
            Actions action = new Actions(ObjectRepository.Driver);
            action.SendKeys(Keys.Escape).Build().Perform();
        }

        public static string decryptPassword(string password)
        {
            //To decrypt
            byte[] mybyte = System.Convert.FromBase64String(password);
            string returntext = System.Text.Encoding.UTF8.GetString(mybyte);
            return returntext;
        }

        public static string encryptPassword(string text)
        {
            //To encode
            byte[] mybyte = System.Text.Encoding.UTF8.GetBytes(text);
            string returntext = System.Convert.ToBase64String(mybyte);
            return returntext;
        }

        public static void ChangeTabs(int index)
        {
            IReadOnlyCollection<string> tabs = ObjectRepository.Driver.WindowHandles;
            ObjectRepository.Driver.SwitchTo().Window(tabs.ElementAt(index));
        }

        public static string GetText(By locator, string elementName)
        {
            try
            {
                return ObjectRepository.Driver.FindElement(locator).Text;
            }
            catch (Exception)
            {
                throw new NoSuchElementException("The element " + elementName + " is not present: " + locator.ToString());
            }
        }

        public static void DragAndDrop(By locatorSrc, By locatorTar , string elementName)
        {
            try
            {
                WaitForWebElement(locatorSrc, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
                WaitForWebElement(locatorTar, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
                Actions act = new Actions(ObjectRepository.Driver);
                IWebElement src = GetElement(locatorSrc);
                IWebElement tar = GetElement(locatorTar);
                Thread.Sleep(1000);

                act.DragAndDrop(src, tar)
                    .Build()
                    .Perform();
            }
            catch (Exception)
            {
                throw new NoSuchElementException("The elements " + elementName + " are not present: " + locatorSrc.ToString() + " " + locatorTar.ToString());
            }
        }

        public static void moveMousePointer(By locator, string elementName)
        {
            try
            {
                WaitForWebElement(locator, TimeSpan.FromSeconds(ConfigClass.ElementLoadTimeout), elementName);
                Actions act = new Actions(ObjectRepository.Driver);
                IWebElement studyPermissionAccordion = GetElement(locator);
                act.MoveToElement(studyPermissionAccordion).Perform();
                Thread.Sleep(1000);
            }
            catch (Exception)
            {
                throw new NoSuchElementException("The element " + elementName + " is not present: " + locator.ToString());
            }
        }
    }
}

