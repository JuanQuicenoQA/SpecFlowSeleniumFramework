using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowBDD.PageObject
{
    public class HomePage
    {
        #region Components

        By productsTittle = By.XPath("//span[@class='title']");

        #endregion

        #region Actions
        public string getTextProductsTittleHomePage()
        {
            return GenericHelper.GetText(productsTittle, "Text Products Tittle Home Page");
        }

        #endregion
    }
}
