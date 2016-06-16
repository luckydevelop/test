using System;
using System.Collections.Generic;
using System.Diagnostics;
using Kliiko.Ui.Tests.Utils;
using Kliiko.Ui.Tests.WebPages.StaticPages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.WebPages.PopUp
{
    class ContactDetailsPopUp : WebPage
    {
        private static readonly By InputFirstName = By.Id("firstName");
        private static readonly By InputLastName = By.Id("lastName");
        private static readonly By InputEmail = By.Id("email");
        private static readonly By InputMobileNumber = By.Id("mobile");
        private static readonly By InputLandlineNumber = By.Id("landlineNumber");
        private static readonly By InputAddress = By.Id("postalAddress");
        private static readonly By InputCity = By.Id("city");
        private static readonly By InputState = By.Id("state");
        private static readonly By InputPostCode = By.Id("postCode");
        private static readonly By InputCountry = By.Id("country");
        private static readonly By InputCompanyName = By.Id("companyName");

        private static readonly By RadioMale =
            By.XPath(".//*[@id='contactDetailsModal']/div/div/div[2]/form/div/div/div[1]/div[4]/div/label[1]/input");

        private static readonly By RadioFeMale =
            By.XPath(".//*[@id='contactDetailsModal']/div/div/div[2]/form/div/div/div[1]/div[4]/div/label[2]/input");

        private static readonly By CheckboxNewsLetter = By.Id("reveiveNewsLetters");

        private static readonly By ButtonDone =
            By.XPath(".//*[@id='contactDetailsModal']/div/div/div[2]/form/div/div/div[3]/span/button[3]");

        private static readonly By ButtonCancel =
            By.XPath(".//*[@id='contactDetailsModal']/div/div/div[2]/form/div/div/div[3]/span/button[1]");

        private static readonly By ButtonUpdate =
            By.XPath(".//*[@id='contactDetailsModal']/div/div/div[2]/form/div/div/div[3]/span/button[2]");

        private static readonly By NameFields = By.CssSelector(".control-label.col-md-4.text-no-bold.text-login-page");

        private static readonly By DropDownFlags = By.CssSelector(".selected-flag");

        private static readonly By WarningMsgSuccess =
            By.XPath("//div[contains(text(), 'Contact details updated successfully.')]");

        private static readonly By WarningMsgMobileNumberInvalid =
            By.XPath("//div[contains(text(), 'The mobile number for this country is not valid.')]");

        private static readonly By WarningMsgLandLineNumberInvalid =
            By.XPath("//div[contains(text(), 'The landline number for this country is not valid.')]");
        
        private static readonly By WarningMsgEmptyFirstName = By.XPath("//span[contains(text(), 'First Name can')]");
            //First Name can't be empty

        private static readonly By WarningMsgEmptyLastName = By.XPath("//span[contains(text(), 'Last Name can')]");
            //Last Name can't be empty

        private static readonly By WarningMsgInvalidEmailForamt =
            By.XPath("//span[contains(text(), 'Email has invalid format')]"); //Email has invalid format 

        private static readonly IList<By> ListLocators = new List<By>();
        private static readonly Dictionary<String, By> DictionaryLocatorsMain = new Dictionary<String, By>();
        private static Dictionary<String, By> _dictionaryLocatorsAll = new Dictionary<string, By>();
        private static readonly IList<By> ListWarningsMessages = new List<By>();

        private static Dictionary<String, By> FillDictionaryLocatorsMain()
        {
            DictionaryLocatorsMain.Add("firstName", InputFirstName);
            DictionaryLocatorsMain.Add("lastName", InputLastName);
            DictionaryLocatorsMain.Add("email", InputEmail);
            DictionaryLocatorsMain.Add("male", RadioMale);
            DictionaryLocatorsMain.Add("female", RadioFeMale);
            DictionaryLocatorsMain.Add("mobile", InputMobileNumber);
            DictionaryLocatorsMain.Add("landlineNumber", InputLandlineNumber);
            DictionaryLocatorsMain.Add("postalAddress", InputAddress);
            DictionaryLocatorsMain.Add("city", InputCity);
            DictionaryLocatorsMain.Add("state", InputState);
            DictionaryLocatorsMain.Add("postCode", InputPostCode);
            DictionaryLocatorsMain.Add("country", InputCountry);
            DictionaryLocatorsMain.Add("companyName", InputCompanyName);
            DictionaryLocatorsMain.Add("newsletter", CheckboxNewsLetter);

            return DictionaryLocatorsMain;
        }

        private static Dictionary<String, By> FillDictionaryLocatorsAll()
        {
            if (_dictionaryLocatorsAll.Count == 0)
            {
                _dictionaryLocatorsAll = new Dictionary<string, By>(FillDictionaryLocatorsMain());
                _dictionaryLocatorsAll.Add("done", ButtonDone);
            }

            return _dictionaryLocatorsAll;
        }

        public static void ExpectWebElements()
        {
            Web.ExpectWebElements(new List<By>(FillDictionaryLocatorsAll().Values));

            int quantityAllFields = Web.FindElements(NameFields).Count;
            int quantityFieldsName = Web.FindElements(DropDownFlags).Count;

            Assert.AreEqual(12, quantityAllFields, "Quantity of required fields");
            Assert.AreEqual(2, quantityFieldsName, "Quantity of all fields");
           // Assert.False(Web.IsElementSelected(CheckboxNewsLetter)); check value later when will be access to DB

            HeaderBlock.ExpectedWebElements();
        }

        public static void FillContactDetailsForm(Dictionary<String, String> contactDetailsData)
        {
            foreach (var pair in contactDetailsData)
            {
                if (!pair.Value.Equals("null"))
                {
                    if (pair.Value.Equals("selected"))
                    {
                        //Log.Info("WTF");
                        //Log.Info("DictionaryLocatorsMain - " + "Key - " + pair.Key + "Value - " + DictionaryLocatorsMain[pair.Key].ToString());
                        //Log.Info("pair - " + "Key - " + pair.Key + "Value - " + pair.Value);
                        if (!Web.IsElementSelected(DictionaryLocatorsMain[pair.Key]))
                        {
                            Web.Click(DictionaryLocatorsMain[pair.Key]);
                        }
                    }
                    else if (pair.Value.Equals("clear"))
                    {
                        Web.ClearField(DictionaryLocatorsMain[pair.Key]);
                    }
                    else
                    {
                        Web.TypeNewText(DictionaryLocatorsMain[pair.Key], pair.Value);
                    }
                }
            }
        }

        public static bool IsContactDetailsCorrect(Dictionary<String, String> contactDetailsData)
        {
            Log.StartStep(new StackTrace().GetFrame(0).GetMethod().Name);

            foreach (var pairSource in contactDetailsData)
            {
                if (!pairSource.Value.Equals("null"))
                {
                    try
                    {
                        if (pairSource.Value.Equals("selected"))
                        {
                            Log.Info("WTF - SELCTED");
                            Log.Info("DictionaryLocatorsMain - " + "Key - " + pairSource.Key + "Value - " +
                                     DictionaryLocatorsMain[pairSource.Key]);
                            Log.Info("pairSource - " + "Key - " + pairSource.Key + "Value - " + pairSource.Value);
                            Assert.True(Web.IsElementSelected(DictionaryLocatorsMain[pairSource.Key]),
                                "Should be selected");
                        }
                        else if (pairSource.Value.Equals("clear"))
                        {
                            string fieldValue = Web.GetAttributeText(DictionaryLocatorsMain[pairSource.Key], "value");
                            Log.Info("WTF - CLEAR");
                            Log.Info("ActualFieldValue = " + fieldValue);
                            Log.Info("DictionaryLocatorsMain - Key - " + pairSource.Key + "Value - " +
                                     DictionaryLocatorsMain[pairSource.Key]);
                            Log.Info("pairSource - " + "Key - " + pairSource.Key + "Value - " + pairSource.Value);
                            Assert.AreNotEqual("", fieldValue, "Field should NOT be empty because it is field with ASTERICS");
                        }
                        else
                        {
                            string fieldValue = Web.GetAttributeText(DictionaryLocatorsMain[pairSource.Key], "value");
                            Log.Info("WTF - NEW TEXT");
                            Log.Info("DictionaryLocatorsMain - " + "Key - " + pairSource.Key + "Value - " +
                                     DictionaryLocatorsMain[pairSource.Key]);
                            Log.Info("pairSource - " + "Key - " + pairSource.Key + "Value - " + pairSource.Value);
                            Assert.AreEqual(pairSource.Value, fieldValue, "Values should be equals");
                        }
                    }
                    catch (Exception e)
                    {
                        Log.Error(e.Message);
                        return false;
                    }
                }
            }

            return true;
        }

        
        public static void ClickButtonUpdate()
        {
            Web.Click(ButtonUpdate);
        }

        public static void ClickButtonDone()
        {
            Web.Click(ButtonDone);
        }

        public static void ClickButtonCancel()
        {
            Web.Click(ButtonCancel);
        }

        public static void ClearFieldMobileNumber()
        {
            Web.ClearField(InputMobileNumber);
        }

        public static void ClearFieldLandlineNumber()
        {
            Web.ClearField(InputLandlineNumber);
        }

        public static void FillFieldMobileNumber(String newNumber)
        {
            Web.Type(InputMobileNumber, newNumber);
        }

        public static void FillFieldLandlineNumber(String newNumber)
        {
            Web.Type(InputLandlineNumber, newNumber);
        }

        public static string GetMobileNumberFieldValue()
        {
            return Web.GetAttributeText(InputMobileNumber, "value");
        }

        public static string GetLandlineNumberFieldValue()
        {
           return Web.GetAttributeText(InputLandlineNumber, "value");
        }
        
    }
}
