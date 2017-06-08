using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.UserListPage
{
    public static class UserListPageAsserter
    {
        public static void AssertLogo(this UserListPage page)
        {
            Assert.AreEqual("SOFTUNI BLOG", page.Logo.Text);
        }

        public static void AssertAdminUserIsLogged(this UserListPage page)
        {
            Assert.IsTrue(page.AdminLink.Displayed);
        }
        public static void AssertUserListPageIsLoaded(this UserListPage page, string text)
        {
            Assert.AreEqual(text, page.Heading.Text);
        }

        public static void AssertUserListTableIsDisplayed(this UserListPage page)
        {
            Assert.IsTrue(page.UserListTable.FindElements(By.CssSelector("body > div.container.body - content > div > div > table > tbody tr.info")).Count > 0);
        }



    }
}
