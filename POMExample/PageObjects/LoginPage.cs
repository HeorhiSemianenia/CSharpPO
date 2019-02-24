using OpenQA.Selenium;
using POMExample.Utils;
using POMExample.WrapperFactory;
using SeleniumExtras.PageObjects;

namespace POMExample.PageObjects
{
    public class LoginPage
    {
        private readonly string LOGIN_PAGE_URL = "https://dev.integrivideo.com/login";
        
        [FindsBy(
            How = How.XPath,
            Using = "//div[@class='logo']//img"
        )]
        private IWebElement logo;

        [FindsBy(
            How = How.XPath,
            Using = "//input[@type='email']"
        )]
        private IWebElement email;

        [FindsBy(
            How = How.XPath,
            Using = "//input[@type='password']"
        )]
        private IWebElement password;

        [FindsBy(
            How = How.XPath,
            Using = "//button/i"
        )]
        private IWebElement loginButton;

        public void GoToPage()
        {
            BrowserFactory.Driver.Navigate().GoToUrl(LOGIN_PAGE_URL);
        }

        public DashboardPage LoginIntoDashboard()
        {
            email.EnterText("integriuser2@mailinator.com");
            password.EnterText("integripassword");
            WaiterUtil.ElementIsClicableByXpath("//button/i");
            loginButton.ClickOnElement();
            WaiterUtil.ElementInvisibleByXpath("//button/i");
            return Page.Dashboard;
        }
    }
}