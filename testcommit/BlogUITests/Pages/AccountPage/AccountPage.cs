using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace BlogBuild.Tests.Pages.AccountPage
{
    public partial class AccountPage : BasePage
    {
        public AccountPage(IWebDriver driver) : base(driver)
        {
        }
        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public string URL
        {
            get
            {
                return base.url + "Article/List";
            }
        }
        
    }
}
