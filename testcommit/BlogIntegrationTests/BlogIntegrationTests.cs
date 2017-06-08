using BlogBuild.Tests.Pages.AccountPage;
using BlogBuild.Tests.Pages.CreatePostPage;
using BlogBuild.Tests.Pages.LoginPage;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests

{

    [TestFixture]
    public class BlogIntegrationTests
    {
        private IWebDriver driver;

        [SetUp]

        public void Init()
        {
            //this.driver = new InternetExplorerDriver();
            this.driver = new ChromeDriver();
        }
        [TearDown]
        public void CleanUp()
        {
            this.driver.Quit();
        }

        [Test]
        [Property("Integration Test", 1)]
        [Author("Rossen Dimov")]

        public void CreateNewPost()
        {
            var loginPage = new LoginPage(this.driver);
            var accountPage = new AccountPage(this.driver);
            var createPostPage = new CreatePostPage(this.driver);
            string titleOfPost = "New Important Post";
            string contentOfPost = "That is new post created";

            loginPage.Login();

            createPostPage.NavigateTo();
            createPostPage.CreateNewPost(titleOfPost, contentOfPost);
            Assert.AreEqual(titleOfPost, accountPage.FindNewPostTitle.Text);

        }

        [Test]
        [Property("Integration Test", 1)]
        [Author("Rossen Dimov")]
        public void DeletePost()
        {
            var loginPage = new LoginPage(this.driver);
            var accountPage = new AccountPage(this.driver);
            accountPage.NavigateTo();
          //  string newPostLink = accountPage.FindNewPostTitle.Text;
            try
            {
                loginPage.Login();
                
                accountPage.FindNewPostTitle.Click();
                this.driver.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[2]")).Click();
                this.driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/input")).Click();
                if(accountPage.FindNewPostTitle.Text == null)
                {
                    CreatePostPageAsserter.AsserterForMissingElement("NoSuchElementException");
                }
            }
            catch (NoSuchElementException )
            {
                CreatePostPageAsserter.AsserterForMissingElement("NoSuchElementException");
                
            }







        }
    }
}
