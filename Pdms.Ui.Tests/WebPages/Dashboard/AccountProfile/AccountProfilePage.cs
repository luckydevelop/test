using Kliiko.Ui.Tests.WebPages.StaticPages;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Kliiko.Ui.Tests.WebPages.Dashboard.AccountProfile
{
    //user.kliiko.diatomdemo.com:8080/dashboard#/account-profile

    class AccountProfilePage : WebPage
    {
        private static readonly By ButtonUpgradePlan = By.CssSelector(".btn.btn-dashboard-menu.ng-scope");
        private static readonly By ButtonAccountManagers = By.CssSelector(".account-manager.pull-right");

        private static readonly By PlaceHolderManualTxt = By.CssSelector(".col-md-6.dashboard-index.text-center");

        private static readonly IList<By> ListLocators = new List<By>();


        public static void ExpectWebElements()
        {
            if (ListLocators.Count == 0)
            {
                ListLocators.Add(ButtonUpgradePlan);
                ListLocators.Add(ButtonAccountManagers);
                ListLocators.Add(PlaceHolderManualTxt);
            }

            HeaderBlock.ExpectedWebElements();
            FooterBlock.ExpectedWebElements();
        }

     
        public static void ClickButtonUpgradePlan()
        {
            Web.Click(ButtonUpgradePlan);
        }

        public static void ClickButtonAccountManagers()
        {
            Web.Click(ButtonAccountManagers);
        }

    }                   
}
