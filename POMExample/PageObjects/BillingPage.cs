using OpenQA.Selenium;
using POMExample.Utils;
using POMExample.WrapperFactory;
using SeleniumExtras.PageObjects;
using System;

namespace POMExample.PageObjects
{
    public class BillingPage
    {
        private readonly string removeXPath = "//a[contains(.,'Remove')]";
        private readonly string removeFirstXPath = "(//a[contains(.,'Remove')])[1]";

        [FindsBy(
            How = How.XPath,
            Using = "(//a[contains(.,'Remove')])[1]"
        )]
        private IWebElement removeFirstButton;

        [FindsBy(
            How = How.XPath,
            Using = "//a[contains(.,'Add new')]"
        )]
        private IWebElement addNewButton;

        [FindsBy(
            How = How.CssSelector,
            Using = "input.form-control[name='number']"
        )]
        private IWebElement cardNumberField;

        [FindsBy(
            How = How.CssSelector,
            Using = "input.form-control[name='expirationMonth']"
        )]
        private IWebElement expirationMonthField;

        [FindsBy(
            How = How.CssSelector,
            Using = "input.form-control[name='expirationYear']"
        )]
        private IWebElement expirationYearField;

        [FindsBy(
            How = How.CssSelector,
            Using = "input.form-control[name='cardholderName']"
        )]
        private IWebElement cardholderNameField;

        [FindsBy(
            How = How.XPath,
            Using = "//button[contains(.,'Add')]"
        )]
        private IWebElement addButton;

        [FindsBy(
            How = How.CssSelector,
            Using = ".col-md-7"
        )]
        private IWebElement cardRecord;

        [FindsBy(
            How = How.CssSelector,
            Using = "span.iv-icon-sync"
        )]
        private IWebElement syncLoader;

        public Boolean AddNewCard(String cardNumber)
        {
            addNewButton.ClickOnElement();
            cardNumberField.EnterText(cardNumber);
            expirationMonthField.EnterText("01");
            expirationYearField.EnterText("2100");
            cardholderNameField.EnterText("Test User");
            WaiterUtil.ElementIsClicableByXpath("//button[contains(.,'Add')]");
            addButton.ClickOnElement();
            WaiterUtil.ElementVisibleByCss(".col-md-7");
            return cardRecord.Text.Split(' ')[0].Equals(StringParser.GetSecureCode(cardNumber));
        }

        public void DeleteAllCards()
        {
            var amountOfCards = BrowserFactory.Driver.FindElements(By.XPath(removeXPath)).Count;
            for (int i = 0; i < amountOfCards; i++)
            {
                removeFirstButton.ClickOnElement();
            }
        }
    }
}
