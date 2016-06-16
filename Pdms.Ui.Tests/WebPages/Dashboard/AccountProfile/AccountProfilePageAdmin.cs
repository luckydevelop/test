using Kliiko.Ui.Tests.WebPages.StaticPages;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Kliiko.Ui.Tests.WebPages.Dashboard.AccountProfile
{
    class AccountProfilePageAdmin
    {
        private static readonly By BottonAccountDb = By.XPath(".//*[@id='dashboard']/div/section/div[2]/div/div[1]");
        private static readonly By BottonPromotionCodes = By.XPath(".//*[@id='dashboard']/div/section/div[2]/div/div[2]");
        private static readonly By BottonUploadBanner = By.XPath(".//*[@id='dashboard']/div/section/div[2]/div/div[2]");
        private static readonly By BottonEmailTemplates = By.XPath(".//*[@id='dashboard']/div/section/div[2]/div/div[2]");
        private static readonly By BottonSessionRating = By.XPath(".//*[@id='dashboard']/div/section/div[2]/div/div[2]");

        private static readonly By PlaceHolderManualTxt = By.CssSelector(".col-md-6.dashboard-index.text-center");

        private static readonly IList<By> ListLocators = new List<By>();


        public static void ExpectWebElements()
        {
            if (ListLocators.Count == 0)
            {
                ListLocators.Add(BottonAccountDb);
                ListLocators.Add(BottonPromotionCodes);
                ListLocators.Add(BottonUploadBanner);
                ListLocators.Add(BottonEmailTemplates);
                ListLocators.Add(BottonSessionRating);
            }

            HeaderBlock.ExpectedWebElements();
            FooterBlock.ExpectedWebElements();
        }

    }                   
}
