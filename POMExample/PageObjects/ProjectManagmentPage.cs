using OpenQA.Selenium;
using POMExample.Utils;
using POMExample.WrapperFactory;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace POMExample.PageObjects
{
    public class ProjectManagmentPage
    {
        [FindsBy(
            How = How.XPath,
            Using = "//div[@class='col-12 description']"
        )]
        private IWebElement projectDescription;

        [FindsBy(
            How = How.XPath,
            Using = "//div[@class='col-10']/h1"
        )]
        private IWebElement projectTitle;

        [FindsBy(
            How = How.XPath,
            Using = "//span[contains(@class,'file-add')]"
        )]
        private IWebElement addComponentButton;

        [FindsBy(
            How = How.CssSelector,
            Using = "input.form-control"
        )]
        private IWebElement componentNameField;

        [FindsBy(
            How = How.XPath,
            Using = "//button[contains(.,'Create')]"
        )]
        private IWebElement createButton;

        [FindsBy(
            How = How.XPath,
            Using = "//button[contains(.,'Update')]"
        )]
        private IWebElement updateButton;

        [FindsBy(
            How = How.XPath,
            Using = "//div[@class='component']"
        )]
        private IWebElement componentElement;

        [FindsBy(
            How = How.CssSelector,
            Using = ".select2-selection__rendered"
        )]
        private IWebElement dropDown;

        public Dictionary<string, string> getProjectProperties()
        {
            Dictionary<string, string> project = new Dictionary<string, string>();
            project.Add("Name", projectTitle.Text);
            project.Add("Description", projectDescription.Text);
            return project;
        }

        public Boolean addComponent(String componentName)
        {
            addComponentButton.ClickOnElement();
            dropDown.ClickOnElement();
            IWebElement dropDownOption = BrowserFactory.Driver.FindElement(By.XPath(String.Format("//li[contains(.,'{0}')]", componentName)));
            dropDownOption.ClickOnElement();
            componentNameField.EnterText("My Component");
            createButton.ClickOnElement();
            WaiterUtil.ElementVisibleByXpath("//button[contains(.,'Update')]");
            updateButton.ClickOnElement();
            WaiterUtil.ElementVisibleByXpath("//div[@class='component']");
            return componentElement.Text.Contains(componentName);
        }
    }
}