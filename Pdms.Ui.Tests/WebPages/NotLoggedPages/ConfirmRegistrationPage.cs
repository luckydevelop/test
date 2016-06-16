using System.Collections.Generic;
using Kliiko.Ui.Tests.WebPages.StaticPages;
using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.WebPages.NotLoggedPages
{
    class ConfirmRegistrationPage : WebPage
    {
        private static readonly By PlaceHolderCongratulationTxt = By.CssSelector(".text-gray-dark.text-center");
        private static readonly By PlaceHolderInstuctionTxt = By.XPath("html/body/div[2]/div/p");

        private static readonly IList<By> ListLocators = new List<By>();

        public static void ExpectWebElements()
        {
            if (ListLocators.Count == 0)
            {
                ListLocators.Add(PlaceHolderCongratulationTxt);
                ListLocators.Add(PlaceHolderInstuctionTxt);
            }

            Web.ExpectWebElements(ListLocators);

            HeaderBlock.ExpectedWebElementsNotLogged();
            FooterBlock.ExpectedWebElements();
        }
    }
}
