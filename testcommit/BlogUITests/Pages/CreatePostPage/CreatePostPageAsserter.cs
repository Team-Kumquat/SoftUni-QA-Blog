using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBuild.Tests.Pages.CreatePostPage
{
    public static class CreatePostPageAsserter
    {
        public static void AsserterForTitleOfNewPost(this AccountPage.AccountPage page, string text)
        {

            Assert.AreEqual(text, page.FindNewPostTitle);
        }
        public static void AsserterForContentOfNewPost(this AccountPage.AccountPage page, string text)
        {

            Assert.AreEqual(text, page.FindContent);
        }
       public static void AsserterForMissingElement(string e)
       {
            Assert.AreEqual("NoSuchElementException", e);
        }
    }
}
