using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BlogBuild.Tests.Pages.CreatePostPage
{
    public partial class CreatePostPage : BasePage
    {
        public CreatePostPage(IWebDriver driver) : base(driver)
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
                return base.url + "Article/Create";
            }
        }
      public void LoggingIn()
      {
          var loginPage = new LoginPage.LoginPage(this.Driver);
          var accountPage = new AccountPage.AccountPage(this.Driver);
      
          loginPage.NavigateTo();
          loginPage.Type(loginPage.Email, "abv@abv.bg");
          loginPage.Type(loginPage.Password, "123");
          loginPage.LoginButton.Click();
      
      }
        public void CreateNewPost(string titleOfPost, string contentOfPost)
        {
            var loginPage = new LoginPage.LoginPage(this.Driver);
            var accountPage = new AccountPage.AccountPage(this.Driver);
            var createPostPage = new CreatePostPage(this.Driver);
           //string titleOfPost = "New Important Post";
           //string contentOfPost = "That is new post created";

            loginPage.Login();

            createPostPage.NavigateTo();
            //loginPage.CreateButton.Click();
            createPostPage.Type(createPostPage.Title, titleOfPost);
            createPostPage.Type(createPostPage.Content, contentOfPost);
            createPostPage.CreatelButton.Click();
        }

    }
}
