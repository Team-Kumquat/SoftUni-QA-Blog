using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.LoginPage
{
    public static class LoginPageAsserter
    {
        public static void AssertSuccessLoginMessage(this LoginPage page, string text)
        {
            Assert.IsTrue(page.SuccessLoginMessage.Displayed);
            Assert.AreEqual(text, page.SuccessLoginMessage.Text);
        }

        public static void AssertSuccessfullLogout(this LoginPage page)
        {
            Assert.IsTrue(page.Login.Displayed);
        }

        public static void AssertErrorMessageForEmail(this LoginPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForEmail.Displayed);
            Assert.AreEqual(text, page.ErrorMessageForEmail.Text);
        }

        public static void AssertErrorMessageEmptyPassword(this LoginPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageEmptyPassword.Displayed);
            Assert.AreEqual(text, page.ErrorMessageEmptyPassword.Text);
        }

        public static void AssertErrorMessageInvalidUser(this LoginPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageInvalidUser.Displayed);
            Assert.AreEqual(text, page.ErrorMessageInvalidUser.Text);
        }

        public static void AssertLoginPageIsLoaded(this LoginPage page, string text)
        {
            Assert.AreEqual(text, page.Heading.Text);
        }

    }
}