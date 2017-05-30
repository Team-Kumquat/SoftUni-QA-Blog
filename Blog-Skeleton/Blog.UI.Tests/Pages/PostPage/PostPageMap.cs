using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Blog.UI.Tests.Pages.PostPage
{
    public partial class PostPage
    {

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



        public IWebElement CreatePostButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
            }
        }

        public IWebElement PostAdded
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("container"));
            }
        }

        public IWebElement ErrorMessage
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")));
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }
    }
}
