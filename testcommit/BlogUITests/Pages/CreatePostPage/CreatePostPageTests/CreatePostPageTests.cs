using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBuild.Tests.Pages.CreatePostPage.CreatePostPageTests
{
    [TestFixture]

    class CreatePostPageTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            //this.driver = new InternetExplorerDriver();
            this.driver = new ChromeDriver();
        }
        [TearDown]
        public void CleanUp()
        {
            this.driver.Quit();
        }


        


    }
}
