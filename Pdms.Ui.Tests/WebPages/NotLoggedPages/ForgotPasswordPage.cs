using System;
using System.Collections.Generic;
using Kliiko.Ui.Tests.WebPages.StaticPages;
using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.WebPages.NotLoggedPages
{
    class ForgotPasswordPage : WebPage
    {
        private static readonly By InputEmail = By.Id("email");

        private static readonly By ButtonSubmit =
            By.CssSelector(".btn.submit-btn-size.border-yellow.text-brown-light.background-transp.pull-right");

        private static readonly By WarningMsgEmail = By.Id("warning-email-password");
        private static readonly By LogoEmail = By.CssSelector(".form-group.text-center>img");
        private static readonly By TextInstruction = By.XPath(".//*[@id='login']/h5");
        private static readonly By TextInstructionEmail = By.CssSelector(".reset-password-success-message");

        private static readonly By TextEmail =
            By.XPath(".//*[@id='login']/form/div/div[1]/div/table/tbody/tr/td[1]/label");

        private static readonly IList<By> ListLocators = new List<By>();
        
        private static void FillListLocators()
        {
            ListLocators.Add(InputEmail);
            ListLocators.Add(ButtonSubmit);
            ListLocators.Add(LogoEmail);
            ListLocators.Add(TextInstruction);
            ListLocators.Add(TextEmail);
        }

        public static void ExpectWebElements()
        {
            if (ListLocators.Count == 0)
            {
                FillListLocators();
            }
            Web.ExpectWebElements(ListLocators);
            HeaderBlock.ExpectedWebElementsNotLogged();
            FooterBlock.ExpectedWebElements();
        }

        public static void ExpectWebElementsWhenPageReload()
        {

            Web.IsElementVisible(TextInstructionEmail);
        }

        public static bool IsWarningMessagesPresent(string message)
        {
            if (Web.GetLocatorText(WarningMsgEmail).Equals(message))
            {
                return true;
            }

            return false;
        }

        public static void FillFieldEmail(String emailAddress)
        {
            Web.Type(InputEmail, emailAddress);
        }

        public static void ClickButtonSubmit()
        {
            Web.Click(ButtonSubmit);
        }







        //public static void EmailValidation()
        //{
        //    Web.Validation(WarningMsgEmail);
        //}
    }
}
