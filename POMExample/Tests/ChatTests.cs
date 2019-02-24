using NUnit.Allure.Core;
using NUnit.Framework;
using POMExample.PageObjects;
using POMExample.WrapperFactory;
using System.Configuration;
using System.Threading;

namespace POMExample.Tests
{
    [AllureNUnit]
    [Apartment(ApartmentState.STA)]
    class ChatTests
    {

        [OneTimeSetUp]
        public void SetUp()
        {
            BrowserFactory.InitBrowser();
        }

        [Test(Description = "Check possibility to change users settings on the chat")]
        public void ChangeUserProp()
        {
            var chat = Page.Chat;
            chat.GoToPage();
            Assert.IsTrue(chat.CheckGuestProperty("Heorhi", ConfigurationManager.ConnectionStrings["image"].ConnectionString));
        }

        [Test(Description = "Check possibility to copy a link for joining to the chat")]
        public void CopyLink()
        {
            var chat = Page.Chat;
            chat.GoToPage();
            Assert.IsTrue(chat.ClickInvite().Contains("https://dev.integrivideo.com/demo"));
        }

        [Test(Description = "Check possibility to copy script for external chart integration")]
        public void CopyCode()
        {
            var chat = Page.Chat;
            chat.GoToPage();
            Assert.IsTrue(chat.CopyMarkup().Contains("https://dev.integrivideo.com/integri.js"));
        }

        [Test(Description = "Check possibility to perform Add, Edit and Delete actions with a message on the chat")]
        public void DeleteMessage()
        {
            var chat = Page.Chat;
            chat.GoToPage();
            Assert.AreEqual(chat.AddMessage("Hello Selenium C#"), "Hello Selenium C#", "Incorrect message on the chat");
            Assert.AreEqual(chat.EditMessage("Edited message"), "Edited message", "Incorrect message on the chat");
            Assert.AreEqual(chat.DeleteMessage(), "removed...", "Message was removed incorrectly");
        }

        [Test(Description = "Check possibility to upload file to the chat")]
        public void UploadFile()
        {
            var chat = Page.Chat;
            chat.GoToPage();
            Assert.IsTrue(chat.UploadFile("App.config"), "File was uploded incorrectly");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            BrowserFactory.CloseDriver();
        }
    }
}
