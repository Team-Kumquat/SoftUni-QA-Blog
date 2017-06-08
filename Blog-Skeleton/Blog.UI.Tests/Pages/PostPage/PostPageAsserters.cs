using NUnit.Framework;

namespace Blog.UI.Tests.Pages.PostPage
{
    public static class PostPageAsserter
    {
        public static void AssertPostAdded(this PostPage page)
        {
            Assert.IsTrue(page.PostAdded.Displayed);
        }

        public static void AssertErrorMessage(this PostPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessage.Displayed);
            StringAssert.Contains(text, page.ErrorMessage.Text);
        }

        public static void AssertPostPageIsLoaded(this PostPage page, string text)
        {
            Assert.AreEqual(text, page.Heading.Text);
        }

    }
}