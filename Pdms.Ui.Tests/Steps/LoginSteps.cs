using System;
using System.Diagnostics;
using TechTalk.SpecFlow;
using Kliiko.Ui.Tests.Selenium;
using Kliiko.Ui.Tests.Utils;
using Kliiko.Ui.Tests.WebPages.LoggedPages;
using Kliiko.Ui.Tests.WebPages.NotLoggedPages;
using NUnit.Framework;


namespace Kliiko.Ui.Tests.Steps
{
    [Binding]
    public class TestLoginSteps
    {

        
        [StepDefinition(@"User starts new browser session and opens home page")]
        public void UserStartsNewBrowserSessionAndOpensHomePage()
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() +" "+ new StackTrace().GetFrame(0).GetMethod().Name);
            //WebApplications.ChangeBrowserName("firefox");
            HomePage.OpenUrl();
            HomePage.MaximizeWindow();
            HomePage.ExpectWebElements(); 
        }

        [Given(@"User starts new browser session with Kliiko browser profile and opens home page")]
        public void UserStartsNewBrowserSessionWithKliikoBrowserProfileAndOpensHomePage()
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            WebApplications.ChangeBrowserName("firefox Kliiko");
            HomePage.OpenUrl();
            HomePage.MaximizeWindow();
        }

        [StepDefinition(@"User opens home page")]
        public void WhenUserStartsNewBrowserSessionAndLoadHomePage()
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            HomePage.OpenUrl();
            HomePage.MaximizeWindow();
        }

        [StepDefinition(@"User enters (.*) and (.*)")]
        public void UserEntersAnd(string userName, string password)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() +" "+ new StackTrace().GetFrame(0).GetMethod().Name);
            HomePage.FillUsernamePassword(userName, password);
            HomePage.ClickLoginButton(); 
        }

        [StepDefinition(@"User enters (.*) and (.*)"), Scope(Tag = "plans")]
        public void UserEntersAndUpgradePlan(string userName, string password)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            HomePage.FillUsernamePassword(userName, password);
            HomePage.ClickLoginButton();
            ScenarioContext.Current["userEmail"] = userName;
        }

        [StepDefinition(@"User logs in")]
        public void GivenUserLogsIn()
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            HomePage.FillUsernamePassword("user@insider.com", "qwerty123");
           // HomePage.FillUsernamePassword("kliikoselenium@gmail.com", "qwerty123");
            HomePage.ClickLoginButton();
        }

        [StepDefinition(@"Page '(.*)' is loaded")]
        public void PageIsLoaded(string pageName)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() +" "+ new StackTrace().GetFrame(0).GetMethod().Name);
            Log.Info("Page " + pageName + " SHOULD be loaded");
            string methodName = "ExpectWebElements";    //статик   
            Helper.InvokeClassMethodReturnValueReflection(pageName, methodName);
            Log.Info("Page " + pageName + " IS ALREADY loaded");
       }
        
        [StepDefinition(@"User selects '(.*)' checkbox on '(.*)'")]
        public void UserSelectsOn(string checkBoxName, string pageName)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() +" "+ new StackTrace().GetFrame(0).GetMethod().Name);
            String methodName = "Select" + checkBoxName + "CheckBox";
            Helper.InvokeClassMethodReturnValueReflection(pageName, methodName);
        }
        
        [Given(@"User closes browser session")]
        public void UserClosesBrowserSession()
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() +" "+ new StackTrace().GetFrame(0).GetMethod().Name);
             WebApplications.QuitDriver(); //удалить когда AfterScenario разблакирую
        }
        
        [Given(@"Account name '(.*)' is present in Account Manager")]
        public void GivenAccountNameIsPresentInAccountManager(string accountName)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            Assert.AreEqual(accountName, AccountManagerPage.GetAccountName(), "Account Manager name");
        }

        [StepDefinition(@"User clicks on '(.*)' icon on '(.*)'")]
        public void UserClicksOnIconOn(string iconName, string pageName)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            String methodName = "ClickIcon" + iconName;
            Helper.InvokeClassMethodReturnValueReflection(pageName, methodName);
            Log.Info("User clicked on icon - " + iconName);
        }
        
    }
}
