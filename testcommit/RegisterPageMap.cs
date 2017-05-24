using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public partial class RegisterPage
{
    public string  EmailAddress {
        get
        {
            return this.driver.IWebElement(By.XPath("//*[@id=\"Email\"]"));
        }
        ; set; }
	{
	}
}
