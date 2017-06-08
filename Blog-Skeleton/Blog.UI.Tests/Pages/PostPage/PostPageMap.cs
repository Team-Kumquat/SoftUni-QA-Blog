using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Blog.UI.Tests.Pages.PostPage
{
    public partial class PostPage
    {
        public IWebElement Heading
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

        public IWebElement CreatePostButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
            }
        }

        public IWebElement EditButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[1]"));
            }
        }

        public IWebElement EditArticleButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
            }
        }

        public IWebElement DeleteButton
        {
            get
            {               
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[2]"));
            }
        }

        public IWebElement DeleteArticleButton
        {
            get
            {
               
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/input"));
            }
        }

        public IWebElement NewPost
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[4]/article/header/h2/a"));
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
