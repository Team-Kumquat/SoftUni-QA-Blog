using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace Blog.UI.Tests.Pages.LoginPage
{
    public partial class LoginPage
    {
       
        public IWebElement Email
        {
            get
            {
                return this.Driver.FindElement(By.Id("Email"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.Driver.FindElement(By.Id("Password"));
            }
        }


        public IWebElement RememberCheckbox
        {
            get
            {
                return this.Driver.FindElement(By.Id("RememberMe"));
            }
        }



        public IWebElement LoginButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
            }
        }

        public IWebElement Login
        {
            get
            {
                return this.Driver.FindElement(By.Id("loginLink"));
            }
        }

        public IWebElement LogoutButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[4]/a"));
            }
        }

        public IWebElement Heading
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
            }
        }

        public IWebElement SuccessLoginMessage
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[3]/a"));
            }
        }

        public IWebElement ErrorMessageForEmail
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/div/span/span")));
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/div/span/span"));
            }
        }

        public IWebElement ErrorMessageEmptyPassword
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[2]/div/span/span")));
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[2]/div/span/span"));
            }
        }

        public IWebElement ErrorMessageInvalidUser
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")));
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

    }
}
