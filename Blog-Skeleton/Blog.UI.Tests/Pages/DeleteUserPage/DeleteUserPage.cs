using Blog.UI.Tests.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.DeleteUserPage
{
    public partial class DeleteUserPage : BasePage
    {
        public DeleteUserPage(IWebDriver driver)
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
                return base.url + "User/Delete/" + UserGuid;//add user id from Excel
            }
        }
        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void DeleteUser()
        {
            this.DeleteButton.Click();
        }

        public void CancelDeleteUser()
        {
            this.CancelButton.Click();
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
