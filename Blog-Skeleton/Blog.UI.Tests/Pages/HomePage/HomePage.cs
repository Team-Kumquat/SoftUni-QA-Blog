using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.HomePage
{
    public partial class HomePage : BasePage
    {
        //private IWebDriver driver;
        private WebDriverWait wait;
        // private string url = @"http://localhost:60634/Article/List";

        public HomePage(IWebDriver driver) : base(driver)
        {
            // this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        public string URL
        {
            get
            {
                return base.url + "Article/List";
            }
        }

        //public IWebDriver Driver
        //{
        //    get
        //    {
        //        return this.driver;
        //    }
        //}

        //public WebDriverWait Wait
        //{
        //    get
        //    {
        //        return this.wait;
        //    }
        //}

        //public string URL
        //{
        //    get
        //    {
        //        return this.url;
        //    }
        //}

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }
    }
}
