using Blog.UI.Tests.Pages.HomePage;
using NUnit.Framework;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class BlogSmokeTests
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
