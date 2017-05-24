using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BlogBuild.Tests.Pages.LoginPage
{
    public partial class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public string  URL
        { get
            {
                return base.url+ "Account/Login";
            }
        }

        public void Login()
        {
            var loginPage = new LoginPage(this.Driver);


            loginPage.NavigateTo();
            loginPage.Type(loginPage.Email, "abv@abv.bg");
            loginPage.Type(loginPage.Password, "123");
            loginPage.LoginButton.Click();
        }
        }
}
