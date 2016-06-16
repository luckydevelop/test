using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.WebPages.NotLoggedPages
{
    class ConfirmInvitationAccountManagerPage : WebPage
    {
        private static readonly By InputPassword = By.Id("password");

        private static readonly By ButtonAccept = By.LinkText("Accept");
        private static readonly By ButtonDecline = By.LinkText("Decline");

        private static readonly By WarningMsgPassword = By.Id("warning-email-password");

        private static readonly By TextInfo = By.XPath(".//*[@id='login']/h5");

        public static void FillFieldPassword(String password)
        {
            Web.Type(InputPassword, password);
        }

        public static void ClickButtonAccept()
        {
            Web.Click(ButtonAccept);
        }
    }
}
