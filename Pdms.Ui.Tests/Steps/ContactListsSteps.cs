using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Kliiko.Ui.Tests.Selenium;
using Kliiko.Ui.Tests.Utils;
using Kliiko.Ui.Tests.WebPages.Dashboard.Resources;
using Kliiko.Ui.Tests.WebPages.PopUp;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Kliiko.Ui.Tests.Steps
{
    [Binding]
    public sealed class ContactListsSteps : TechTalk.SpecFlow.Steps
    {
        [StepDefinition(@"User selects '(.*)' tab")]
        public void GivenUserSelectsTab(string tabName)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            string methodName = "Select"+tabName+"Tab";
            string pageName = "HeaderBlock";
            Helper.InvokeClassMethodReturnValueReflection(pageName, methodName);
        }

        [Given(@"User selects '(.*)' in Add Contact dropdown menu")]
        public void GivenUserSelectsInAddContactDropdownMenu(string menuItem)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            ContactListsPage.SelectManualInput();
        }

        [Given(@"User open Add New Contact pop-up")]
        public void GivenUserOpenAddNewContactPop_Up()
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);

            Given($"User starts new browser session and opens home page");
            Given($"User logs in");
            Given($"User selects '{"Resources"}' tab");
            Given($"Page '{"GalleryPage"}' loads");
            Given($"User clicks on '{"ContactList"}' button on '{"ResourcesBlock"}'");
            Given($"Page '{"ContactListsPage"}' loads");
            Given($"User selects '{"Manual Input"}' in Add Contact dropdown menu");
            Given($"Page '{"AddNewContactPopUp"}' loads");
        }

        [Given(@"User open Contact Lists page")]
        public void GivenUserOpenContactListsPage()
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);

            Given($"User starts new browser session and opens home page");
            Given($"User logs in");
            Given($"User selects '{"Resources"}' tab");
            Given($"Page '{"GalleryPage"}' loads");
            Given($"User clicks on '{"ContactList"}' button on '{"ResourcesBlock"}'");
            Given($"Page '{"ContactListsPage"}' loads");
        }




        [Given(@"User scrolls Contact List page")]
        public void GivenUserScrollsContactListPage()
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            IWebDriver driver = WebApplications.Web.WebDriver;
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            IWebElement table = WebApplications.Web.FindElement(By.XPath(".//*[@id='dashboard-contact-lists-main-table']"));
            string id = "dashboard-contact-lists-main-table";
            string targetString = string.Format("document.getElementById('{0}').scrollLeft += 250", id);
            executor.ExecuteScript(targetString, "");

            WebApplications.Web.ClickWithActions(By.XPath(".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr/td[13]"));
            IWebElement delete = WebApplications.Web.FindElement(By.XPath(".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr/td[13]/span/img[2]"));
            delete.Click();
        }

        //[Given(@"User is going remove '(.*)' with email '(.*)' and '(.*)'")]
        //public void GivenUserIsGoingRemoveWithEmailAnd(string p0, string p1, string p2)
        //{
        //    ScenarioContext.Current.Pending();
        //}


        [Given(@"User is going remove '(.*)' with emails '(.*)' and '(.*)'")]
        public void UserIsGoingRemoveWithEmails(string userRole, string email1, string email2)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            ScenarioContext.Current["email"] = email1;
            ScenarioContext.Current["email2"] = email2;
            Log.Info("ScenarioContext.Current[email1] = " + ScenarioContext.Current["email"]);
            Log.Info("ScenarioContext.Current[email2] = " + ScenarioContext.Current["email2"]);
        }
    }
}
