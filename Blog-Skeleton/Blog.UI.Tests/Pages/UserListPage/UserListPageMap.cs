using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.UserListPage
{
    public partial class UserListPage
    {
        public IWebElement Heading
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
            }
        }

        public IWebElement Logo
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a")));
            }
        }

        public IWebElement AdminLink
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.XPath("//*[@id='logoutForm']/ul/li[1]/a")));
            }
        }
        public IWebElement UserListTable
        {
            get {
                return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/div/table/tbody")));
            }
        }

      

        public IWebElement GreatingLink
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a"));
            }

        }

       
    }
}
