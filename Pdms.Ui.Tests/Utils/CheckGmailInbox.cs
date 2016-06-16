using System;
using System.Threading;
using OpenQA.Selenium;
using Kliiko.Ui.Tests.Selenium;
using NUnit.Framework;

namespace Kliiko.Ui.Tests.Utils
{
    class CheckGmailInbox
    {
        private static readonly By Login = By.Id("Email");
        private static readonly By Next = By.Id("next");
        private static readonly By Password = By.Id("Passwd");
        private static readonly By SignIn = By.Id("signIn");
        private static readonly By ConfirametionLink =
            By.XPath("//a[contains (@href, 'http://insider.kliiko.diatomdemo.com:8080')]");

        private static readonly By Delete = By.XPath(".//*[@id=':5']/div[2]/div[1]/div/div[2]/div[3]/div/div");
        private static readonly By TextEmptyInbox = By.XPath(".//*[@id=':2h']/div[1]/div[2]/div/div/div");

        private static readonly By AccountLogo = By.XPath(".//*[@id='gb']/div[1]/div[1]/div[2]/div[4]/div[1]/a/span");
        private static readonly By LogOut = By.Id("gb_71");
        private static readonly By FooterList = By.Id("footer-list");

        private static string _emailSubjectXPathLocator;


        public static void ClickOnConfirmationEmail(string login, string password, string emailSubject,
            string linkKeyWord)
        {
            OpenTargetEmail(login, password, emailSubject);

            string confirmationLinkXPathLocator = $"//a[contains (@href, '{linkKeyWord}')]";
           // string confirmationLinkXPathLocator = String.Format("//a[contains (@href, '{0}')]", linkKeyWord);
            Log.Info("confirmationLinkXPathLocator -" + confirmationLinkXPathLocator);
            String confirmationAdress = WebApplications.Web.GetAttributeText(By.XPath(confirmationLinkXPathLocator),
                "href");

            WebApplications.Web.Click(Delete);

            WebApplications.Web.Open(confirmationAdress);
            ConfirmToLeave();
        }

        public static void CheckConfirmationEmail(string emailSubject)
        {
            WebApplications.Web.Open("http://gmail.com/");
            _emailSubjectXPathLocator = $"//*[text() ='{emailSubject}']";
            Log.Info("EmailSubjectXPathLocator -" + _emailSubjectXPathLocator);
            WebApplications.Web.Click(By.XPath(_emailSubjectXPathLocator));
            DeleteMailLogOut();
        }

        public static void CheckConfirmationEmailLogIn(string login, string password, string emailSubject)
        {
            OpenTargetEmail(login, password, emailSubject);
            DeleteMailLogOut();
        }

        private static void OpenTargetEmail(string login, string password, string emailSubject)
        {
            WebApplications.Web.Open("http://gmail.com/");
            WebApplications.Web.Type(Login, login);
            WebApplications.Web.Click(Next);
            WebApplications.Web.Type(Password, password);
            WebApplications.Web.Click(SignIn);

            //b[contains (text(), 'Email')]
            
            //span[contains (text(), 'Your Invoice')]
            // _emailSubjectXPathLocator = String.Format("//*[text() ='{0}']", emailSubject);

            if ((emailSubject.Equals("Thank you for the payment")))
            {
                _emailSubjectXPathLocator = $"//span[contains (text(), '{emailSubject}')]";
            }
            else
            {
                _emailSubjectXPathLocator = $"//*[text()= '{emailSubject}']";
            }

            //_emailSubjectXPathLocator = String.Format("//*[text()='{0}']", emailSubject);
            Log.Info("EmailSubjectXPathLocator -" + _emailSubjectXPathLocator);
            Thread.Sleep(1000);
            WebApplications.Web.Click(By.XPath(_emailSubjectXPathLocator));
        }

        private static void DeleteMailLogOut()
        {
            WebApplications.Web.Click(Delete);
            WebApplications.Web.Click(AccountLogo);
            WebApplications.Web.Click(LogOut);
            ConfirmToLeave();
            Assert.True(WebApplications.Web.IsElementVisibleMilliseconds(FooterList, 3000));
        }

        private static void ConfirmToLeave()
        {
            try
            {
                IAlert alert = WebApplications.Web.WebDriver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (NoAlertPresentException e)
            {
                Log.Warn(e.Message);
            }
        }
    }
}
