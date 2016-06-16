using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Kliiko.Ui.Tests.Utils;

namespace Kliiko.Ui.Tests.WebPages.PopUp
{
    class ChangePasswordPopUp : WebPage
    {
        private static readonly By InputPassword = By.Id("password");
        private static readonly By InputConfirmPassword = By.Id("repassword");

        private static readonly By ButtonDone =
            By.XPath(".//*[@id='changePasswordModal']/div/div/div[2]/div/form/div[3]/span/button[3]");

        private static readonly By ButtonUpdate =
            By.XPath(".//*[@id='changePasswordModal']/div/div/div[2]/div/form/div[3]/span/button[2]");

        private static readonly By ButtonCancel =
            By.XPath(".//*[@id='changePasswordModal']/div/div/div[2]/div/form/div[3]/span/button[1]");

        private static readonly By ButtonClose = By.CssSelector(".close");

        private static readonly By WarningMsgSuccess = By.XPath("//div[contains(text(), 'Password was')]");
        private static readonly By WarningMsgFillBoth = By.XPath("//div[contains(text(), 'Please fill')]");
        private static readonly By WarningMsgNotEqual = By.XPath("//div[contains(text(), 'not equal')]");
        private static readonly By WarningMsg7AndLonger = By.XPath("//div[contains(text(), '7 characters')]");

        private static readonly By TextPassword =
            By.XPath(".//*[@id='changePasswordModal']/div/div/div[2]/div/form/div[1]/label");

        private static readonly By TextConfirmPassword =
            By.XPath(".//*[@id='changePasswordModal']/div/div/div[2]/div/form/div[2]/label");


        private static readonly IList<By> ListLocators = new List<By>();
        private static readonly IList<By> ListWarningsMessages = new List<By>();

        private static IList<By> FillListWarningMessages()
        {
            ListWarningsMessages.Add(WarningMsgSuccess);
            ListWarningsMessages.Add(WarningMsg7AndLonger);
            ListWarningsMessages.Add(WarningMsgFillBoth);
            ListWarningsMessages.Add(WarningMsgNotEqual);
            return ListWarningsMessages;
        }

        public static bool IsWarningMessagesPresent(string message)
        {
            Log.Info("public static bool IsWarningMessagePresent(string message)");
            Log.Info("string message - " + message);

            if (ListWarningsMessages.Count == 0)
            {
                FillListWarningMessages();
            }
            
            foreach (var messages in ListWarningsMessages)
            {
                if (Web.IsElementVisibleMilliseconds(messages, 500))
                {
                    Log.Info("Next locator IS VISIBLE - " + messages);
                    string locatorText = Web.GetLocatorText(messages);
                    Log.Info("Locator text is - " + locatorText + " Text SHOULD be - " + message);
                    if (locatorText.Equals(message))
                    {
                        Web.WaitUntilInVisible(messages); 
                        return true;
                    }
                }
                Log.Info("Next locator IS NOT VISIBLE - " + messages);
            }

            return false;
        }

        private static void FillListLocators()
        {
            ListLocators.Add(InputPassword);
            ListLocators.Add(InputConfirmPassword);
            ListLocators.Add(ButtonDone);
            ListLocators.Add(ButtonClose);
            ListLocators.Add(TextPassword);
            ListLocators.Add(TextConfirmPassword);
        }

        public static void ExpectWebElements()
        {
            if (ListLocators.Count == 0)
            {
                FillListLocators();
            }
            Web.ExpectWebElements(ListLocators);
        }

        public static void FillFieldPassword(String value)
        {
            Web.Type(InputPassword, value);
        }

        public static void FillFieldConfirmPassword(String value)
        {
            Web.Type(InputConfirmPassword, value);
        }

        public static void ClickButtonCancel()
        {
            Web.Click(ButtonCancel);
        }

        public static void ClickButtonUpdate()
        {
            Web.Click(ButtonUpdate);
        }

        public static void ClickButtonClose()
        {
            Web.Click(ButtonClose);
        }

        public static void ClickButtonDone()
        {
            Web.Click(ButtonDone);
        }
    }
}

