using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.DeleteUserPage
{
    public static class DeleteUserPageAssert
    {
        public static void AssertAdminUserIsLogged(this DeleteUserPage page)
        {
            Assert.IsTrue(page.AdminLink.Displayed);
        }
        public static void AssertDeleteUserPageIsLoaded(this DeleteUserPage page, string text)
        {
            Assert.AreEqual(text, page.Heading.Text);
        }

        public static void AssertOKMessage(this DeleteUserPage page, string text)
        {
            Assert.IsTrue(page.OKMessage.Displayed);
        }
    }
}