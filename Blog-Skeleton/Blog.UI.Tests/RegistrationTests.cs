using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using Configuration;
using Blog.UI.Tests.Pages.RegistrationPage;
using Blog.UI.Tests.Models;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class RegistrationTests
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
        [Property("UITest Register loaded", 1)]      

        public void RegistrationPageLoaded()
        {
            var registrationPage = new RegistrationPage(this.driver);
            registrationPage.NavigateTo();

            registrationPage.AssertRegisterPageIsLoaded("Register");
        }

        [Test]
        [Property("Register", 1)]
        public void RegisterWithoutFullName()
        {
            var regPage = new RegistrationPage(this.driver);
            User user = AccessExcelData.GetUserTestData("RegisterWithoutFullName");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
           
            regPage.AssertErrorMessage("The Full Name field is required.");
        }

        [Test]
        [Property("Register", 1)]
        public void RegisterWithoutEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            User user = AccessExcelData.GetUserTestData("RegisterWithoutEmail");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessage("The Email field is required.");
        }

        //[Test]
        //[Property("Register", 1)]
        //public void RegisterWithoutPassword()
        //{
        //    var regPage = new RegistrationPage(this.driver);
        //    User user = AccessExcelData.GetUserTestData("RegisterWithoutPassword");

        //    regPage.NavigateTo();
        //    regPage.FillRegistrationForm(user);

        //    regPage.AssertErrorMessage("The Password field is required.");
        //}

        [Test]
        [Property("Register", 1)]
        public void RegisterWithoutConfirmPassword()
       {
           var regPage = new RegistrationPage(this.driver);
           User user = AccessExcelData.GetUserTestData("RegisterWithoutConfirmPassword");

           regPage.NavigateTo();
           regPage.FillRegistrationForm(user);

           regPage.AssertErrorMessageConfPassword("The password and confirmation password do not match.");
       }


        [Test]
        [Property("Register", 1)]
        public void PasswordsDontMatch()
        {
            var regPage = new RegistrationPage(this.driver);
            User user = AccessExcelData.GetUserTestData("PasswordsDontMatch");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessage("The password and confirmation password do not match.");
        }

        [Test]
        [Property("Register", 1)]
        public void RegisterWithInvalidEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            User user = AccessExcelData.GetUserTestData("RegisterWithInvalidEmail");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessage("The Email field is not a valid e-mail address.");
        }

        //[Test]
        //[Property("Register", 1)]
        //public void RegisterWithFullNameWithNumbers()
        //{
        //    var regPage = new RegistrationPage(this.driver);
        //    User user = AccessExcelData.GetUserTestData("RegisterWithFullNameWithNumbers");
        //
        //    regPage.NavigateTo();
        //    regPage.FillRegistrationForm(user);
        //
        //    regPage.AssertSuccessMessage("Hello 123@abv.bg!");
        //}
        //
        //[Test]
        //[Property("Register", 1)]
        //public void RegisterSuccessfull()
        //{
        //    var regPage = new RegistrationPage(this.driver);
        //    User user = AccessExcelData.GetUserTestData("RegisterSuccessfull");
        //
        //    regPage.NavigateTo();
        //    regPage.FillRegistrationForm(user);
        //
        //    regPage.AssertSuccessMessage("Hello cvety@abv.bg!");
        //}

        [Test]
        [Property("Register", 1)]
        public void RegisterWithLongFullName()
        {
            var regPage = new RegistrationPage(this.driver);
            User user = AccessExcelData.GetUserTestData("RegisterWithLongFullName");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessage("The field Full Name must be a string with a maximum length of 50.");
        }
    }
}
