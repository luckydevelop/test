using System.Collections.Generic;
using System.IO;
using Kliiko.Ui.Tests.Environment;
using Kliiko.Ui.Tests.WebPages.StaticPages;
using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.WebPages.NotLoggedPages
{
    class HomePage : WebPage
    {
        private static readonly By InputEmail = By.Id("email");
        private static readonly By InputPassword = By.Id("password");

        private static readonly By CheckboxRememberMe =
            By.XPath(".//*[@id='login']/form/div/div[1]/div/table/tbody/tr[3]/td[2]/label");

        private static readonly By ButtonLoginKlzii =
            By.CssSelector(".background-yellow.text-font-family-tabs.text-white.text-shadow-gray.btn.login-kliiko-tab");

        private static readonly By ButtonGetKlziiAccount =
            By.CssSelector(".background-green.text-font-family-tabs.text-white.text-center.login-signup-tab");

        private static readonly By ButtonForgotPassword = By.Id("forgot-password");

        private static readonly By ButtonLogin =
            By.CssSelector(
                ".btn.border-yellow.text-brown-light.border-radius-none.background-transp.pull-right.login-btn-size");

        private static readonly By ButtonLoginGoogle = By.XPath("//*[@id='login']//*[@href='/auth/google']");
        private static readonly By ButtonLoginFacebook = By.XPath("//*[@id='login']//*[@href='/auth/facebook']");

        private static readonly By PlaceHolderWelcomeTxt = By.CssSelector(".text-gray-dark.text-center");
        private static readonly By PlaceHolderEmailTxt = By.CssSelector(".text-no-bold.text-login-page");

        private static readonly By PlaceHolderPasswordTxt =
            By.CssSelector(".text-no-bold.text-login-page.text-brown-dark");

        private static readonly By PlaceHolderRememberMeTxt =
            By.CssSelector(".table.table-no-inside-borders.text-left.text-gray-dark.table-v-content-middle>tbody>tr>td");

        //private static readonly By ValidationMsgPassword = By.Id("warning-email-password");

        private static readonly By ValidationMsgPassword1 =
By.XPath("//div[contains(text(), 'Sorry, your Email and Password do not match. Please try again.')]"); //Sorry, your Email and Password do not match. Please try again.

        private static readonly By ValidationMsgPassword2 =
By.XPath("//div[contains(text(), 'Missing credentials')]"); //Sorry, your Email and Password do not match. Please try again.

        private static readonly By ValidationMsgPaswordChanged = By.CssSelector(".text-center.background-yellow>b");
        
        private static readonly By PlaceHolderLogoImg = By.CssSelector(".login-header>a>img");

        private static readonly By PicEmail =
            By.XPath(".//*[@id='login']/form/div/div[1]/div/table/tbody/tr[1]/td[2]/img");

        private static readonly By PicPassword =
            By.XPath(".//*[@id='login']/form/div/div[1]/div/table/tbody/tr[2]/td[2]/img");

        private static readonly IList<By> ListLocators = new List<By>();

        public static void OpenUrl()
        {
            Web.Open(string.Format(Config.HomePage, Path.AltDirectorySeparatorChar ));
           // Web.Open("https://www.klzii.com/login");
        }

        public static void MaximizeWindow()
        {
            Web.MaximizeWindow();
        }

        public static void ExpectWebElements()
        {
            if (ListLocators.Count == 0)
            {
                ListLocators.Add(InputEmail);
                ListLocators.Add(InputPassword);
                ListLocators.Add(CheckboxRememberMe);
                ListLocators.Add(ButtonLoginKlzii);
                ListLocators.Add(ButtonGetKlziiAccount);
                ListLocators.Add(ButtonForgotPassword);
                ListLocators.Add(ButtonLogin);
                ListLocators.Add(ButtonLoginGoogle);
                ListLocators.Add(ButtonLoginFacebook);
                ListLocators.Add(PlaceHolderWelcomeTxt);
                ListLocators.Add(PlaceHolderEmailTxt);
                ListLocators.Add(PlaceHolderPasswordTxt);
                ListLocators.Add(PlaceHolderRememberMeTxt);
                ListLocators.Add(PlaceHolderLogoImg);

                ListLocators.Add(PicEmail);
                ListLocators.Add(PicPassword);
            }

            Web.ExpectWebElements(ListLocators);

            HeaderBlock.ExpectedWebElementsNotLogged();
            FooterBlock.ExpectedWebElements();
        }

        public static void ClickButtonGetKlziiAccount()
        {
            IWebElement buttonLoginKlziiElement = Web.FindElement(ButtonGetKlziiAccount);
            buttonLoginKlziiElement.Click();
        }

        public static void ClickButtonForgotPassword()
        {
            IWebElement buttonForgotPasswordElement = Web.FindElement(ButtonForgotPassword);
            buttonForgotPasswordElement.Click();
        }


        public static string GetPasswordPlaceholderAttribute() //past later
        {
            return Web.GetAttributeText(InputPassword, "placeholder");
        }

        public static string GetEmailPlaceholderAttribute()
        {
            return Web.GetAttributeText(InputEmail, "placeholder");
        }

        public static bool IsPasswordPlaceholderSecure()
        {
            string res = Web.GetAttributeText(InputPassword, "type");

            return res.Equals("password") ? true : false;
        }

        public static void FillUsernamePassword(string userName, string password)
        {
            Web.TypeNewText(InputEmail, userName);
            Web.TypeNewText(InputPassword, password);
        }

        public static void FillPassword(string password)
        {
            Web.TypeNewText(InputPassword, password);
        }

        public static void ClickLoginButton()
        {
            Web.Click(ButtonLogin);
        }

        public static void ClickForgotPasswordButton()
        {
            Web.Click(ButtonForgotPassword);
        }

        public static void ClickRegistrationButton()
        {
            Web.Click(ButtonGetKlziiAccount);
        }

        public static void SelectRemeberMeCheckBox()
        {
            Web.Click(CheckboxRememberMe);
        }
    }
}
