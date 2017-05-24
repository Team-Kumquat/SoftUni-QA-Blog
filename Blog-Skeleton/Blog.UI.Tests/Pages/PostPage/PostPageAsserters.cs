using NUnit.Framework;

namespace Blog.UI.Tests.Pages.PostPage
{
    public static class PostPageAsserter
    {
        public static void AssertPostAdded(this PostPage page, string text)
        {
            Assert.IsTrue(page.PostAdded.Displayed);
            Assert.AreEqual(text, page.PostAdded.Text);
        }

        public static void AssertErrorMessage(this PostPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessage.Displayed);
            StringAssert.Contains(text, page.ErrorMessage.Text);
        }

    }
}