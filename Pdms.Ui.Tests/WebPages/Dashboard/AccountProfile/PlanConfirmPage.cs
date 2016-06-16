using System;
using Kliiko.Ui.Tests.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.WebPages.Dashboard.AccountProfile
{
    //user.kliiko.diatomdemo.com:8080/dashboard#/account-profile/upgrade-plan 
    class PlanConfirmPage : WebPage
    {

        private static readonly By ButtonSubmit = By.CssSelector(".col-md-4.btn-dashboard-plans.btn-md.pull-right.btn-standart.btn-red");
        private static readonly By ButtonBack = By.CssSelector(".col-md-4.btn-dashboard-plans.btn-md.pull-left.btn-standart.btn-red");

        //private static readonly By CheckBoxTerms = By.CssSelector(".check>label");
        private static readonly By CheckBoxTerms = By.XPath(".//*[@id='chargebee-details']/div/div[1]/div/label");
        private static readonly By LinkTerms = By.CssSelector(".shake-this>a");

        private static readonly By TextPlanName = By.XPath(".//*[@id='step-3']/div/div[1]/ng-include/div/div[2]/div[2]/div[1]");
        private static readonly By TexDuration= By.XPath(".//*[@id='step-3']/div/div[1]/ng-include/div/div[2]/div[2]/div[2]");
        private static readonly By IntTotalPrice = By.XPath(".//*[@id='step-3']/div/div[1]/ng-include/div/div[2]/div[2]/div[3]");
        private static readonly By IntOrderTotalSum= By.XPath(".//*[@id='step-3']/div/div[1]/ng-include/div/div[2]/div[3]/div[2]");


        public static void CheckStringCorrect(string expectedString, By actualLocator)
        {
            string actualString = Web.GetLocatorText(actualLocator);
            Assert.AreEqual(expectedString, actualString);
        }

        public static void CheckPlanNameCorrect(string expectedPlanName)
        {
            CheckStringCorrect(expectedPlanName, TextPlanName);
        }
        

        public static void CheckNumberCorrect(int expectedNumber, By actualLocator)
        {
            string numberWithUsd = Web.GetLocatorText(actualLocator);
            string numberWoUsd = numberWithUsd.Substring(4);
            int actualNumber = Int32.Parse(numberWoUsd);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        public static void CheckOrderTotalCorrect(int expectedOrderTotal)
        {
            CheckNumberCorrect(expectedOrderTotal, IntOrderTotalSum);
        }

        public static void CheckPriceCorrect(int expectedPlanPrice)
        {
            CheckNumberCorrect(expectedPlanPrice, IntTotalPrice);
        }

        public static void SubmitOrder()
        {
            Web.Click(CheckBoxTerms);
            Web.Click(ButtonSubmit);
        }

        public static void ClickButtonSubmitOrder()
        {
            Web.Click(ButtonSubmit);
        }

        public static void SelectTermsAndConditionsCheckBox()
        {
            Web.Click(CheckBoxTerms);
        }



        //.//*[@id='step-3']/div/div[1]/ng-include/div/div[2]/div[3]/div[2]



    }
}
