using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBuild.Tests.Pages
{
    public class BasePage
    {


        protected string url = "http://localhost:60634/";
        private IWebDriver driver;
        private WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {

            this.driver = driver;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
        }

        public IWebDriver Driver
        {
            get
            {
                return this.driver;
            }
        }

        public WebDriverWait Wait
        {
            get
            {
                return this.wait;
            }
        }

        public void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }


    }
}
