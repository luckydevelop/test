using System;
using System.Collections.Generic;
using Kliiko.Ui.Tests.WebPages.StaticPages;
using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.WebPages.NotLoggedPages
{
    class ResetPasswordPage : WebPage
    {
        private static readonly By InputPassword = By.Id("password");
        private static readonly By InputReEnterPassword = By.Id("repassword");

        private static readonly By ButtonSubmit =
            By.CssSelector(".btn.submit-btn-size.border-yellow.text-brown-light.background-transp.pull-right");

        private static readonly By TesxtPassword =
            By.XPath(".//*[@id='login']/form/div/div[1]/div/table/tbody/tr[1]/td[1]/label");

        private static readonly By TesxtReEnterPassword =
            By.XPath(".//*[@id='login']/form/div/div[1]/div/table/tbody/tr[2]/td[1]/label");

        private static readonly By IconPassword =
            By.XPath(".//*[@id='login']/form/div/div[1]/div/table/tbody/tr[1]/td[2]/img");

        private static readonly By IconReEnterPassword =
            By.XPath(".//*[@id='login']/form/div/div[1]/div/table/tbody/tr[2]/td[2]/img");

        private static readonly By WarningMsgPassword = By.XPath(".//*[@id='login']/form/div/div[1]/div/span[1]");
        private static readonly By WarningMsgTokenEpired = By.XPath(".//*[@id='login']/h4/div");
        
        private static readonly IList<By> ListLocators = new List<By>();
        
        private static void FillListLocators()
        {
            ListLocators.Add(InputPassword);
            ListLocators.Add(InputReEnterPassword);
            ListLocators.Add(ButtonSubmit);
            ListLocators.Add(TesxtPassword);
            ListLocators.Add(TesxtReEnterPassword);
            ListLocators.Add(IconPassword);
            ListLocators.Add(IconReEnterPassword);
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

        public static void FillFieldPassword(String value)
        {
            Web.Type(InputPassword, value);
        }

        public static void FillFieldReEnterPassword(String value)
        {
            Web.Type(InputReEnterPassword, value);
        }

        public static void ClickButtonSubmit()
        {
            Web.Click(ButtonSubmit);
        }
    }
}
