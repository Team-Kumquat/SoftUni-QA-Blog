using Blog.UI.Tests.Models;
using OpenQA.Selenium;


namespace Blog.UI.Tests.Pages.PostPage
{
    public partial class PostPage : BasePage
    {
        public PostPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl("http://localhost:60634/Article/Create");
        }

        public void FillPostForm(Post post)
        {
            Type(this.Title, post.Title);
            Type(this.Content, post.Content);
            this.CreatePostButton.Click();
        }

        public void DeletePost()
        {
            this.DeleteButton.Click();
        }

        public void DeleteArticlePost()
        {
            DeleteArticleButton.Click();
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();

            if (!text.Equals("String.Empty"))
            {
                element.SendKeys(text);
            }
        }

        public void NavigateToNewPost()
        {
            NewPost.Click();
        }
    }
}
