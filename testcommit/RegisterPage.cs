using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Linq;

public partial class RegisterPage : BasePage

{
	public RegisterPage(IWebDriver driver) : base(driver)
	{

	}
    public string URL {
        get
        {
            return base.url + "Account/Register";

        }
            }
}
