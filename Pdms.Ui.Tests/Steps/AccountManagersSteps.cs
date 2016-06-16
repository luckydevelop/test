using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Kliiko.Ui.Tests.Selenium;
using Kliiko.Ui.Tests.Utils;
using Kliiko.Ui.Tests.WebPages.Dashboard.AccountProfile;
using Kliiko.Ui.Tests.WebPages.LoggedPages;
using Kliiko.Ui.Tests.WebPages.NotLoggedPages;
using Kliiko.Ui.Tests.WebPages.PopUp;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Kliiko.Ui.Tests.Steps
{
    [Binding]
    public sealed class AccountManagersSteps : TechTalk.SpecFlow.Steps
    {
        [Given(@"User open Add New AccountManager pop-up")]
        public void UserOpenAddNewAccountManagerPop_Up(Table table)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            var dataTable = Helper.ToDataTable(table);

            Given($"User starts new browser session and opens home page");
            Given($"User logs in");
            foreach (DataRow row in dataTable.Rows)
            {
                Given($"User clicks on '{row.ItemArray[0].ToString()}' button on '{row.ItemArray[1].ToString()}'");
                Given($"Page '{row.ItemArray[2].ToString()}' loads");
            }
        }

        [Given(@"User fills fields on '(.*)' page")]
        public void UserFillsFieldsOnPage(string pageName, Table table)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            Dictionary<string, string> expectedData = Helper.ToDictionary(table);
            if (expectedData.ContainsKey("mobileNumber"))
            {
                string code = "+" + Regex.Match(expectedData["phoneCode"], @"\d+").Value + " ";
                expectedData["mobileNumber"] = code + expectedData["mobileNumber"];
            }
            if (expectedData.ContainsKey("landlineNumber"))
            {
                string code = "+" + Regex.Match(expectedData["phoneCode"], @"\d+").Value + " ";
                expectedData["landlineNumber"] = code + expectedData["landlineNumber"];
            }
            ScenarioContext.Current["expectedData"] = expectedData;
            ScenarioContext.Current["email"] = expectedData["email"];
            string methodName = "FillFields";
            Helper.InvokeClassMethodReturnValueWithParameterReflection(pageName, methodName, expectedData);
        }

        [Given(@"User edit ALL fields on '(.*)' page")]
        public void GivenUserEditALLFieldsOnPage(string pageName, Table table)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            Dictionary<string, string> expectedData = Helper.ToDictionary(table);
            string methodName = "ClearFields";
            Helper.InvokeClassMethodReturnValueWithParameterReflection(pageName, methodName, expectedData);
            Given($"User fills fields on '{pageName}' page", table);
        }


        [When(@"User fill all fields '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void UserFillAllFields(string firstName, string lastName, string email, string gender, string mobileNumber, string landlineNumber, string phoneCode, string address, string city, string state, string postcode, string country, string company)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            Dictionary<string, string> dataFields = new Dictionary<string, string>();
            dataFields["firstName"] = firstName;
            dataFields["lastName"] = lastName;
            dataFields["email"] = email;
            dataFields["gender"] = gender;
            dataFields["phoneCode"] = phoneCode;
            dataFields["mobileNumber"] = mobileNumber;
            dataFields["landlineNumber"] = landlineNumber;
            dataFields["address"] = address;
            dataFields["city"] = city;
            dataFields["state"] = state;
            dataFields["postcode"] = postcode;
            dataFields["country"] = country;
            dataFields["company"] = company;
            
            ScenarioContext.Current["dataFields"] = dataFields;
            ScenarioContext.Current["email"] = email;
            AddNewAccountManagerPopUp.FillFields(dataFields);
        }
        
        [StepDefinition(@"User fill on '(.*)' asterix fields '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void UserFillOnAsterixFields(string pageName, string firstName, string lastName, string email, string gender)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            Dictionary<string, string> expectedData = new Dictionary<string, string>();
            expectedData["firstName"] = firstName;
            expectedData["lastName"] = lastName;
            expectedData["email"] = email;
            expectedData["gender"] = gender;
           // dataFields["mobileNumber"] = "";
            ScenarioContext.Current["expectedData"] = expectedData;
            ScenarioContext.Current["email"] = email;
            string methodName = "FillFields";
            Helper.InvokeClassMethodReturnValueWithParameterReflection(pageName, methodName, expectedData);
        }


        [When(@"User fill asterix fields '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void UserFillAsterixFields(string firstName, string lastName, string email, string gender)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            Dictionary<string, string> dataFields = new Dictionary<string, string>();
            dataFields["firstName"] = firstName;
            dataFields["lastName"] = lastName;
            dataFields["email"] = email;
            dataFields["gender"] = gender;
            dataFields["mobileNumber"] = "";
            ScenarioContext.Current["dataFields"] = dataFields;
            ScenarioContext.Current["email"] = email;
            AddNewAccountManagerPopUp.FillFields(dataFields);
        }
        
        [StepDefinition(@"New account manager has '(.*)' status")]
        public void NewAccountManagerHasStatus(string expectedStatus)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            string actualStatus = AccountManagersPage.GetManagerStatus((string)ScenarioContext.Current["email"]);
            Assert.AreEqual(expectedStatus, actualStatus);
        }
        
        [StepDefinition(@"All data is saved successfully in table on page '(.*)'")]
        public void AllDataIsSavedSuccessfullyInTableOnPage(string pageName)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            Dictionary<string, string> expectedData = (Dictionary<string, string>)ScenarioContext.Current["expectedData"];
            string methodName = "IsAllDataSavedInTable";
            bool res = (bool)Helper.InvokeClassMethodReturnValueWithParameterReflection(pageName, methodName, expectedData);
            Assert.True(res);
        }

        [StepDefinition(@"All data is correct in '(.*)' pop-up")]
        public void AllDataIsCorrectInPopUp(string pageName)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            Dictionary<string, string> expectedFields = (Dictionary<string, string>)ScenarioContext.Current["expectedData"];
            string methodName = "IsAllFieldsSavedInPopUp";
            bool res = (bool)Helper.InvokeClassMethodReturnValueWithParameterReflection(pageName, methodName, expectedFields);
            Assert.True(res);
        }


        [StepDefinition(@"User clicks on corresponding '(.*)' icon on '(.*)'")]
        public void UserClicksOnCorrespondingIconOn(string iconName, string pageName)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            String methodName = "ClickIcon" + iconName;
            Helper.InvokeClassMethodReturnValueWithParameterReflection(pageName, methodName, (string)ScenarioContext.Current["email"]);
            Log.Info("User clicked on icon - " + iconName);
        }

        [StepDefinition(@"User opens AccountManagers page")]
        public void UserOpensAccountManagersPage()
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            Then($"User logs in");
            Then($"User clicks on '{"AccountManagers"}' button on '{"AccountProfilePage"}'");
            Then($"Page '{"AccountManagersPage"}' loads");
        }
        

        [Then(@"New Account Manager enters password for his new account")]
        public void NewAccountManagerEntersPasswordForHisNewAccount()
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            Then($"Page '{"ConfirmInvitationAccountManagerPage"}' loads");
            Then($"User fill '{"Password"}' field with '{"qwerty123"}' on '{"ConfirmInvitationAccountManagerPage"}'");
            Then($"User clicks on '{"Accept"}' button on '{"ConfirmInvitationAccountManagerPage"}'");
        }

        [Given(@"User is going edit '(.*)' with email '(.*)'")]
        [StepDefinition(@"User is going remove '(.*)' with email '(.*)'")]
        public void GivenUserIsGoingRemoveWithEmail(string userRole, string email)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            ScenarioContext.Current["email"] = email;
            Log.Info("ScenarioContext.Current[email] = " + ScenarioContext.Current["email"]);
        }

        [Then(@"'(.*)' are removed on '(.*)'")]
        [Then(@"'(.*)' is removed on '(.*)'")]
        public void IsRemovedOn(string userRole, string pageName)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            //string res = AccountManagersPage.GetEmailRowNumber((string)ScenarioContext.Current["email"]);
            string methodName = "GetEmailRowNumber";
            string res = (string)Helper.InvokeClassMethodReturnValueWithParameterReflection(pageName, methodName, (string)ScenarioContext.Current["email"]);
            Assert.AreEqual("-1", res, "Value is -1 when contact with email is removed");
            if (ScenarioContext.Current.ContainsKey("email2"))
            {
                res = (string)Helper.InvokeClassMethodReturnValueWithParameterReflection(pageName, methodName, (string)ScenarioContext.Current["email2"]);
                Assert.AreEqual("-1", res, "Value is -1 when contact with email2 is removed");
            }
        }



    }
}
