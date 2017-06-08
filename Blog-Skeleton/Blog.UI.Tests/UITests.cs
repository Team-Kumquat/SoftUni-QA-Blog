using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.UI.Tests.Pages.HomePage;
using Blog.UI.Tests.Models;
using Blog.UI.Tests.Pages.RegistrationPage;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class UITests
    {
        [Test]
        public void BlogLogoDisplayedRightMessage()
        {
            var homePage = new HomePage(BrowserHost.Instance.Application.Browser);

            homePage.NavigateTo();

            homePage.AssertLogo();
        }

        [Test]
        public void RegisterWithoutEmail()
        {
            var regPage = new RegistrationPage(BrowserHost.Instance.Application.Browser);
            User user = AccessExcelData.GetUserTestData("RegisterWithoutEmail");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessage("The Email field is required.");
        }

        [Test]
        public void RegisterWithoutConfirmPassword()
        {
            var regPage = new RegistrationPage(BrowserHost.Instance.Application.Browser);
            User user = AccessExcelData.GetUserTestData("RegisterWithoutConfirmPassword");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageConfPassword("The password and confirmation password do not match.");
        }
    }
}
