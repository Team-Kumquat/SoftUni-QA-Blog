using BlogBuild.Tests.Pages.AccountPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBuild.Tests.Pages.LoginPage.LoginPageTests
{
    [TestFixture]
    class LoginPageTests
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
        [Property ("UITest Login loaded",1)]
        [Author("Rossen Dimov")]

        public void LoginPageLoaded()
        {
            var loginPage = new LoginPage(this.driver);

            loginPage.NavigateTo();

            loginPage.AssertLoginPageLoaded("Log in");
        }

        [Test]
        [Property ("User Is Logged In",1)]
        [Author("Rossen Dimov")]
        public void TryToLoggingIn()
        {
            var loginPage = new LoginPage(this.driver);
            var accountPage = new AccountPage.AccountPage(this.driver);

            loginPage.Login();
            accountPage.NavigateTo();
            accountPage.AssertIsLogged("Hello abv@abv.bg!");
        }
    }
}
