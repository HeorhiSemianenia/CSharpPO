using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using POMExample.PageObjects;
using System;
using System.Configuration;

namespace POMExample.WrapperFactory
{
    class BrowserFactory
    {
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

        public static void InitBrowser()
        {
            string browserName = ConfigurationManager.ConnectionStrings["browser"].ConnectionString;
            switch (browserName)
            {
                case "Firefox":
                    FirefoxOptions optionsFirefox = new FirefoxOptions();
                    optionsFirefox.AddArguments("--disable-infobars");
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    ChromeOptions optionsChrome = new ChromeOptions();
                    optionsChrome.AddArguments("--disable-infobars");
                    driver = new ChromeDriver();
                    break;
            }
            Page.GetLog().Info("Driver for [" + browserName + "] browser was created");
            driver.Manage().Window.Maximize();
        }

        public static void CloseDriver()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
            Page.GetLog().Info("Driver was closed");
        }
    }
}