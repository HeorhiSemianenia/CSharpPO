/*
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;

namespace POMExample.WrapperFactory
{
    class BrowserFactoryDictionary
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (driver == null)
                    {
                        driver = new FirefoxDriver();
                        Drivers.Add("Firefox", Driver);
                    }
                    break;

                case "Chrome":
                    if (driver == null)
                    {
                        driver = new ChromeDriver();
                        Drivers.Add("Chrome", driver);
                    }
                    break;
            }
            driver.Manage().Window.Maximize();
        }

        public static void LoadApplication(string url)
        {
            Driver.Url = url;
        }

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
                Drivers[key].Dispose();
            }
            driver = null;
            Drivers.Clear();
        }
    }
}
*/