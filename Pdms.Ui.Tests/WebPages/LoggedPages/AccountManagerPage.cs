using System.Collections.Generic;
using Kliiko.Ui.Tests.WebPages.StaticPages;
using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.WebPages.LoggedPages
{
    class AccountManagerPage : WebPage
    {
        private static readonly By TabAccountManeger = By.XPath(".//*[@id='nav-tabs-main']/li[1]/a");
        private static readonly By TabAccountParticipant = By.XPath(".//*[@id='nav-tabs-main']/li[2]/a");

        private static readonly By TableHeaderAccountName = By.XPath("html/body/main/div/div[2]/div/div/div/div/div/div/table/thead/tr/th[1]");
        private static readonly By TableHeaderFirstName = By.XPath("html/body/main/div/div[2]/div/div/div/div/div/div/table/thead/tr/th[2]");
        private static readonly By TableHeaderLastName = By.XPath("html/body/main/div/div[2]/div/div/div/div/div/div/table/thead/tr/th[3]");

        private static readonly By TableCellAccountName = By.XPath("html/body/main/div/div[2]/div/div/div/div/div/div/table/tbody/tr/td[1]");
        private static readonly By TableCellFirstName = By.XPath("html/body/main/div/div[2]/div/div/div/div/div/div/table/tbody/tr/td[2]");
        private static readonly By TableCellLastName = By.XPath("html/body/main/div/div[2]/div/div/div/div/div/div/table/tbody/tr/td[3]");

        private static readonly By IconSelectUser =
            By.XPath("html/body/main/div/div[2]/div/div/div/div/div/div/table/tbody/tr/td[4]/a/span");
        
        private static readonly By ButtonLogOut = By.CssSelector(".btn-header-red");

        private static readonly IList<By> ListLocators = new List<By>();
        
        private static void FillListLocators()
        {
            ListLocators.Add(TabAccountManeger);
            ListLocators.Add(TabAccountParticipant);
            ListLocators.Add(TableHeaderAccountName);
            ListLocators.Add(TableHeaderFirstName);
            ListLocators.Add(TableHeaderLastName);
            ListLocators.Add(TableCellAccountName);
            ListLocators.Add(TableCellFirstName);
            ListLocators.Add(TableCellLastName);
            ListLocators.Add(IconSelectUser);
            ListLocators.Add(ButtonLogOut);
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

        public static string GetAccountName()
        {
            return Web.GetLocatorText(TableCellAccountName);
        }
        
        public static void ClickIconPlay()
        {
            Web.Click(IconSelectUser);
        }



    }
}
