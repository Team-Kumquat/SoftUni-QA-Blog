using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.UserListPage
{
    public partial class UserListPage : BasePage
    {
        // private IWebDriver driver;
        private WebDriverWait wait;
        // private string url = @"http://localhost:60634/Article/List";

        public UserListPage(IWebDriver driver) : base(driver)
        {
            // this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        public string URL
        {
            get
            {
                return base.url + "User/List";
            }
        }


        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        //get the non-superadmin, non-first id
        public string GetUserGuid()
        {
            return this.Driver.FindElement(By.CssSelector("body > div.container.body-content > div > div > table > tbody > tr:nth-child(2) > td:nth-child(1)")).Text;
        }

    }
}
