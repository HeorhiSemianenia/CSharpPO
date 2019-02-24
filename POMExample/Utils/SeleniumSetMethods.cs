using OpenQA.Selenium;
using System;

namespace POMExample.Utils
{
    public static class SeleniumSetMethods
    {
        public static void EnterText(this IWebElement element, string value)
        {
            try
            {
                element.SendKeys(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured logging on: " + ex.ToString());
            }
        }

        public static void ClickOnElement(this IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured logging on: " + ex.ToString());
            }
        }
    }
}

