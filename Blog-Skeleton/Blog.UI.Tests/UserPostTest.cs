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
using Blog.UI.Tests.Pages.RegistrationPage;

namespace Blog.UI.Tests
{
        [TestFixture]
        public class UserPostTests
        {

            public IWebDriver driver;

            [SetUp]
            public void Init()
            {
                this.driver = new ChromeDriver();

                var logPage = new LoginPage(this.driver);
                User user = AccessExcelData.GetUserTestData("LoginUserSuccessfull");

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
            [Property("CreateUserPost", 6)]
            public void CreateUserPostWithoutTitle()
            {
                var postPage = new PostPage(this.driver);
                Post post = AccessExcelData.GetPostTestData("CreateUserPostWithoutTitle");

                postPage.NavigateTo();
                postPage.FillPostForm(post);

                postPage.AssertErrorMessage("The Title field is required.");
            }


            [Test]
            [Property("CreateUserPost", 6)]
            public void CreateUserPostWithoutContent()
            {
                var postPage = new PostPage(this.driver);
                Post post = AccessExcelData.GetPostTestData("CreateUserPostWithoutContent");

                postPage.NavigateTo();
                postPage.FillPostForm(post);

                postPage.AssertErrorMessage("The Content field is required.");
            }


            [Test]
            [Property("CreateUserPost", 6)]
            public void CreateUserPostSuccessfully()
            {
                var postPage = new PostPage(this.driver);
                Post post = AccessExcelData.GetPostTestData("CreateUserPostSuccessfully");

                postPage.NavigateTo();
                postPage.FillPostForm(post);

                postPage.AssertPostAdded();
            }

            [Test]
            [Property("CreateUserPost", 6)]
            public void CreateUserPostWithLongTitle()
            {
                var postPage = new PostPage(this.driver);
                Post post = AccessExcelData.GetPostTestData("CreateUserPostWithLongTitle");

                postPage.NavigateTo();
                postPage.FillPostForm(post);

                postPage.AssertErrorMessage("The field Title must be a string with a maximum length of 50.");
            }
        }
    }
