using OpenQA.Selenium;
using POMExample.PageObjects;
using System;

namespace POMExample.Utils
{
    class WebElementActionsUtil
    {
        public static void ClearAndInputTextIntoWebElement(IWebElement element, String text) {
            element.Clear();
            element.EnterText(text);
            Page.GetLog().Info("Field was cleared and text: " + text + ", was added");
        }
    }
}
