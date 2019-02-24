using NUnit.Allure.Core;
using NUnit.Framework;
using POMExample.PageObjects;
using POMExample.WrapperFactory;


namespace POMExample.Tests
{
    [AllureNUnit]
    class AdminTests
    {

        [SetUp]
        public void SetUp()
        {
            BrowserFactory.InitBrowser();
        }

        [Test(Description = "Check that user is able to add new card for payment")]
        public void AddCard()
        {
            var home = Page.Login;
            home.GoToPage();
            DashboardPage dashboard = home.LoginIntoDashboard();
            var billing = dashboard.GoToBillingPage();
            billing.DeleteAllCards();
            Assert.IsTrue(billing.AddNewCard("4242424242424242"), "Error during adding the card.");
        }

        [Test(Description = "Check that user is able to add new project on Dashboard")]
        public void AddNewProject()
        {
            var loginPage = Page.Login;
            loginPage.GoToPage();
            DashboardPage dashboardPage1 = loginPage.LoginIntoDashboard();
            NewProjectPage newProjectPage = dashboardPage1.GetNewProjectForm();
            DashboardPage dashboardPage2 = newProjectPage.FillInAllFields("TEST_JAVA", "Test Java description.", "test.com");
            ProjectManagmentPage newProjectPage2 = dashboardPage2.OpenExistingProject("TJ");
            Assert.AreEqual(newProjectPage2.getProjectProperties()["Name"], "TEST_JAVA", "Incorrect name");
            Assert.AreEqual(newProjectPage2.getProjectProperties()["Description"], "Test Java description.", "Incorrect description");
        }

        [Test(Description = "Check that user is able to add new component to the project")]
        public void AddProjectComponent()
        {
            var home = Page.Login;
            home.GoToPage();
            DashboardPage dashboardPage = home.LoginIntoDashboard();
            ProjectManagmentPage newProjectPage = dashboardPage.OpenExistingProject("TJ");
            Assert.IsTrue(newProjectPage.addComponent("Single Video"), "Component doesn't exist");
        }

        [Test(Description = "Check that user is able to login in the system and headers on pages are correct")]
        public void LoginInSystem()
        {
            var loginPage = Page.Login;
            loginPage.GoToPage();
            Assert.AreEqual("IntegriVideo - Video components for your website", BrowserFactory.Driver.Title);
            DashboardPage about = loginPage.LoginIntoDashboard();
            Assert.AreEqual("IntegriVideo - Video components for your website", BrowserFactory.Driver.Title);
        }

        [TearDown]
        public void TearDown()
        {
            BrowserFactory.CloseDriver();
        }
    }
}
