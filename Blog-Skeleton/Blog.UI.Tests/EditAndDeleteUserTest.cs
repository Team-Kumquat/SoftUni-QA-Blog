using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using Configuration;
using Blog.UI.Tests.Pages.PostPage;
using Blog.UI.Tests.Models;
using Blog.UI.Tests.Pages.LoginPage;
using Blog.UI.Tests.Pages.UserEditPage;
using Blog.UI.Tests.Pages.UserListPage;
using Blog.UI.Tests.Pages.DeleteUserPage;
using Blog.UI.Tests.Pages.RegistrationPage;
using Blog.UI.Tests.Pages.HomePage;
using System;

namespace Blog.UI.Tests
{
    class EditAndDeleteUserTest
    {
        public IWebDriver driver;
        private string _userGuid;
        [SetUp]
        public void Init()
        {
            var separateRegOfTestUserDriver = new ChromeDriver();
            var random = new System.Random(100);
            var testUser = new User
            {
                FullName = "For deletition",
                Email = string.Format("{0}@test.bg", System.Guid.NewGuid().ToString().Substring(0, 5)),
                Password = "123",
                ConfirmPassword = "123",
                IsAdmin = false,
                IsUser = true
            };
            var registerPage = new RegistrationPage(separateRegOfTestUserDriver);
            registerPage.NavigateTo();
            registerPage.FillRegistrationForm(testUser);
            separateRegOfTestUserDriver.Close();


            this.driver = new ChromeDriver();
            var logPage = new LoginPage(this.driver);

            User user = AccessExcelData.GetUserTestData("LoginAsAdmin");

            logPage.NavigateTo();
            logPage.FillLoginForm(user);

            var userList = new UserListPage(this.driver);
            userList.NavigateTo();
            _userGuid = userList.GetUserGuid();
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
        [Property("UITest User List loaded", 1)]

        public void UserListPageLoaded()
        {
            var userListPage = new UserListPage(this.driver);
            userListPage.NavigateTo();

            userListPage.AssertUserListPageIsLoaded("Users");
        }

        [Test]
        [Property("UITest Edit User loaded", 1)]

        public void UserEditPageLoaded()
        {
            var userEditPage = new EditUserPage(this.driver);

            userEditPage.UserGuid = _userGuid;
            userEditPage.NavigateTo();

            userEditPage.AssertUserEditPageIsLoaded("Edit User");
        }

        [Test]
        [Property("UITest Delete User loaded", 1)]

        public void UserDeletePageLoaded()
        {
            var userDeletePage = new DeleteUserPage(this.driver);

            userDeletePage.UserGuid = _userGuid;
            userDeletePage.NavigateTo();

            userDeletePage.AssertDeleteUserPageIsLoaded("Delete User");
        }

        [Test]
        [Property("EditUser", 4)]
        public void EditUserEmail()
        {
            var editPage = new EditUserPage(this.driver);
            editPage.UserGuid = _userGuid;

            editPage.NavigateTo();

            User user = new User
            {
                FullName = editPage.FullName.GetAttribute("value"),
                Password = "123",
                ConfirmPassword = "123",
                Email = "new" + editPage.Email.GetAttribute("value"),
                IsUser = Convert.ToBoolean(editPage.IsUserRole.GetAttribute("value")),
                IsAdmin = Convert.ToBoolean(editPage.IsAdminRole.GetAttribute("value"))
            };

            editPage.FillEditUserForm(user);

            editPage.AssertSuccessMessage("Users");
        }

        [Test]
        [Property("EditUser", 4)]
        public void EditUserRole()
        {
            var editPage = new EditUserPage(this.driver);

            editPage.UserGuid = _userGuid;
            editPage.NavigateTo();

            User user = new User
            {
                FullName = editPage.FullName.GetAttribute("value"),
                Password = "123",
                ConfirmPassword = "123",
                Email = editPage.Email.GetAttribute("value"),
                IsUser = Convert.ToBoolean(editPage.IsUserRole.GetAttribute("value")),
                IsAdmin = !Convert.ToBoolean(editPage.IsAdminRole.GetAttribute("value"))
            };

            editPage.FillEditUserForm(user);

            editPage.AssertSuccessMessage("Users");
        }

        [Test]
        [Property("EditUser", 4)]
        public void EditUserPassword()
        {
            var editPage = new EditUserPage(this.driver);
            editPage.UserGuid = _userGuid;
            editPage.NavigateTo();

            User user = new User
            {
                FullName = editPage.FullName.GetAttribute("value"),
                Email = editPage.Email.GetAttribute("value"),
                Password = "123changed",
                ConfirmPassword = "123changed",               
                IsUser = Convert.ToBoolean(editPage.IsUserRole.GetAttribute("value")),
                IsAdmin = Convert.ToBoolean(editPage.IsAdminRole.GetAttribute("value"))
            };

            editPage.FillEditUserForm(user);

            editPage.AssertSuccessMessage("Users");
        }

        [Test]
        [Property("DeleteUser", 5)]
        public void DeleteUser()
        {

            var deletePage = new DeleteUserPage(this.driver);
            //var userList = new UserListPage(this.driver);
            //userList.NavigateTo();
            //var userguid = userList.GetUserGuid();

            deletePage.UserGuid = _userGuid;

            deletePage.NavigateTo();
            deletePage.DeleteButton.Click();

            deletePage.AssertOKMessage("Users");
        }
    }
}
