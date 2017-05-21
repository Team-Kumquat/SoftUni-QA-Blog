using Blog.UI.Tests.Models;
using OpenQA.Selenium;


namespace Blog.UI.Tests.Pages.LoginPage
{
    public partial class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl("http://localhost:60634/Account/Login");
        }

        public void FillLoginForm(User user)
        {
            Type(this.Email, user.Email);
            Type(this.Password, user.Password);
            this.RememberCheckbox.Click();
            this.LoginButton.Click();
        }



        private void Type(IWebElement element, string text)
        {
            element.Clear();

            if (!text.Equals("String.Empty"))
            {
                element.SendKeys(text);
            }
        }
    }
}
