using System;
using TechTalk.SpecFlow;
using Kliiko.Ui.Tests.Selenium;
using System.Collections.Generic;
using System.Diagnostics;
using Kliiko.Ui.Tests.Utils;
using Kliiko.Ui.Tests.WebPages.NotLoggedPages;
using NUnit.Framework;

namespace Kliiko.Ui.Tests.Steps
{
    [Binding]
    class RegistrationSteps
    {
        [StepDefinition(@"User clicks on '(.*)' button on '(.*)'")]
        public void UserClicksOnButtonOn(string buttonName, string pageName)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            String methodName = "ClickButton" + buttonName;
            Helper.InvokeClassMethodReturnValueReflection(pageName, methodName);
            Log.Info("User clicked on button - " + buttonName);
        }
        
        [StepDefinition(@"User fills registration form '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void UserFillsRegistrationFormEnableEnable(string accountName, string firstName, string lastName, string email, string gender, string mobileNumber, string landlineNumber, string password, string termsConditions, string newsletter, string errormessage)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            Dictionary<String, String> registrationData = new Dictionary<String, String>();//Scenario Context
            registrationData.Add("InputName", accountName);
            registrationData.Add("InputFirstName", firstName);
            registrationData.Add("InputLastName", lastName);
            registrationData.Add("InputEmail", email);
            registrationData.Add("CheckboxMaleFemale", gender);
            registrationData.Add("InputPhone", mobileNumber);
            registrationData.Add("InputLandLineNumber", landlineNumber);
            registrationData.Add("InputPassword", password);
            registrationData.Add("CheckboxTerms", termsConditions);
            registrationData.Add("CheckboxNewsletter", newsletter);
            registrationData.Add("Errormessage", errormessage);

            ScenarioContext.Current["errormessage"] = errormessage;
   
            RegistrationPage.FillRegistrationForm(registrationData);
        }
        

        [Then(@"Validation message is appeared on RegistrationPage")]
        public void ValidationMessageIsAppearedOnRegistrationPage()
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            IList<String> errorsOnThePage = RegistrationPage.GetErrorsOnPage();

            int errorQuantityInt;
            string errorQuantityString = (string)ScenarioContext.Current["errormessage"];
            bool isInt = int.TryParse(errorQuantityString, out errorQuantityInt);

            bool errorOnPageExist;

            if (!isInt)
            {
                Log.Info("1 "+errorQuantityString);
                Log.Info("2 "+errorsOnThePage[0]);

                errorOnPageExist = errorsOnThePage.Contains(errorQuantityString);
            }
            else
            {
                Log.Info("Quantity of errors on the page is - " + errorQuantityInt);
                errorOnPageExist = errorsOnThePage.Count == errorQuantityInt;
            }
            Assert.True(errorOnPageExist);
        }
        

    }
}
