using OpenQA.Selenium;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Kliiko.Ui.Tests.Utils;

namespace Kliiko.Ui.Tests.WebPages.StaticPages
{
    class HeaderBlock : WebPage
    {
        private static readonly By PlaceHolderLogoImg = By.XPath("//img[contains(@src,'Kliiko_logo_lines')]");

        private static readonly By PlaceHolderUserNameTxt = By.CssSelector(".col-xs-1.current-domain-name");
        private static readonly By PlaceHolderWelcomeTxt = By.CssSelector(".col-xs-12.col-md-7.btn-group.remove-link-line.nav-button-top-margin.text-right.ng-binding");

        private static readonly By ButtonTour = By.CssSelector(".btn-header-green");
        private static readonly By ButtonVideo = By.CssSelector(".btn-header-red");
       // private static readonly By ButtonMyDetails = By.Id("headerDropdown");
        private static readonly By ButtonMyDetails = By.XPath(".//*[@id='headerDropdown']");

        #region[DROP DOWN MENU]
        private static readonly By DropDownContact = By.XPath("html/body/div[2]/div[3]/ul/li[1]/a");
        private static readonly By DropDownChangePassword = By.LinkText("Change Password");
        private static readonly By DropDownDashboard = By.LinkText("My Dashboard");
        private static readonly By DropDownPaymentDetails = By.LinkText("Payment Details");
        private static readonly By DropDownGetSmsCredit = By.LinkText("Get SMS credits");
        private static readonly By DropDownLogOut = By.LinkText("Logout");
        #endregion

        private static readonly By TabAccountProfile = By.LinkText("Account Profile");
        private static readonly By TabSessions = By.LinkText("Sessions");
        private static readonly By TabResources = By.LinkText("Resources");

        private static readonly IList<By> ListLocatorsNotLogged = new List<By>();
        private static readonly IList<By> ListLocatorsLogged = new List<By>();

        public static void ExpectedWebElementsNotLogged()
        {
            Log.Info("Check loading of next page - "+ MethodBase.GetCurrentMethod().DeclaringType.Name);
            if (ListLocatorsNotLogged.Count == 0)
            {
                ListLocatorsNotLogged.Add(PlaceHolderLogoImg);
            }
            Web.ExpectWebElements(ListLocatorsNotLogged);
        }

        public static void ExpectedWebElements()
        {
            Log.Info("Check loading of next page - " + MethodBase.GetCurrentMethod().DeclaringType.Name);
            if (ListLocatorsLogged.Count == 0)
            {
                ListLocatorsLogged.Add(PlaceHolderLogoImg);
                ListLocatorsLogged.Add(PlaceHolderUserNameTxt);
                ListLocatorsLogged.Add(PlaceHolderWelcomeTxt);
                ListLocatorsLogged.Add(ButtonTour);
                ListLocatorsLogged.Add(ButtonVideo);
                ListLocatorsLogged.Add(ButtonMyDetails);
            }

            Web.ExpectWebElements(ListLocatorsLogged);           
        }

        public static void SelectAccountProfileTab()
        {
            Web.MoveMouse(TabAccountProfile);
            Web.Click(TabAccountProfile);
        }

        public static void SelectSessionsTab()
        {
            Web.Click(TabSessions);
        }

        public static void SelectResourcesTab()
        {
            Web.Click(TabResources);
        }
        
        public static void SelectLogOut()
        {
            SelectDropDownItem(DropDownLogOut);
        }

        public static void SelectChangePassword()
        {
            SelectDropDownItem(DropDownChangePassword);
        }

        public static void SelectContactDetails()
        {
            SelectDropDownItem(DropDownContact);
        }
        


        private static void SelectDropDownItem(By locator)
        {
            //Thread.Sleep(1000); 
            //Web.Click(ButtonMyDetails);
            //Web.WaitUntilToBeClicable(locator);
            //Web.ClickWithActions(locator);

            Web.MoveMouse(ButtonMyDetails);
            Web.Click(ButtonMyDetails);
            Web.ClickWithActions(locator);
        }

    }
}
