using System;
using System.Collections.Generic;
using Kliiko.Ui.Tests.Utils;
using Kliiko.Ui.Tests.WebPages.StaticPages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.WebPages.NotLoggedPages
{
    class RegistrationPage : WebPage
    {
        private static readonly By InputName = By.Id("account_name");
        private static readonly By InputFirstName = By.Id("first_name");
        private static readonly By InputLastName = By.Id("last_name");
        private static readonly By InputEmail = By.Id("email");
        private static readonly By InputPhone = By.Id("mobilePhone");
        private static readonly By InputLandLineNumber = By.Id("landline_number");
        private static readonly By InputPassword = By.Id("password");

        private static readonly By DropDownListPhone =
            By.XPath(".//*[@id='signup']/div/div/div/form/table/tbody/tr[11]/td[2]/div/div/div");

        private static readonly By DropDownListLineNumber =
            By.XPath(".//*[@id='signup']/div/div/div/form/table/tbody/tr[13]/td[2]/div/div/div");

        private static readonly By CheckboxMale =
            By.XPath(".//*[@id='signup']/div/div/div/form/table/tbody/tr[9]/td[2]/label[1]");

        private static readonly By CheckboxFemale =
            By.XPath(".//*[@id='signup']/div/div/div/form/table/tbody/tr[9]/td[2]/label[2]");

        private static readonly By CheckboxTerms = By.XPath(".//*[@id='signup']/div/div/div/form/div[1]/div[1]/label");

        private static readonly By CheckboxNewsletter =
            By.XPath(".//*[@id='signup']/div/div/div/form/div[1]/div[2]/label");

        private static readonly By ButtonSignUp =
            By.CssSelector(".btn.border-green.border-radius-none.text-green-dark.background-transp");

        private static readonly By PlaceholderRequiredText = By.CssSelector(".pull-right.text-red-dark");

        private static readonly By PlaceholderTermsText =
            By.XPath(".//*[@id='signup']/div/div/div/form/div[1]/div[1]/label");

        private static readonly By PlaceholderNewsletterText =
            By.XPath(".//*[@id='signup']/div/div/div/form/div[1]/div[2]/label");

        private static readonly By ElementsRequiredStars = By.CssSelector(".text-red-dark>h6"); //6
        private static readonly By ElementsFieldsNames = By.CssSelector(".text-no-bold.text-login-page"); //8
        private static readonly By ElementsMaleFemale = By.CssSelector(".checkbox-signup.btn-radius-text"); //2

        private static readonly By WarningMsgNameInvalidFormat =
            By.XPath(".//*[@id='signup']/div/div/div/form/table/tbody/tr[2]/td[2]/span");
            //Name has invalid format /or Name has already been taken

        private static readonly By WarningMsgFirstNameEmpty =
            By.XPath(".//*[@id='signup']/div/div/div/form/table/tbody/tr[4]/td[2]/span"); //First Name can't be empty

        private static readonly By WarningMsgLastNameEmpty =
            By.XPath(".//*[@id='signup']/div/div/div/form/table/tbody/tr[6]/td[2]/span"); //Last Name can't be empty

        private static readonly By WarningMsgEmailInvalidFormat =
            By.XPath(".//*[@id='signup']/div/div/div/form/table/tbody/tr[8]/td[2]/span");
            //Email has invalid format / or Email has already been taken

        private static readonly By WarningMsgGenderEmpty =
            By.XPath(".//*[@id='signup']/div/div/div/form/table/tbody/tr[10]/td[2]/span"); //Gender can't be empty

        private static readonly By WarningMsgInvalidPhoneMobile = By.Id("mobilePhoneError");
            //Invalid phone number format (ex. 1 123456789)

        private static readonly By WarningMsgInvalidPhoneLand = By.Id("landline_number_error");
            //Invalid phone number format (ex. 1 123456789)

        private static readonly By WarningMsgPasswordShort =
            By.XPath(".//*[@id='signup']/div/div/div/form/table/tbody/tr[16]/td[2]/span");
            //Make sure your password is longer than 7 characters

        private static readonly By WarningMsgMustAgreeTerm = By.XPath(".//*[@id='signup']/div/div/div/form/div[1]/span");
            //You must agree to the terms and conditions before register.

        private static readonly IList<By> ListErrorsLocators = new List<By>();
        private static readonly IList<By> ListLocators = new List<By>();

        public static IList<By> GetErrorsLocatorsList()
        {
            if (ListErrorsLocators.Count == 0)
            {
                ListErrorsLocators.Add(WarningMsgNameInvalidFormat);
                ListErrorsLocators.Add(WarningMsgFirstNameEmpty);
                ListErrorsLocators.Add(WarningMsgLastNameEmpty);
                ListErrorsLocators.Add(WarningMsgEmailInvalidFormat);
                ListErrorsLocators.Add(WarningMsgGenderEmpty);
                ListErrorsLocators.Add(WarningMsgInvalidPhoneMobile);
                ListErrorsLocators.Add(WarningMsgInvalidPhoneLand);
                ListErrorsLocators.Add(WarningMsgPasswordShort);
                ListErrorsLocators.Add(WarningMsgMustAgreeTerm);
            }
            return ListErrorsLocators;
        }

        public static IList<string> GetErrorsOnPage()
        {
            IList<string> listErrorsText = new List<string>();
            foreach (var locator in GetErrorsLocatorsList())
            {
                if (Web.IsElementVisibleMilliseconds(locator, 500))
                {
                    String error = Web.GetLocatorText(locator);
                    listErrorsText.Add(error);
                    Log.Info("Error on Registration page is found - " + error);
                }
            }
            return listErrorsText;
        }

        public static void ExpectWebElements()
        {
            if (ListLocators.Count == 0)
            {
                ListLocators.Add(InputName);
                ListLocators.Add(InputFirstName);
                ListLocators.Add(InputLastName);
                ListLocators.Add(InputEmail);
                ListLocators.Add(InputPhone);
                ListLocators.Add(InputLandLineNumber);
                ListLocators.Add(InputPassword);
                ListLocators.Add(DropDownListPhone);
                ListLocators.Add(DropDownListLineNumber);
                ListLocators.Add(CheckboxMale);
                ListLocators.Add(CheckboxFemale);
                ListLocators.Add(CheckboxTerms);
                ListLocators.Add(CheckboxNewsletter);
                ListLocators.Add(ButtonSignUp);
                ListLocators.Add(PlaceholderRequiredText);
                ListLocators.Add(PlaceholderTermsText);
                ListLocators.Add(PlaceholderNewsletterText);
            }

            Web.ExpectWebElements(ListLocators);

            int quantityStars = Web.FindElements(ElementsRequiredStars).Count;
            int quantityFieldsName = Web.FindElements(ElementsFieldsNames).Count;
            int quantityMaleFemale = Web.FindElements(ElementsMaleFemale).Count;

            Assert.AreEqual(6, quantityStars, "Quantity of required fields");
            Assert.AreEqual(8, quantityFieldsName, "Quantity of all fields");
            Assert.AreEqual(2, quantityMaleFemale, "Male and Female checkbox");

            HeaderBlock.ExpectedWebElementsNotLogged();
            FooterBlock.ExpectedWebElements();
        }

        public static void FillRegistrationForm(Dictionary<String, String> registrationData)
        {
            if (!registrationData["InputName"].Equals("null"))
            {
                Web.Type(InputName, registrationData["InputName"]);
            }
            if (!registrationData["InputEmail"].Equals("null"))
            {
                Web.Type(InputEmail, registrationData["InputEmail"]);
            }
            if (!registrationData["InputFirstName"].Equals("null"))
            {
                Web.Type(InputFirstName, registrationData["InputFirstName"]);
            }
            if (!registrationData["InputLastName"].Equals("null"))
            {
                Web.Type(InputLastName, registrationData["InputLastName"]);
            }
            if (!registrationData["InputPhone"].Equals("null"))
            {
                Web.Type(InputPhone, registrationData["InputPhone"]);
            }
            if (!registrationData["InputLandLineNumber"].Equals("null"))
            {
                Web.Type(InputLandLineNumber, registrationData["InputLandLineNumber"]);
            }
            if (!registrationData["InputPassword"].Equals("null"))
            {
                Web.Type(InputPassword, registrationData["InputPassword"]);
            }
            if (registrationData["CheckboxTerms"].Equals("enable"))
            {
                Web.Click(CheckboxTerms);
            }
            if (registrationData["CheckboxNewsletter"].Equals("enable"))
            {
                Web.Click(CheckboxNewsletter);
            }
            if (registrationData["CheckboxMaleFemale"].Equals("male"))
            {
                Web.Click(CheckboxMale);
            }
            if (registrationData["CheckboxMaleFemale"].Equals("female"))
            {
                Web.Click(CheckboxFemale);
            }
        }

        public static void ClickButtonSignUp()
        {
            Web.Click(ButtonSignUp);
        }
    }
}
