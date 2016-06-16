using System.Diagnostics;
using Kliiko.Ui.Tests.Environment;
using Kliiko.Ui.Tests.Selenium;
using Kliiko.Ui.Tests.Utils;
using TechTalk.SpecFlow;

namespace Kliiko.Ui.Tests.Steps
{
    [Binding]
    public class ChangePasswordSteps
    {
        [StepDefinition(@"User selects '(.*)' in My Details menu")]
        public void UserSelectsInMyDetailsMenu(string dropDownMenuItem)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            string classNameSimple = "HeaderBlock";
            string methodName ="Select" + dropDownMenuItem;

            Helper.InvokeClassMethodReturnValueReflection(classNameSimple, methodName);
        }

        [Then(@"User receives '(.*)' mail")]
        public void ThenUserReceivesMail(string emailSubject)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock.ToString() + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            string email = Config.Email;
            string password = Config.Password;
            Log.Info("Ok" + "email - " + email + "password - " + password);
            CheckGmailInbox.CheckConfirmationEmailLogIn(email, password, emailSubject);
        }
    }
}