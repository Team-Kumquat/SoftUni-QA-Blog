using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.RegistrationPage
{
    public static class RegistrationPageAsserter
    {
        public static void AssertRegistrationPageIsOpen(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.Header.Text);
        }

        public static void AssertSuccessMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.SuccessMessage.Displayed);
            Assert.AreEqual(text, page.SuccessMessage.Text);
        }

        public static void AssertErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessages.Displayed);
            StringAssert.Contains(text, page.ErrorMessages.Text);
        }


        public static void AssertErrorMessageConfPassword(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesComfPassword.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesComfPassword.Text);
        }

        public static void AssertRegisterPageIsLoaded(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.Heading.Text);
        }
    }
}
