using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using Configuration;
using Blog.UI.Tests.Pages.LoginPage;
using Blog.UI.Tests.Models;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class LoginTests
    {

        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();
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
        public void LoginWithoutEmail()
        {
            var logPage = new LoginPage(this.driver);
            User user = AccessExcelData.GetUserTestData("LoginWithoutEmail");

            logPage.NavigateTo();
            logPage.FillLoginForm(user);
           
            logPage.AssertErrorMessageForEmail("The Email field is required.");
        }

        [Test]
        public void LoginWithoutPassword()
        {
            var logPage = new LoginPage(this.driver);
            User user = AccessExcelData.GetUserTestData("LoginWithoutPassword");

            logPage.NavigateTo();
            logPage.FillLoginForm(user);

            logPage.AssertErrorMessageEmptyPassword("The Password field is required.");
        }

        [Test]
        public void LoginWithInvalidUser()
        {
            var logPage = new LoginPage(this.driver);
            User user = AccessExcelData.GetUserTestData("LoginWithInvalidUser");

            logPage.NavigateTo();
            logPage.FillLoginForm(user);

            logPage.AssertErrorMessageInvalidUser("Invalid login attempt.");
        }

        [Test]
        public void LoginWithInvalidEmail()
        {
            var logPage = new LoginPage(this.driver);
            User user = AccessExcelData.GetUserTestData("LoginWithInvalidEmail");

            logPage.NavigateTo();
            logPage.FillLoginForm(user);

            logPage.AssertErrorMessageForEmail("The Email field is not a valid e-mail address.");
        }

        [Test]
        public void SuccessfullLoginAsAdmin()
        {
            var logPage = new LoginPage(this.driver);
            User user = AccessExcelData.GetUserTestData("LoginAsAdmin");

            logPage.NavigateTo();
            logPage.FillLoginForm(user);

            logPage.AssertSuccessLoginMessage("Hello admin@admin.com!");
        }

        [Test]
        public void SuccessfullLogout()
        {
            var logPage = new LoginPage(this.driver);
            User user = AccessExcelData.GetUserTestData("LoginAsAdmin");

            logPage.NavigateTo();
            logPage.FillLoginForm(user);

            logPage.Logout();

            logPage.AssertSuccessfullLogout();
        }

    }
}
