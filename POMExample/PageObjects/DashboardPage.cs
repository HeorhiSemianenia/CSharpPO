using OpenQA.Selenium;
using POMExample.Utils;
using POMExample.WrapperFactory;
using SeleniumExtras.PageObjects;

namespace POMExample.PageObjects
{
    public class DashboardPage
    {
        [FindsBy(
            How = How.XPath,
            Using = "//a/span[@class='iv-icon iv-icon-file-add']"
        )]
        private IWebElement addProjectButton;

        [FindsBy(
            How = How.XPath,
            Using = "//a[contains(.,'Billing')]"
        )]
        private IWebElement billingHeaderButton;

        public NewProjectPage GetNewProjectForm()
        {
            addProjectButton.ClickOnElement();
            return Page.NewProject;
        }

        public ProjectManagmentPage OpenExistingProject(string mnemonic)
        {
            var project = BrowserFactory.Driver.FindElements(By.XPath(string.Format("//div[@class='circle' and contains(.,'{0}')]", mnemonic)));
            var element = project[project.Count - 1];
            element.ClickOnElement();
            return Page.ProjectManagment;
        }

        public BillingPage GoToBillingPage()
        {
            billingHeaderButton.ClickOnElement();
            WaiterUtil.ElementVisibleByCss("div.col-md-6>a.btn");
            return Page.Billing;
        }
    }
}