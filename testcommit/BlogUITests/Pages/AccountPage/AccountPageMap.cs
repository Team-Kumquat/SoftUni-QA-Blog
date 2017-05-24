using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBuild.Tests.Pages.AccountPage
{
    public partial class AccountPage
    {
        public IWebElement GreatingLink
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a"));
            }

        }
        public IWebElement FindNewPostTitle
        {
            get
            {
                return this.Driver.FindElement(By.PartialLinkText("New Important Post"));
                
            }
        }
        public IWebElement FindContent
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[10]/article/p"));
            }
                }

    }
}
