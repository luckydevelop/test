using OpenQA.Selenium;
using System.Collections.Generic;
using System.Reflection;
using Kliiko.Ui.Tests.Utils;

namespace Kliiko.Ui.Tests.WebPages.StaticPages
{
    class FooterBlock : WebPage
    {
        private static readonly By PlaceHolderKlzii = By.Id("footer");
        private static readonly By LinkPrivacyPolicy = By.LinkText("Privacy Policy");
        private static readonly By LinkTermsConditions = By.LinkText("Terms & Conditions");

        private static readonly IList<By> ListLocators = new List<By>();

        public static void ExpectedWebElements()
        {
            Log.Info("Check loading of next page - " + MethodBase.GetCurrentMethod().DeclaringType.Name);
            if (ListLocators.Count == 0)
            {
                ListLocators.Add(PlaceHolderKlzii);
                ListLocators.Add(LinkPrivacyPolicy);
                ListLocators.Add(LinkTermsConditions);
            }
            Web.ExpectWebElements(ListLocators);
        }

    }
}
