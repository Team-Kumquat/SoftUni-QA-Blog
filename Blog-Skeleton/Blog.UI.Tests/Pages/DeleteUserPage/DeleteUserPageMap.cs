using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.DeleteUserPage
{
    public partial class DeleteUserPage
    {
        public IWebElement Heading
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
            }
        }

        public IWebElement UserName
        {
            get
            {
                return this.Driver.FindElement(By.Id("UserName"));
            }
        }


        public IWebElement FullName
        {
            get
            {
                return this.Driver.FindElement(By.Id("FullName"));
            }
        }

       
        public IWebElement DeleteButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/input"));
            }
        }

        public IWebElement CancelButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/a"));
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
        public IWebElement OKMessage
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));//check if you are at User/List page 'Users'
            }
        }
      
    }
}
