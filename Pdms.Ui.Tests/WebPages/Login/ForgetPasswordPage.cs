using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Kliiko.Ui.Tests.Environment;
using System.Threading;
using TechTalk.SpecFlow;
using Kliiko.Ui.Tests.Selenium;

namespace Kliiko.Ui.Tests.WebPages.Login
{
    class ForgetPasswordPage : WebPage
    {
        private static readonly By INPUT_EMAIL = By.XPath("//*[@id='login']//*[@type='email']");
        private static readonly By BUTTON_SUBMIT = By.XPath("//*[@id='login']//*[@type='submit']");
        private static readonly By ERROR_WRONG_EMAIL = By.XPath("//*[@id='warning-email-password']");

            public static void ExpectWebElements()
            {
                Web.WaitUntil(ExpectedConditions.ElementIsVisible(INPUT_EMAIL));
                Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_SUBMIT));
            }

        public static void TypeInEmail(object data)
        {
            string email = WebApplication.GetFieldDataFromDynamicClass(data, "Email");
            Web.TypeNewText(INPUT_EMAIL, email);
        }
        public static void EmailValidation()
        {
            Web.Validation(ERROR_WRONG_EMAIL);
        }
      
    }
}
