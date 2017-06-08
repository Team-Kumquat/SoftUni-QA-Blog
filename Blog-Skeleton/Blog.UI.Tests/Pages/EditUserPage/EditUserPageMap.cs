using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace Blog.UI.Tests.Pages.UserEditPage
{
    public partial class EditUserPage
    {
        public IWebElement Heading
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
            }
        }

        public IWebElement FullName
        {
            get
            {
                return this.Driver.FindElement(By.Id("User_FullName"));
            }
        }


        public IWebElement Email
        {
            get
            {
                return this.Driver.FindElement(By.Id("User_Email"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.Driver.FindElement(By.Id("Password"));
            }
        }

        public IWebElement ConfirmPassword
        {
            get
            {
                return this.Driver.FindElement(By.Id("ConfirmPassword"));
            }
        }

        public IWebElement IsAdminRole
        {
            get
            {
                return this.Driver.FindElement(By.Id("Roles_0__IsSelected"));
            }
        }


        public IWebElement IsUserRole
        {
            get
            {
                return this.Driver.FindElement(By.Id("Roles_1__IsSelected"));
            }
        }


        public IWebElement EditButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/input"));
            }
        }

        public IWebElement AdminLink
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.XPath("//*[@id='logoutForm']/ul/li[1]/a")));
            }
        }

        public IWebElement GreatingLink
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a"));
            }

        }

        public IWebElement SuccessMessage
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));//check if you are at User/List page
            }
        }      

        public IWebElement ErrorMessagesComfPassword
        {
            get
            {                                                        
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/div/ul/li")));
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/ul/li"));
            }
        }
    }
}
