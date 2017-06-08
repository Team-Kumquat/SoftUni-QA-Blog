using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using Configuration;
using Blog.UI.Tests.Pages.PostPage;
using Blog.UI.Tests.Models;
using Blog.UI.Tests.Pages.LoginPage;

namespace Blog.UI.Tests
{
    class EditAndDeletePostTest
    {
        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();

            var logPage = new LoginPage(this.driver);
            var postPage = new PostPage(this.driver);
            User user = AccessExcelData.GetUserTestData("LoginAsAdmin");
            Post post = AccessExcelData.GetPostTestData("CreatePostSuccessfully");

            logPage.NavigateTo();
            logPage.FillLoginForm(user);
            postPage.NavigateTo();
            postPage.FillPostForm(post);
        }


        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string filename = ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".txt";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                File.WriteAllText(filename, TestContext.CurrentContext.Test.FullName + "        " + TestContext.CurrentContext.WorkDirectory + "            " + TestContext.CurrentContext.Result.PassCount);

                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                screenshot.SaveAsFile(filename + TestContext.CurrentContext.Test.Name + ".jpg", ScreenshotImageFormat.Jpeg);
            }

            this.driver.Quit();

        }

        [Test]
        [Property("EditPost", 4)]
        public void EditNewPostTitle()
        {
            var postPage = new PostPage(this.driver);
            Post post = AccessExcelData.GetPostTestData("EditNewPostTitle");


            postPage.NavigateToNewPost();
            postPage.EditPost();
            postPage.EditPostTitle(post);
            postPage.EditArticlePost();

            postPage.AssertPostAdded();
        }

        [Test]
        [Property("EditPost", 4)]
        public void EditNewPostContent()
        {
            var postPage = new PostPage(this.driver);
            Post post = AccessExcelData.GetPostTestData("EditNewPostContent");


            postPage.NavigateToNewPost();
            postPage.EditPost();
            postPage.EditPostFormContent(post);
            postPage.EditArticlePost();

            postPage.AssertPostAdded();
        }

        [Test]
        [Property("DeletePost", 5)]
        public void DeletePostSuccessfully()
        {
            var postPage = new PostPage(this.driver);


            postPage.NavigateToNewPost();
            postPage.DeletePost();
            postPage.DeleteArticlePost();



            postPage.AssertPostAdded();
        }
    }
}
