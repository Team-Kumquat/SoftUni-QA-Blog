using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.UI.Tests.Pages.HomePage;
using Blog.UI.Tests.Models;
using Blog.UI.Tests.Pages.RegistrationPage;
using OpenQA.Selenium;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class UITests
    {

        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = BrowserHost.Instance.Application.Browser;
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            
        }

        [Test]
        public void BlogLogoDisplayedRightMessage()
        {
            var homePage = new HomePage(this.driver);

            homePage.NavigateTo();

            homePage.AssertLogo();
        }

        [Test]
        public void RegisterWithoutFullName()
        {
            var regPage = new RegistrationPage(this.driver);
            User user = AccessExcelData.GetUserTestData("RegisterWithoutFullName");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessage("The Full Name field is required.");
        }

        [Test]
        public void RegisterWithoutEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            User user = AccessExcelData.GetUserTestData("RegisterWithoutEmail");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            //if all fields are empty, this test passed!
            regPage.AssertErrorMessage("The Email field is required.");
        }

        [Test]
        public void RegisterWithoutPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            User user = AccessExcelData.GetUserTestData("RegisterWithoutPassword");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessage("The Password field is required.");
        }

        [Test]
        public void RegisterWithoutConfirmPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            User user = AccessExcelData.GetUserTestData("RegisterWithoutConfirmPassword");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageConfPassword("The password and confirmation password do not match.");
        }

        [Test]
        public void PasswordsDontMatch()
        {
            var regPage = new RegistrationPage(this.driver);
            User user = AccessExcelData.GetUserTestData("PasswordsDontMatch");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessage("The password and confirmation password do not match.");
        }

        [Test]
        public void RegisterWithInvalidEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            User user = AccessExcelData.GetUserTestData("RegisterWithInvalidEmail");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessage("The Email field is not a valid e-mail address.");
        }

        //change the email in the excell file into DataDrivenTests folder
        [Test]
        public void RegisterWithFullNameWithNumbers()
        {
            var regPage = new RegistrationPage(this.driver);
            User user = AccessExcelData.GetUserTestData("RegisterWithFullNameWithNumbers");
        
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
        
            regPage.AssertSuccessMessage("Hello " + user.Email + "!");
        }

        //change the email in the excell file into DataDrivenTests folder
        [Test]
        public void RegisterSuccessfull()
        {
            var regPage = new RegistrationPage(this.driver);
            User user = AccessExcelData.GetUserTestData("RegisterSuccessfull");
        
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
        
            regPage.AssertSuccessMessage("Hello "+ user.Email + "!");
        }

        [Test]
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
