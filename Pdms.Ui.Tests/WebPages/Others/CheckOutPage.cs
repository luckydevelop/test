
using System;
using Kliiko.Ui.Tests.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.WebPages.Others
{
    class CheckOutPage : WebPage
    {
        private static readonly By TextPlanName = By.XPath(".//*[@id='cb-order-summary-main-list']/ul/li/div[1]/strong");
        private static readonly By IntPlanPrice = By.XPath(".//*[@id='cb-order-summary-main-list']/ul/li/div[2]");
        private static readonly By IntPlanTotal = By.XPath(".//*[@id='cb-order-total']/div[2]");


        private static readonly By InputFirstNameAccount = By.Id("customer[first_name]");
        private static readonly By InputLastNameAccount = By.Id("customer[last_name]");
        private static readonly By InputEmailAccount = By.Id("customer[email]");


        private static readonly By InputFirstNamePayment = By.Id("card[first_name]");
        private static readonly By InputLastNamePayment = By.Id("card[last_name]");
        private static readonly By InputCardNumberPayment = By.Id("card[number]");
        private static readonly By InputExpireMonthPayment = By.Id("card[expiry_month]");
        private static readonly By InputExpireYearPayment = By.Id("card[expiry_year]");
        private static readonly By InputCardCvPayment = By.Id("card[cvv]");

        private static readonly By ButtonSubcribe = By.CssSelector(".btn.btn-primary");
        private static readonly By ButtonCancel = By.CssSelector(".btn.btn-link");

        private static readonly By LinkValidCarNumberSpecial = By.XPath(".//*[@id='cb-test-cards']/div/ul/li[1]/a/small");
        private static readonly By LinkInValidCarNumberSpecial = By.XPath(".//*[@id='cb-test-cards']/div/ul/li[2]/a/small[1]");

        private static readonly By ValidationMsgInvalidCard = By.CssSelector(".error");

        

        public static void CheckNumberCorrect(int expectedNumber, By actualLocator)
        {
            string numberWithUsd = Web.GetLocatorText(actualLocator);
            string numberWoUsd = numberWithUsd.Substring(1, 3);
            Log.Info("string numberWoUsd - " + numberWoUsd);
            int actualNumber = Int32.Parse(numberWoUsd);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        public static void CheckOrderTotalCorrect(int expectedOrderTotal)
        {
            CheckNumberCorrect(expectedOrderTotal, IntPlanTotal);
        }

        public static void CheckPriceCorrect(int expectedPlanPrice)
        {
            CheckNumberCorrect(expectedPlanPrice, IntPlanPrice);
        }

        public static void CheckPlanNameCorrect(string expectedString)
        {
            string actualString = Web.GetLocatorText(TextPlanName);
            Assert.AreEqual(expectedString, actualString);
            //Assert.AreEqual(expectedString +" Plan", actualString);
        }

        
        public static string GetActualEmail()
        {
            return  Web.GetAttributeText(InputEmailAccount, "value");
        }

        public static void InputFirstName(string value)
        {
             Web.TypeNewText(InputFirstNamePayment, value);
        }

        public static void InputLastName(string value)
        {
            Web.TypeNewText(InputLastNamePayment, value);
        }

        public static void SelectValidCardNumber()
        {
            Web.Click(InputCardNumberPayment);
            Web.Click(InputCardNumberPayment);
            Web.Click(LinkValidCarNumberSpecial);
        }

        public static void SelectInvalidCardNumber()
        {
            Web.Click(InputCardNumberPayment);
            Web.Click(InputCardNumberPayment);
            Web.Click(LinkInValidCarNumberSpecial);
        }
        
        public static void ClickButtonSubscribe()
        {
            Web.Click(ButtonSubcribe);
        }


    }
}
