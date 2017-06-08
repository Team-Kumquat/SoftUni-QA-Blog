using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBuild.Tests.Pages.CreatePostPage
{
    public partial class CreatePostPage
    {
        public IWebElement HeadingExist
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
            }
        }
        public IWebElement Title
        {
            get
            {
                return this.Driver.FindElement(By.Id("Title"));

            }
        }

        public IWebElement Content
        {
            get
            {
                return this.Driver.FindElement(By.Id("Content"));

            }
        }
        public IWebElement CancelButton
        {
            get
            {
                return this.Driver.FindElement(By.LinkText("/Article"));

            }
        }

        public IWebElement CreatelButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));

            }
        }
    }
}
