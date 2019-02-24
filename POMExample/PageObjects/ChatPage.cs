using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using POMExample.Utils;
using POMExample.WrapperFactory;
using SeleniumExtras.PageObjects;
using System;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;

namespace POMExample.PageObjects
{
    public class ChatPage
    {
        private readonly string chatPageUrl = "https://dev.integrivideo.com/demo/chat/new";
        private readonly string nameSettingsString = "//div[@class='integri-modal-content']//input[@type='text']";
        private readonly string inputMessageFieldCSS = "integri-chat-input textarea";

        [FindsBy(
            How = How.XPath,
            Using = "//button[@class='btn']/span"
        )]
        private IWebElement statisticsTitle;

        [FindsBy(
            How = How.XPath,
            Using = "//div[@class='integri-chat-action-buttons']//span[contains(@class,'plane')]"
        )]
        private IWebElement sendMessageButton;

        [FindsBy(
            How = How.XPath,
            Using = "//button[contains(text(),'Invite')]"
        )]
        private IWebElement inviteUsersButton;

        [FindsBy(
            How = How.CssSelector,
            Using = "code.component-code"
        )]
        private IWebElement copyCodeArea;

        [FindsBy(
            How = How.XPath,
            Using = "//div[@class='integri-modal-content']//input[@type='text']"
        )]
        private IWebElement nameSettings;

        [FindsBy(
            How = How.XPath,
            Using = "//div[@class='integri-modal-content']//input[@type='email']"
        )]
        private IWebElement emailSettings;

        [FindsBy(
            How = How.XPath,
            Using = "//div[@class='integri-modal-content']//input[@type='url']"
        )]
        private IWebElement photoSettings;

        [FindsBy(
            How = How.XPath,
            Using = "//div[@class='integri-session-user-name']"
        )]
        private IWebElement userNameHeader;

        [FindsBy(
            How = How.XPath,
            Using = "//div[@class='integri-session-user-name']/preceding-sibling::div"
        )]
        private IWebElement userNamePhoto;

        [FindsBy(
            How = How.XPath,
            Using = "//span[@class='iv-icon iv-icon-cog']"
        )]
        private IWebElement settingsIcon;

        [FindsBy(
            How = How.XPath,
            Using = "//button[contains(@class,'settings-save')]"
        )]
        private IWebElement saveSettingsButton;

        [FindsBy(
            How = How.XPath,
            Using = "//span[contains(.,'Drag & drop')]"
        )]
        private IWebElement dragDropButton;

        [FindsBy(
            How = How.XPath,
            Using = "//input[@type='file' and @class='integri-hide']"
        )]
        private IWebElement inputArea;

        [FindsBy(
            How = How.XPath,
            Using = "//button[contains(.,'Start')]"
        )]
        private IWebElement startButton;

        [FindsBy(
            How = How.CssSelector,
            Using = "div.integri-chat-message"
        )]
        private IWebElement chatMessage;

        [FindsBy(
            How = How.CssSelector,
            Using = "div.integri-chat-message-text"
        )]
        private IWebElement chatMessageText;

        [FindsBy(
            How = How.XPath,
            Using = "//span[contains(@class,'iv-icon-pencil')]"
        )]
        private IWebElement chatMessageEditIcon;

        [FindsBy(
            How = How.XPath,
            Using = "//span[contains(@class,'iv-icon-trash2')]"
        )]
        private IWebElement chatMessageDeleteIcon;

        [FindsBy(
            How = How.XPath,
            Using = "//div[@class='integri-chat-message ']/textarea"
        )]
        private IWebElement messageTextArea;


        public String AddMessage(string text)
        {
            WaiterUtil.ElementVisibleByCss("." + inputMessageFieldCSS);
            JSUtil.ExecuteJSScript(string.Format("document.querySelector(\".{0}\").value=\"{1}\"", inputMessageFieldCSS, text));
            sendMessageButton.ClickOnElement();
            WaiterUtil.ElementVisibleByCss("div.integri-chat-message");
            return chatMessageText.Text;
        }

        public string ClickInvite()
        {
            inviteUsersButton.ClickOnElement();
            return Clipboard.GetText(TextDataFormat.Text);
        }

        public string CopyMarkup()
        {
            int width = copyCodeArea.Size.Width;
            int height = copyCodeArea.Size.Height;
            Actions act = new Actions(BrowserFactory.Driver);
            act.MoveToElement(copyCodeArea).MoveByOffset(width / 2, height / 2).Click().Perform();
            return Clipboard.GetText(TextDataFormat.Text);
        }

        public void GoToPage()
        {
            BrowserFactory.Driver.Navigate().GoToUrl(chatPageUrl);
        }

        public String DeleteMessage()
        {
            chatMessageDeleteIcon.ClickOnElement();
            BrowserFactory.Driver.SwitchTo().Alert().Accept();
            WaiterUtil.ElementVisibleByCss("div.integri-chat-message-utility");
            return chatMessageText.Text;
        }

        public String EditMessage(String text)
        {
            chatMessageEditIcon.ClickOnElement();
            WebElementActionsUtil.ClearAndInputTextIntoWebElement(messageTextArea, text);
            messageTextArea.EnterText(Keys.Enter);
            WaiterUtil.ElementInvisibleByXpath("//div[@class='integri-chat-message ']/textarea");
            return chatMessageText.Text;
        }

        private void setGuestProperty(String name, String email, String photoAddress)
        {
            WaiterUtil.ElementVisibleByXpath("//span[@class='iv-icon iv-icon-cog']");
            settingsIcon.ClickOnElement();
            WaiterUtil.ElementVisibleByXpath(nameSettingsString);
            WebElementActionsUtil.ClearAndInputTextIntoWebElement(nameSettings, name);
            WebElementActionsUtil.ClearAndInputTextIntoWebElement(emailSettings, email);
            WebElementActionsUtil.ClearAndInputTextIntoWebElement(photoSettings, photoAddress);
            saveSettingsButton.ClickOnElement();
            WaiterUtil.ElementInvisibleByXpath(nameSettingsString);
        }

        public Boolean CheckGuestProperty(String name, String photoAddress)
        {
            setGuestProperty(name, "", photoAddress);
            Boolean bResult = userNameHeader.Text.Contains(name);
            bResult &= emailSettings.Text.Contains("");
            bResult &= userNamePhoto.GetAttribute("style").Contains(photoAddress);
            return bResult;
        }

        public Boolean UploadFile(string fileName)
        {
            WaiterUtil.ElementVisibleByXpath("//span[contains(.,'Drag & drop')]");
            dragDropButton.ClickOnElement();
            inputArea.EnterText(FilePathUtils.GetAbsolutePath(fileName));
            IWebElement uploadingProgress = BrowserFactory.Driver.FindElement(By.CssSelector("div[class='integri-file-item']"));
            startButton.ClickOnElement();
            WaiterUtil.ElementInvisibleByCss("div[class='integri-file-item']");
            WaiterUtil.ElementVisibleByCss("div.integri-chat-message");
            return chatMessage.Displayed;
        }
    }
}