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
        public string URL
        {
            get
            {
                return base.url + "Article/Create";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void FillPostForm(Post post)
        {
            Type(this.Title, post.Title);
            Type(this.Content, post.Content);
            this.CreatePostButton.Click();
        }

        public void EditPostTitle(Post post)
        {
            Type(this.Title, post.Title);
        }

        public void EditPostFormContent(Post post)
        {
            Type(this.Content, post.Content);
        }

        public void EditPost()
        {
            this.EditButton.Click();
        }

        public void EditArticlePost()
        {
            EditArticleButton.Click();
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
