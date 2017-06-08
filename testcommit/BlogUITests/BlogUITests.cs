using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace BlogUITests
{
    [TestFixture]
    public class BlogUITests
{



        [Test]
        [Property("Smoke test",1)]
        [Author("Rossen Dimov")]
        public void CheckSiteLoad()
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            driver.Navigate().GoToUrl(@"http://localhost:60634/Article/List");

            var logo = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a"));
            Assert.AreEqual("SOFTUNI BLOG", logo.Text);
            driver.Close();
        }
    }
}
