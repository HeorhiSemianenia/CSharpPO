using OpenQA.Selenium;
using POMExample.Utils;
using SeleniumExtras.PageObjects;
using System;

namespace POMExample.PageObjects
{
    public class NewProjectPage
    {
        [FindsBy(
            How = How.XPath,
            Using = "//input[@class='form-control' and @placeholder='New project']"
        )]
        private IWebElement projectNameField;

        [FindsBy(
            How = How.XPath,
            Using = "//textarea[@name='description']"
        )]
        private IWebElement descriptionField;

        [FindsBy(
            How = How.XPath,
            Using = "//input[@class='form-control' and @placeholder='example.com']"
        )]
        private IWebElement domainsField;

        [FindsBy(
            How = How.XPath,
            Using = "//button[contains(.,'Create')]"
        )]
        private IWebElement createButton;

        public DashboardPage FillInAllFields(String projectName, String description, String domains)
        {
            projectNameField.EnterText(projectName);
            descriptionField.EnterText(description);
            domainsField.EnterText(domains);
            createButton.ClickOnElement();
            WaiterUtil.ElementInvisibleByXpath("//button[contains(.,'Create')]");
            return Page.Dashboard;
        }
    }
}
