﻿using TestStack.Seleno.Configuration;

namespace Blog.UI.Tests
{
    public static class BrowserHost
    {
        public static readonly SelenoHost Instance = new SelenoHost();
        private static readonly string RootUrl = "http://localhost:60634/Article/List";

        static BrowserHost()
        {
            Instance.Run("Blog", 60639);
            // For Chrome: Instance.Run("Blog", 60634, w => w.WithRemoteWebDriver(BrowserFactory.Chrome));
            // or Instance.Run("Blog", 60634, w => w.WithRemoteWebDriver(() => new ChromeDriver()));

        }
    }
}
