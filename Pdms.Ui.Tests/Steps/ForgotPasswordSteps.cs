using System;
using System.Diagnostics;
using Kliiko.Ui.Tests.Environment;
using TechTalk.SpecFlow;
using Kliiko.Ui.Tests.Selenium;
using Kliiko.Ui.Tests.Utils;
using Kliiko.Ui.Tests.WebPages.NotLoggedPages;

namespace Kliiko.Ui.Tests.Steps
{
    [Binding]
    class ForgotPasswordSteps
    {
        [StepDefinition(@"User fill '(.*)' field with '(.*)' on '(.*)'")]
        public void UserFillFieldWithOn(string fieldName, string value, string pageName)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            String methodName = "FillField" + fieldName;
            Helper.InvokeClassMethodReturnValueWithParameterReflection(pageName, methodName, value);
        }
        
        [Then(@"Page Forgot Password page is re-loaded")]
        public void ThenPageForgotPasswordPageIsRe_Loaded()
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            ForgotPasswordPage.ExpectWebElementsWhenPageReload();
        }

        [Then(@"User receives '(.*)' email and confirm '(.*)'")]
        public void ThenUserReceivesEmailAndConfirm(string emailSubject, string linkKeyWord)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            string email = Config.Email;
            string password = Config.Password; 
            Log.Info(email + " " + password);
            CheckGmailInbox.ClickOnConfirmationEmail(email, password, emailSubject, linkKeyWord);
            FeatureContext.Current["link"] = WebApplications.Web.GetCurrentPage();
            Log.Info("FeatureContext.Current[\"link\"] is " + (string)FeatureContext.Current["link"]);
        }

        [Then(@"User receives '(.*)' email")]
        public void ThenUserReceivesEmail(string emailSubject)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            string email = Config.Email;
            string password = Config.Password;
            Log.StartStep("Ok" + "email - " + email + "password - " + password);
            CheckGmailInbox.CheckConfirmationEmail(emailSubject);
        }

        [When(@"User open confirmation link in browser again")]
        public void WhenUserOpenConfirmationLinkInBrowserAgain()
        {
            WebApplications.Web.Open((string)FeatureContext.Current["link"]);
            //WebApplications.Web.Open("http://insider.kliiko.diatomdemo.com:8080/resetpassword/3a41cb00-03f5-11e6-99b1-93a6b6774226");
        }







        //[Then(@"user click Forget Password button")]
        //public void ClickForgotPasswordButton()
        //{
        //    HomePage.ClickForgotPasswordButton();
        //    ForgetPasswordPage.ExpectWebElements();
        //}

        //[StepDefinition(@"system counts user emails")]
        //public void SaveEmailAmountOriginal()
        //{
        //   // WebApplication.CountEmail();
        //}

        //[Then(@"user types in ""(?:.*)"" email")]
        //public void ThenUserTypeNonExistingEmail(Table table)
        //{
        //    var data = table.CreateDynamicInstance();
        //    ForgetPasswordPage.TypeInEmail(data);
        //}

        //[Then(@"user see validation message")]
        //public void ThenUserSeeValidationMessage_()
        //{
        //    ForgetPasswordPage.EmailValidation();
        //}

        //[StepDefinition(@"system check if user recieved an email")]
        //public void ThenSystemCheckIfUserRecievedAnEmail()
        //{
        //    Assert.IsTrue(WebApplication.CompareEmailCount(), "Must be true");
        //}


    }
}
