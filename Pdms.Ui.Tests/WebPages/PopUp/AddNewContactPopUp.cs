
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Kliiko.Ui.Tests.Selenium;
using Kliiko.Ui.Tests.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Kliiko.Ui.Tests.WebPages.PopUp
{
    class AddNewContactPopUp : WebPage
    {
        private static readonly By InputFirstName = By.XPath(".//*[@id='contactList-addContactManual']//*[@id='firstName']");
        private static readonly By InputLastName = By.XPath(".//*[@id='contactList-addContactManual']//*[@id='lastName']");
        private static readonly By InputEmail = By.XPath(".//*[@id='contactList-addContactManual']//*[@id='email']");
        private static readonly By InputMobileNumber = By.XPath(".//*[@id='contactList-addContactManual']//*[@id='contactListMobile']");
        private static readonly By InputLandlineNumber =By.XPath(".//*[@id='contactList-addContactManual']//*[@id='contactListLandlineNumber']");
        private static readonly By InputPostalAdress =By.XPath(".//*[@id='contactList-addContactManual']//*[@id='postalAddress']");
        private static readonly By InputCity = By.XPath(".//*[@id='contactList-addContactManual']//*[@id='city']");
        private static readonly By InputState = By.XPath(".//*[@id='contactList-addContactManual']//*[@id='state']");
        private static readonly By InputPostCode = By.XPath(".//*[@id='contactList-addContactManual']//*[@id='postCode']");
        private static readonly By InputCountry = By.XPath(".//*[@id='contactList-addContactManual']//*[@id='country']");
        private static readonly By InputCompanyName = By.XPath(".//*[@id='contactList-addContactManual']//*[@id='companyName']");

        private static readonly By CheckBoxMale =
            By.XPath(".//*[@id='contactList-addContactManual']//input[contains(@value, 'male')]");

        private static readonly By CheckBoxFemale =
            By.XPath(".//*[@id='contactList-addContactManual']//input[contains(@value, 'female')]");

        private static readonly By DropdownMenuFlagsMobileNumber =
            By.XPath(".//*[@id='contactList-addContactManual']/div/div/div[2]/ng-include[1]/form/div[1]/div[5]/div/div/div/div");

        private static readonly By DropdownMenuFlagsLandlineNumber =
            By.XPath(".//*[@id='contactList-addContactManual']/div/div/div[2]/ng-include[1]/form/div[1]/div[6]/div/div/div/div");

        private static readonly By ButtonCancelButton =
            By.XPath(".//*[@id='contactList-addContactManual']/div/div/div[2]/ng-include[1]/form/div[3]/div/div");

        private static readonly By ButtonCloseButtonCross =
            By.XPath(".//*[@id='contactList-addContactManual']/div/div/div[1]/button");

        public static readonly By ButtonCreate =
            By.XPath(
                ".//*[@id='contactList-addContactManual']/div/div/div[2]/ng-include[1]/form/div[3]/div/input[1]");

        public static readonly By ButtonUpdate =
    By.XPath(
        ".//*[@id='contactList-addContactManual']/div/div/div[2]/ng-include[1]/form/div[3]/div/input[2]");

        private static readonly By WarningMsgContactAdded =
            By.XPath("//div[contains(text(), 'was added to list')]"); //New contact * was added to list Account Managers

        private static readonly By WarningMsgContactUpdated =
    By.XPath("//div[contains(text(), 'has been updated')]"); //Contact * has been updated


        private static readonly By WarningMsgFirstNameEmpty =
            By.XPath(".//*[@id='contactList-addContactManual']/div/div/div[2]/ng-include[1]/form/div[1]/div[1]/div/span"); //First Name can't be empty

        private static readonly By WarningMsgLastNameEmpty =
       By.XPath(".//*[@id='contactList-addContactManual']/div/div/div[2]/ng-include[1]/form/div[1]/div[2]/div/span"); //Last Name can't be empty

        private static readonly By WarningMsgEmail =
            By.XPath(".//*[@id='contactList-addContactManual']/div/div/div[2]/ng-include[1]/form/div[1]/div[3]/div/span");
        //Email has already been taken //Email has invalid format //Email can't be empty

            private static readonly By WarningMsgGenderEmpty = By.XPath(".//*[@id='contactList-addContactManual']/div/div/div[2]/ng-include[1]/form/div[1]/div[4]/div/div"); //Gender can't be empty

        private static Dictionary<string, By> _actualFields = new Dictionary<string, By>(); 

        private static Dictionary<string, By> GetActualFields()
        {
            if (_actualFields.Count==0)
            {
                _actualFields["firstName"] = InputFirstName;
                _actualFields["lastName"] = InputLastName;
                _actualFields["email"] = InputEmail;
                _actualFields["mobileNumber"] = InputMobileNumber;
                _actualFields["landlineNumber"] = InputLandlineNumber;
                _actualFields["address"] = InputPostalAdress;
                _actualFields["city"] = InputCity;
                _actualFields["state"] = InputState;
                _actualFields["postcode"] = InputPostCode;
                _actualFields["country"] = InputCountry;
                _actualFields["company"] = InputCompanyName;

                _actualFields["male"] = CheckBoxMale;
                _actualFields["female"] = CheckBoxFemale;

                _actualFields["flagsMobile"] = DropdownMenuFlagsMobileNumber;
                _actualFields["flagsLandline"] = DropdownMenuFlagsLandlineNumber;
            }
            
            return _actualFields;
        }

        public static bool IsAllFieldsSavedInPopUp(Dictionary<string, string> expectedFields)
        {
            return Helper.IsAllFieldsSavedInPopUp(expectedFields, GetActualFields());
        }

        public static void FillFields(Dictionary<string, string> fieldsValues)
        {
            Helper.FillFields(GetActualFields(), fieldsValues);
        }

        public static void ClearFields(Dictionary<string, string> fieldsToClear)
        {
            Helper.ClearFields(GetActualFields(), fieldsToClear);
        }

        

        //public static bool IsAllFieldsSaved(Dictionary<string, string> expectedValues, Dictionary<string, By> actualValues)
        //{
        //    foreach (var pair in expectedValues)
        //    {
        //        if (pair.Key.Equals("gender"))
        //        {
        //            if (pair.Value.Equals("male"))
        //            {
        //                bool selected = Web.IsElementSelected(CheckBoxMale);
        //                if (!selected)
        //                {
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                bool selected = Web.IsElementSelected(CheckBoxFemale);
        //                if (!selected)
        //                {
        //                    return false;
        //                }
        //            }
        //        }

        //        else if (pair.Key.Equals("phoneCode"))
        //        {
        //            string fieldValueMoblie = Web.GetAttributeText(DropdownMenuFlagsMobileNumber, "title");
        //            string fieldValueLandline = Web.GetAttributeText(DropdownMenuFlagsLandlineNumber, "title");
        //            if (!fieldValueMoblie.Equals(pair.Value)&&!fieldValueLandline.Equals(pair.Value))
        //            {
        //                return false;
        //            }

        //        }

        //        else 
        //        {
        //            string fieldValue = Web.GetAttributeText(actualValues[pair.Key], "value");
        //            if (!fieldValue.Equals(pair.Value))
        //            {
        //                return false;
        //            }
        //        }


        //    }
        //    return true;
        //}

        public static void ClickButtonCancelButton()
        {
            Web.Click(ButtonCancelButton);
        }

        public static void ClickButtonCloseButtonCross()
        {
            Web.ClickWithActions(ButtonCloseButtonCross);
        }

        public static void ClickButtonCreate()
        {
            Web.Click(ButtonCreate);
        }

        public static void ClickButtonUpdate()
        {
            Web.Click(ButtonUpdate);
        }



        //public static void FillFields(Dictionary<string, string> dataFields)
        //{
        //    foreach (var pair in dataFields)
        //    {
        //        if (!pair.Value.Equals(""))
        //        {
        //            if (pair.Key.Equals("firstName"))
        //            {
        //              Web.Type(InputFirstName, pair.Value);
        //            }
        //            else if (pair.Key.Equals("lastName"))
        //            {
        //              Web.Type(InputLastName, pair.Value);
        //            }
        //            else if (pair.Key.Equals("email"))
        //            {
        //                Web.Type(InputEmail, pair.Value);
        //            }
        //            else if (pair.Key.Equals("gender"))
        //            {
        //                if (pair.Value.Equals("male"))
        //                {
        //                    Web.Click(CheckBoxMale);
        //                }
        //                else
        //                {
        //                    Web.Click(CheckBoxFemale);
        //                }
        //            }
        //            else if (pair.Key.Equals("phoneCode"))
        //            {
        //                string code = "+"+Regex.Match(pair.Value, @"\d+").Value;
        //                Web.Type(InputMobileNumber, code);
        //                Web.ClearField(InputMobileNumber);
        //                Web.Type(InputLandlineNumber, code);
        //                Web.ClearField(InputLandlineNumber);
        //            }
        //            else if (pair.Key.Equals("mobileNumber"))
        //            {
        //                Web.Type(InputMobileNumber, pair.Value);
        //            }
        //            else if (pair.Key.Equals("landlineNumber"))
        //            {
        //                Web.Type(InputLandlineNumber, pair.Value);
        //            }
        //            else if (pair.Key.Equals("address"))
        //            {
        //                Web.Type(InputPostalAdress, pair.Value);
        //            }
        //            else if (pair.Key.Equals("city"))
        //            {
        //                Web.Type(InputCity, pair.Value);
        //            }
        //            else if (pair.Key.Equals("state"))
        //            {
        //                Web.Type(InputState, pair.Value);
        //            }
        //            else if (pair.Key.Equals("postcode"))
        //            {
        //                Web.Type(InputPostCode, pair.Value);
        //            }
        //            else if (pair.Key.Equals("country"))
        //            {
        //                Web.Type(InputCountry, pair.Value);
        //            }
        //            else if (pair.Key.Equals("company"))
        //            {
        //                Web.Type(InputCompanyName, pair.Value);
        //            }

        //        }
        //    }

        //}
        
    }
}
