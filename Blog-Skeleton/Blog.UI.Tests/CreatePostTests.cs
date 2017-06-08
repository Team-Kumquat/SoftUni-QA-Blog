using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using Configuration;
using Blog.UI.Tests.Pages.PostPage;
using Blog.UI.Tests.Models;
using Blog.UI.Tests.Pages.LoginPage;
using Blog.UI.Tests.Pages.HomePage;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class CreatePostTests
    {

        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();

            var logPage = new LoginPage(this.driver);
            User user = AccessExcelData.GetUserTestData("LoginAsAdmin");

            logPage.NavigateTo();
            logPage.FillLoginForm(user);
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
        [Property("UITest Create Article loaded", 1)]
       
        public void PostPageLoaded()
        {
            var postPage = new PostPage(this.driver);
            postPage.NavigateTo();

            postPage.AssertPostPageIsLoaded("Create Article");
        }

        [Test]
        [Property("CreatePost", 3)]
        public void CreatePostWithoutTitle()
        {
            var postPage = new PostPage(this.driver);
            Post post = AccessExcelData.GetPostTestData("CreatePostWithoutTitle");

            postPage.NavigateTo();
            postPage.FillPostForm(post);

            postPage.AssertErrorMessage("The Title field is required.");
        }


        [Test]
        [Property("CreatePost", 3)]
        public void CreatePostWithoutContent()
        {
            var postPage = new PostPage(this.driver);
            Post post = AccessExcelData.GetPostTestData("CreatePostWithoutContent");

            postPage.NavigateTo();
            postPage.FillPostForm(post);

            postPage.AssertErrorMessage("The Content field is required.");
        }


        [Test]
        [Property("CreatePost", 3)]
        public void CreatePostSuccessfully()
        {
            var postPage = new PostPage(this.driver);
            Post post = AccessExcelData.GetPostTestData("CreatePostSuccessfully");

            postPage.NavigateTo();
            postPage.FillPostForm(post);

            postPage.AssertPostAdded();
        }

        [Test]
        [Property("CreatePost", 3)]
        public void CreatePostWithLongTitle()
        {
            var postPage = new PostPage(this.driver);
            Post post = AccessExcelData.GetPostTestData("CreatePostWithLongTitle");

            postPage.NavigateTo();
            postPage.FillPostForm(post);

            postPage.AssertErrorMessage("The field Title must be a string with a maximum length of 50.");
        }
    }
}
