using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Kliiko.Ui.Tests.Selenium;
using Kliiko.Ui.Tests.Utils;
using Kliiko.Ui.Tests.WebPages.PopUp;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Kliiko.Ui.Tests.Steps
{
    [Binding]
    class ContactDetailsSteps
    {
        
        [Given(@"User fills contact details form '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void UserFillsContactDetailsForm(string firstName, string lastName, string email, string gender, string mobile, string landlineNumber, string postalAddress, string city, string state, string postCode, string country, string companyName, string newsletter, string warningMessage)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            Log.Info("newsletter is - " + newsletter);
            Dictionary<String, String> contactDetailsData = new Dictionary<String, String>();

            contactDetailsData.Add("firstName", firstName);
            contactDetailsData.Add("lastName", lastName);
            contactDetailsData.Add("email", email);
            if (gender.Equals("male"))
            {
              contactDetailsData.Add("male", "selected");
              contactDetailsData.Add("female", "null");
            }
            else if (gender.Equals("female"))
            {
                contactDetailsData.Add("female", "selected");
                contactDetailsData.Add("male", "null");
            }
            else
            {
                contactDetailsData.Add("female", "null");
                contactDetailsData.Add("male", "null");
            }
            contactDetailsData.Add("mobile", mobile);
            contactDetailsData.Add("landlineNumber", landlineNumber);
            contactDetailsData.Add("postalAddress", postalAddress);
            contactDetailsData.Add("city", city);
            contactDetailsData.Add("state", state);
            contactDetailsData.Add("postCode", postCode);
            contactDetailsData.Add("country", country);
            contactDetailsData.Add("companyName", companyName);
            contactDetailsData.Add("newsletter", newsletter);

            ScenarioContext.Current["contactDetailsData"] = contactDetailsData;
      
            ContactDetailsPopUp.FillContactDetailsForm(contactDetailsData);
        }

        [StepDefinition(@"Validation message is appeared on '(.*)' '(.*)'")]
        public void ValidationMessageIsAppearedOn(string pageName, string message)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            IList<By> warningMsgList = Helper.GetValidationAndWarningMessages(pageName);
            bool res;

            if (message.Contains("*"))
            {
                res = Helper.IsValidationMessagesPresent(message, warningMsgList);
            }
            else
            {
                res = Helper.IsValidationMessagePresent(message, warningMsgList);
            }
            
            try
            {
                Assert.True(res, "Validation message should present");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw e;
            }
        }

        //WTF Question to Artur
        [StepDefinition(@"Warning message is appeared on '(.*)' '(.*)'"), Scope(Tag = "warningWoPause")]
        public void WarningMessageIsAppearedWoPause(string pageName, string message)
        {
            ValidationMessageIsAppearedOn(pageName, message);
        }

        [StepDefinition(@"Warning message is appeared on '(.*)' '(.*)'")]
        public void WarningMessageIsAppearedOn(string pageName, string message)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            IList<By> warningMsgList = Helper.GetValidationAndWarningMessages(pageName);

            bool res = Helper.IsWarningMessagePresent(message, warningMsgList);
            try
            {
                Assert.True(res, "Validation message should present");

            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw e;
            }
        }

        [Then(@"Warning message is appeared")]
        public void WarningMessageIsAppeared(Table table)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " +
                  new StackTrace().GetFrame(0).GetMethod().Name);

            Dictionary<string, string> dictionary = Helper.ToDictionary(table);
            
            IList<By> warningMsgList = Helper.GetValidationAndWarningMessages(dictionary["page"]);

            bool res = Helper.IsMessagePresent(dictionary["message"], warningMsgList,
                Int32.Parse(dictionary["waitMilliseconds"]), Convert.ToBoolean(dictionary["waitDisappear"]));
            Log.Info("res = " + res);
            try
            {
                Assert.True(res, "Validation message should present");

            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw e;
            }
        }

        [Then(@"Contact Details updated")]
        public void ThenContactDetailsUpdated()
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            Dictionary<String, String> contactDetailsData = (Dictionary<String, String>)ScenarioContext.Current["contactDetailsData"];

            bool res = ContactDetailsPopUp.IsContactDetailsCorrect(contactDetailsData);
            Assert.True(res);
        }
        
        [Then(@"Contact Details did not update")]
        public void ThenContactDetailsDidNotUpdate()
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            Dictionary<String, String> contactDetailsData = (Dictionary<String, String>)ScenarioContext.Current["contactDetailsData"];

            bool res = ContactDetailsPopUp.IsContactDetailsCorrect(contactDetailsData);
            Assert.True(res);
        }
        

        [Given(@"User clear '(.*)' field on '(.*)'")]
        public void UserClearFieldOn(string fieldName, string pageName)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            String methodName = "ClearField" + fieldName;
            Helper.InvokeClassMethodReturnValueReflection(pageName, methodName);
            Log.Info("Field " + fieldName + " is clear");
        }


        [Then(@"'(.*)' field on '(.*)' should not be equal '(.*)'")]
        public void FieldOnShouldNotBeEqual(string fieldName, string pageName, string fieldValue)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            string methodName = "Get" + fieldName + "FieldValue";
            string actualFieldValue = (string)Helper.InvokeClassMethodReturnValueReflection(pageName, methodName);
            Log.Info("Expected value is - " + fieldValue + "Actual value is - " +actualFieldValue);
            Assert.AreNotEqual(fieldValue, actualFieldValue, "Check field value");
        }



    }
}
