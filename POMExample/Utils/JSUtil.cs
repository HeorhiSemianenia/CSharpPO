using OpenQA.Selenium;
using POMExample.PageObjects;
using POMExample.WrapperFactory;
using System;

namespace POMExample.Utils
{
    class JSUtil
    {

        public static void ExecuteJSScript(String script) {
            IJavaScriptExecutor jse = (IJavaScriptExecutor) BrowserFactory.Driver;
            jse.ExecuteScript(script);
            Page.GetLog().Info("JavaScript code: " + script + " was execuded");
        }

    }
}
