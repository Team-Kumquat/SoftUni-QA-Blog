using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBuild.Tests.Pages.AccountPage
{
    public static class AccountPageAsserter
    {
        public static void AssertIsLogged(this AccountPage page, string text)
        {
            Assert.AreEqual(text, page.GreatingLink.Text);
        }
    }
}
