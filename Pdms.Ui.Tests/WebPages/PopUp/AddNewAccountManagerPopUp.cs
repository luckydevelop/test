
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Kliiko.Ui.Tests.Selenium;
using Kliiko.Ui.Tests.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Kliiko.Ui.Tests.WebPages.PopUp
{
    class AddNewAccountManagerPopUp : WebPage
    {
        private static readonly By InputFirstName = By.XPath(".//*[@id='accountManagerModal']//*[@id='firstName']");
        private static readonly By InputLastName = By.XPath(".//*[@id='accountManagerModal']//*[@id='lastName']");
        private static readonly By InputEmail = By.XPath(".//*[@id='accountManagerModal']//*[@id='email']");
        private static readonly By InputMobileNumber = By.XPath(".//*[@id='accountManagerModal']//*[@id='mobileAM']");

        private static readonly By InputLandlineNumber =
            By.XPath(".//*[@id='accountManagerModal']//*[@id='landlineNumberAM']");

        private static readonly By InputPostalAdress =
            By.XPath(".//*[@id='accountManagerModal']//*[@id='postalAddress']");

        private static readonly By InputCity = By.XPath(".//*[@id='accountManagerModal']//*[@id='city']");
        private static readonly By InputState = By.XPath(".//*[@id='accountManagerModal']//*[@id='state']");
        private static readonly By InputPostCode = By.XPath(".//*[@id='accountManagerModal']//*[@id='postCode']");
        private static readonly By InputCountry = By.XPath(".//*[@id='accountManagerModal']//*[@id='country']");
        private static readonly By InputCompanyName = By.XPath(".//*[@id='accountManagerModal']//*[@id='companyName']");

        private static readonly By CheckBoxMale =
            By.XPath(".//*[@id='accountManagerModal']/div/div/div[2]/form/div/div/div[1]/div[4]/div/label[1]/input");

        private static readonly By CheckBoxFemale =
            By.XPath(".//*[@id='accountManagerModal']/div/div/div[2]/form/div/div/div[1]/div[4]/div/label[2]/input");

        private static readonly By DropdownMenuFlagsMobileNumber =
            By.XPath(".//*[@id='accountManagerModal']/div/div/div[2]/form/div/div/div[1]/div[5]/div/div/div/div");

        private static readonly By DropdownMenuFlagsLandlineNumber =
            By.XPath(".//*[@id='accountManagerModal']/div/div/div[2]/form/div/div/div[1]/div[6]/div/div/div/div");

        private static readonly By ButtonCloseButton =
            By.CssSelector(".btn.border-red.text-red-dark.border-radius-none.background-transp.btn-md.pull-left");

        private static readonly By ButtonCloseButtonCross =
            By.XPath(".//*[@id='accountManagerModal']/div/div/div[1]/button");

        public static readonly By ButtonInvite =
            By.CssSelector(
                ".btn.border-red.text-red-dark.border-radius-none.background-transp.btn-md.pull-right.ng-binding");

        private static readonly By WarningMsgSuccessfully =
            By.XPath("//div[contains(text(), 'Successfully sent invite.')]");

        private static readonly By WarningMsgFirstNameEmpty =
            By.XPath("//div[contains(text(), \"firstName: First Name can't be empty\")]");

        private static readonly By WarningMsgUserAlreadyInvited =
            By.XPath("//div[contains(text(), \"email: This user is already invited.\")]");

        private static readonly By WarningMsgLastNameEmpty =
            By.XPath("//div[contains(text(), 'lastName: Last Name can')]");

        private static readonly By WarningMsgInvalidFormat =
            By.XPath("//div[contains(text(), 'email: Email has invalid format')]");

        private static readonly By WarningMsgEmptyEmail = By.XPath("//div[contains(text(), 'email: Email can')]");

        private static readonly By WarningMsgInviteYourself =
            By.XPath("//div[contains(text(), 'email: You are trying to invite yourself.')]");

        private static readonly By WarningMsgGenderEmpty = By.XPath("//div[contains(text(), 'gender: Gender can')]");

        private static readonly By WarningMsgFirstLastNameEmpty =
            By.XPath(
                "//div[contains(@id, 'msg') and normalize-space()=\"firstName: First Name can't be empty lastName: Last Name can't be empty\"]");

        private static readonly By WarningMsgLastNameEmptyEmailInvalid =
            By.XPath(
                "//div[contains(@id, 'msg') and normalize-space()=\"lastName: Last Name can't be empty email: Email can't be empty \"]");

        private static readonly By WarningMsgGenderEmailEmpty =
            By.XPath(
                "//div[contains(@id, 'msg') and normalize-space()=\"gender: Gender can't be empty email: Email can't be empty\"]");

        private static readonly By WarningMsgFirstLastNameEmailEmpty =
            By.XPath(
                "//div[contains(@id, 'msg') and normalize-space()=\"firstName: First Name can't be empty lastName: Last Name can't be empty email: Email has invalid format\"]");

        private static readonly By TextAllFieldsNamesSpecial =
            By.CssSelector(".control-label.col-md-4.text-no-bold.text-login-page");

        private static Dictionary<string, By> GetAllFieldsXPath()
        {
            Dictionary<string, By> fieldsValues = new Dictionary<string, By>();
            fieldsValues["firstName"] = InputFirstName;
            fieldsValues["lastName"] = InputLastName;
            fieldsValues["email"] = InputEmail;
            fieldsValues["mobileNumber"] = InputMobileNumber;
            fieldsValues["landlineNumber"] = InputLandlineNumber;
            fieldsValues["address"] = InputPostalAdress;
            fieldsValues["city"] = InputCity;
            fieldsValues["state"] = InputState;
            fieldsValues["postcode"] = InputPostCode;
            fieldsValues["country"] = InputCountry;
            fieldsValues["company"] = InputCompanyName;

            fieldsValues["male"] = CheckBoxMale;
            fieldsValues["female"] = CheckBoxFemale;

            fieldsValues["flagsMobile"] = DropdownMenuFlagsMobileNumber;
            fieldsValues["flagsLandline"] = DropdownMenuFlagsLandlineNumber;

            return fieldsValues;
        }


        public static void FillFields(Dictionary<string, string> dataFields)
        {
            Helper.FillFields(GetAllFieldsXPath(), dataFields);
        }

        public static bool IsAllFieldsSavedInPopUp(Dictionary<string, string> expectedFields)
        {
            return Helper.IsAllFieldsSavedInPopUp(expectedFields, GetAllFieldsXPath());
        }

        public static void CheckSpecialElements()
        {
            IReadOnlyCollection<IWebElement> fieldsNames = Web.WebDriver.FindElements(TextAllFieldsNamesSpecial);
            Assert.AreEqual(24, fieldsNames.Count, "Quantity of fields names");
        }
        
        public static void ClickButtonCloseButton()
        {
            Web.Click(ButtonCloseButton);
        }

        public static void ClickButtonCloseButtonCross()
        {
            Web.ClickWithActions(ButtonCloseButtonCross);
        }

        public static void ClickButtonInvite()
        {
            Web.Click(ButtonInvite);
        }
  
    }
}
