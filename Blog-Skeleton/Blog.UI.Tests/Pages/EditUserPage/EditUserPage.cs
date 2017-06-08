using Blog.UI.Tests.Models;
using OpenQA.Selenium;


namespace Blog.UI.Tests.Pages.UserEditPage
{
    public partial class EditUserPage : BasePage
    {
        public EditUserPage(IWebDriver driver)
            : base(driver)
        {
        }

        private string _userGuid = System.Guid.NewGuid().ToString();

        public string UserGuid
        {
            get { return this._userGuid; }
            set { this._userGuid = value; }
        }
        public string URL
        {
            get
            {
                return base.url + "User/Edit/" + UserGuid;//add user id from Excel
            }
        }
        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void FillEditUserForm(User user)
        {
            Type(this.Email, user.Email);
            Type(this.FullName, user.FullName);
            Type(this.Password, user.Password);
            Type(this.ConfirmPassword, user.ConfirmPassword);
            if (user.IsAdmin)
                this.IsAdminRole.Click();
            if (user.IsUser)
                this.IsUserRole.Click();
           
            this.EditButton.Click();
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
