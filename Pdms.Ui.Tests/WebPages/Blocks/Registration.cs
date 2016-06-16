using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Kliiko.Ui.Tests.Environment;
        using System.Threading;
using TechTalk.SpecFlow;
using Kliiko.Ui.Tests.Selenium;

namespace Kliiko.Ui.Tests.WebPages.Blocks
{
    class Registration : WebPage
    {
        private static readonly By INPUT_ACCOUNT_NAME = By.XPath("//*[@id='signup']//*[@name='accountName']");
        private static readonly By INPUT_ACCOUNT_FIRST_NAME = By.XPath("//*[@id='signup']//*[@name='firstName']");
        private static readonly By INPUT_ACCOUNT_LAST_NAME = By.XPath("//*[@id='signup']//*[@name='lastName']");
        private static readonly By INPUT_ACCOUNT_EMAIL = By.XPath("//*[@id='signup']//*[@name='email']");
        private static readonly By CHECKBOX_GENDER_MALE = By.XPath("//*[@id='signup']//*[@for='gender_male']");
        private static readonly By CHECKBOX_GENDER_FEMALE = By.XPath("//*[@id='signup']//*[@for='gender_female']");
        private static readonly By INPUT_ACCOUNT_PHONE = By.XPath("//*[@id='signup']//*[@name='mobile']");
        private static readonly By INPUT_ACCOUNT_LANDLINE_NUMBER = By.XPath("[@name='landlineNumber']");
        private static readonly By INPUT_ACCOUNT_PASSWORD = By.XPath("//*[@id='signup']//*[@name='password']");
        private static readonly By CHECKBOX_TERMS = By.XPath("//*[@id='signup']//*[@for='termsAndConditions']");
        private static readonly By CHECKBOX_NEWSLETTER = By.XPath("[@for='tipsAndUpdate']");
        private static readonly By BUTTON_SUBMIT = By.XPath("//*[@type='submit']");

        public static void ExpectWebElements()
        {
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(INPUT_ACCOUNT_EMAIL));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(INPUT_ACCOUNT_FIRST_NAME));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(INPUT_ACCOUNT_LANDLINE_NUMBER));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(INPUT_ACCOUNT_LAST_NAME));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(INPUT_ACCOUNT_NAME));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(INPUT_ACCOUNT_PASSWORD));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(INPUT_ACCOUNT_PHONE));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(CHECKBOX_GENDER_FEMALE));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(CHECKBOX_GENDER_MALE));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(CHECKBOX_NEWSLETTER));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(CHECKBOX_TERMS));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_SUBMIT));
        }

       

        public static void FillRegistrationForm(object data)
        {
            #region [Fields]
            string accountName = WebApplication.GetFieldDataFromDynamicClass(data, "AccountName");
            string firstName = WebApplication.GetFieldDataFromDynamicClass(data, "FirstName");
            string lastName = WebApplication.GetFieldDataFromDynamicClass(data, "LastName");
            string email = WebApplication.GetFieldDataFromDynamicClass(data, "Email");
            string gender = WebApplication.GetFieldDataFromDynamicClass(data, "Gender");
            string password = WebApplication.GetFieldDataFromDynamicClass(data, "Password");
            #endregion
            Web.TypeNewText(INPUT_ACCOUNT_NAME, accountName);
            Web.TypeNewText(INPUT_ACCOUNT_FIRST_NAME, firstName);
            Web.TypeNewText(INPUT_ACCOUNT_LAST_NAME, lastName);
            Web.TypeNewText(INPUT_ACCOUNT_EMAIL, email);
            if(gender.Contains("Male"))
            {
                Web.Click(CHECKBOX_GENDER_MALE);
            }
            else
            {
                Web.Click(CHECKBOX_GENDER_MALE);
            }
            Web.TypeNewText(INPUT_ACCOUNT_PASSWORD, password);
            Web.Click(CHECKBOX_TERMS);

            
        }
        public static void ClickSubmitButton()
        {
            Web.Click(BUTTON_SUBMIT);
        }

    }
}
