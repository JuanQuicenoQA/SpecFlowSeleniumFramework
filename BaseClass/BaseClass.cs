using System;
using AutomationFramework.Configuration;
using AutomationFramework.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SeleniumWebdriver.ComponentHelper;

namespace AutomationFramework.BaseClasses
{
    [TestClass]

    public class BaseClass
    {
        private static FirefoxOptions GetFirefoxOptions()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("start-maximized");
            return options;
        }

        private static EdgeOptions GetEdgeOptions()
        {
            EdgeOptions options = new EdgeOptions();
            options.AddArgument("start-maximized");
            return options;
        }

        [Obsolete]
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            //option.AddArgument("--headless");
            return option;
        }

        private static FirefoxOptions GetOptions()
        {
            FirefoxProfileManager manager = new FirefoxProfileManager();

            FirefoxOptions options = new FirefoxOptions()
            {
                Profile = manager.GetProfile("default"),
                AcceptInsecureCertificates = true,
            };
            return options;
        }


        private static FirefoxDriver GetFirefoxDriver()
        {
            FirefoxDriver driver = new FirefoxDriver(GetFirefoxOptions());
            return driver;
        }

        private static EdgeDriver GetEdgeDriver()
        {
            EdgeDriver driver = new EdgeDriver(GetEdgeOptions());
            return driver;
        }

        [Obsolete]
        private static ChromeDriver GetChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        [Obsolete]
        public void StartNavigation()
        {
            switch (ConfigClass.browser)
            {
                case "Firefox":
                    ObjectRepository.Driver = GetFirefoxDriver();
                    break;

                case "Chrome":
                    ObjectRepository.Driver = GetChromeDriver();
                    break;

                case "Edge":
                    ObjectRepository.Driver = GetEdgeDriver();
                    break;

                default:
                    throw new NotFoundException("The webdriver is not available");
            }

            //Se define el tiempo de espera maximo para la carga de la pagina
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ConfigClass.PageLoadTimeout);
            //Se define el tiempo de espera maximo para la carga de algun control
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigClass.PageLoadTimeout);
            //Navigate to the page
            NavigationHelper.NavigateToUrl(ConfigClass.website);
            //BrowserHelper.Maximize();
        }

        public void CleanUp()
        {
            if (ObjectRepository.Driver != null)
            {
                //closing windows and driver service
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }
        }
    }
}
