using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.UserEditPage
{
    public static class EditUserPageAsserter
    {
        public static void AssertUserEditPageIsLoaded(this EditUserPage page, string text)
        {
            Assert.AreEqual(text, page.Heading.Text);
        }

        public static void AssertAdminIsEditing(this EditUserPage page)
        {
            Assert.IsTrue(page.AdminLink.Displayed);
        }

        public static void AssertSuccessMessage(this EditUserPage page, string text)
        {
            Assert.IsTrue(page.SuccessMessage.Displayed);
            Assert.AreEqual(text, page.SuccessMessage.Text);
        }

        public static void AssertErrorMessageConfPassword(this EditUserPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesComfPassword.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesComfPassword.Text);
        }

        //no implementation of cases both check-boxes are unchecked actually
        public static void AssertUserIsInrole(this EditUserPage page, string text)
        {
            Assert.IsTrue(page.IsAdminRole.Selected || page.IsUserRole.Selected);
            Assert.AreEqual(text, page.SuccessMessage.Text);
        }

        //no error message if the e-mail is deleted actually
        public static void AssertErrorMessageForEmail(this EditUserPage page, string text)
        {
            Assert.IsFalse(page.SuccessMessage.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesComfPassword.Text);
        }

    }
}
