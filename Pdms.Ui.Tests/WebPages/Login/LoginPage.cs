using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Kliiko.Ui.Tests.Environment;
using System.Threading;
using TechTalk.SpecFlow;

namespace Kliiko.Ui.Tests.WebPages.Login
{
    class LoginPage : WebPage
    {
        private static readonly By INPUT_EMAIL = By.XPath("//*[@id='login']//*[@type='email']");
        private static readonly By INPUT_PASSWORD = By.XPath("//*[@id='login']//*[@type='password']");
        private static readonly By BUTTON_FORGET_PASSWORD = By.XPath("//*[@id='login']//*[@id='forgot-password']");
        private static readonly By BUTTON_LOGIN = By.XPath("//*[@id='login']//*[@type='submit']");
        private static readonly By BUTTON_FACEBOOK = By.XPath("//*[@id='login']//*[@href='/auth/facebook']");
        private static readonly By BUTTON_GOOGLE = By.XPath("//*[@id='login']//*[@href='/auth/google']");
        private static readonly By CHECKBOX_REMEMBER_ME = By.XPath("//*[@id='login']//*[@for='rememberMe']");
        private static readonly By BUTTON_REGISTRATION = By.XPath("//*[@class='background-green text-font-family-tabs text-white text-center login-signup-tab']");
      
        public static void OpenUrl()
        {
            Web.Open(Config.HomePage);
        }

        public static void MaximizeWindow()
        {
            Web.MaximizeWindow();
        }

        public static void ExpectWebElements()
        {
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(INPUT_EMAIL));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(INPUT_PASSWORD));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_FACEBOOK));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_FORGET_PASSWORD));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_GOOGLE));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_LOGIN));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(CHECKBOX_REMEMBER_ME));

        }


        public static void FullUsernamePassword(string userName, string password)
        {
            Web.TypeNewText(INPUT_EMAIL, userName);
            Web.TypeNewText(INPUT_PASSWORD, password);
        }

        public static void ClickLoginButton()
        {
            Web.Click(BUTTON_LOGIN);
        }
        public static void ClickForgotPasswordButton()
        {
            Web.Click(BUTTON_FORGET_PASSWORD);
        }
        public static void ClickRegistrationButton()
        {
            Web.Click(BUTTON_REGISTRATION);
        }
    }
}
