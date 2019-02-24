using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using POMExample.PageObjects;
using POMExample.WrapperFactory;
using System;
using System.Configuration;

namespace POMExample.Utils
{
    class WaiterUtil
    {
        public static WebDriverWait driverWait;
        public static int wait;

        public static WebDriverWait СreateWaiterUtil() {
            try
            {
                wait = Int32.Parse(ConfigurationManager.ConnectionStrings["longWait"].ConnectionString);
            }
            catch (FormatException) {
                Page.GetLog().Error("Incorrect Format for ");
            }
            driverWait = new WebDriverWait(BrowserFactory.Driver, TimeSpan.FromSeconds(wait));
            return driverWait;
        }

        public static void ElementVisibleByXpath(String xpath) {
            СreateWaiterUtil().Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        }

        public static void ElementVisibleByCss(String css)
        {
            СreateWaiterUtil().Until(ExpectedConditions.ElementIsVisible(By.CssSelector(css)));
        }

        public static void ElementInvisibleByXpath(String xpath)
        {
            СreateWaiterUtil().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(xpath)));
        }

        public static void ElementInvisibleByCss(String css)
        {
            СreateWaiterUtil().Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(css)));
        }

        public static void ElementIsClicableByXpath(String xpath)
        {
            СreateWaiterUtil().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
        }
    }
}
