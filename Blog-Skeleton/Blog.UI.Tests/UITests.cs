using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.UI.Tests.Pages.HomePage;

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
    }
}
