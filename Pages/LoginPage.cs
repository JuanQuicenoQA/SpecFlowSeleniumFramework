using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowBDD.PageObject
{
    public class LoginPage
    {
        #region Components

        By tittleLoginPage = By.ClassName("login_logo");
        By userNameField = By.CssSelector("#user-name");
        By passwordField = By.CssSelector("#password");
        By loginButton = By.CssSelector("#login-button");
        By loginErrorMessage = By.XPath("//h3[@data-test='error']");

        #endregion


        #region Actions

        public bool IsLogoCompanyPresent()
        {
            bool visible = true;
            try
            {
                GenericHelper.WaitForElementVisibility(tittleLoginPage, 20, "Company logo");
            }
            catch (Exception e)
            {
                Console.WriteLine("Logo Company is not present because" + e);
                visible = false;
            }
            return visible;
        }

        public void typeInUserFieldIncorrectName()
        {
            TextBoxHelper.TypeInTextBox(userNameField, "Random", "UserName Field Incorrect Name");
        }

        public void typeInUserFieldExpectedName()
        {
            TextBoxHelper.TypeInTextBox(userNameField, "standard_user", "UserName Field Incorrect Name");
        }

        public void typeInPasswordFieldIncorrectPassword()
        {
            TextBoxHelper.TypeInTextBox(passwordField, "RandomPassword", "UserName Field Incorrect Name");
        }

        public void typeInPasswordFieldExpectedPassword()
        {
            TextBoxHelper.TypeInTextBox(passwordField, "secret_sauce", "UserName Field Incorrect Name");
        }

        public string getTextLoginErrorMessage()
        {
            return GenericHelper.GetText(loginErrorMessage, "Error Message Login Page");
        }

        public HomePage clickOnLoginButton()
        {
            ButtonHelper.ClickButton(loginButton, "Login Button Login Page");
            return new HomePage();
        }

        #endregion
    }
}

