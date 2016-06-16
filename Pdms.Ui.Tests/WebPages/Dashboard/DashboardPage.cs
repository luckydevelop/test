//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using Kliiko.Ui.Tests.Environment;
//using System.Threading;
//using System.Xml.Serialization;
//using TechTalk.SpecFlow;
//using NUnit.Framework;

//namespace Kliiko.Ui.Tests.WebPages.Content_Pages
//{
//    class Dashboard : WebPage
//    {
//        private static readonly By BUTTON_TOURVIDEO = By.XPath("(//div//button)[1]");
//        private static readonly By BUTTON_HELP = By.XPath("(//div//button)[2]");
//        private static readonly By BUTTON_MY_DETAILS = By.XPath("(//div//button)[3]");
//        #region [MY DETAILS BUTTONS]
//        private static readonly By BUTTON_CONTACT_DETAILS = By.XPath("//div//*[@class='text-right text-size-dashboard'][1]");
//        private static readonly By BUTTON_CHANGE_PASSWORD = By.XPath("//div//*[@class='text-right text-size-dashboard'][2]");
//        private static readonly By BUTTON_MY_DASHBOARD = By.XPath("//div//*[@class='text-right text-size-dashboard'][3]");
//        private static readonly By BUTTON_PAYMENT_DETAILS = By.XPath("//div//*[@class='text-right text-size-dashboard'][4]");
//        private static readonly By BUTTON_LOGOUT = By.XPath("//div//*[@class='text-right text-size-dashboard'][5]");
//        #endregion
//        private static readonly By BUTTON_ACCOUNT_PROFILE = By.XPath("(//div/ul[@id='nav-tabs-main']/li)[1]");
//        #region [ACCOUNT PROFILE BUTTONS]
//        private static readonly By BUTTON_ACCOUNT_DATABASE = By.XPath("//*[@id='dashboard']//*[@href='#/account-profile/account-database']");
//        private static readonly By BUTTON_PROMOTION_CODES = By.XPath("//*[@id='dashboard']//*[@href='#/account-profile/promotion-code']");
//        private static readonly By BUTTON_UPLOAD_BANNER = By.XPath("//*[@id='dashboard']//*[@href='#/account-profile/banner-messages']");
//        private static readonly By BUTTON_EMAIL_TEMPLATES = By.XPath("//*[@id='dashboard']//*[@href='#/account-profile/account-profile?systemMail=true']");
//        #endregion
//        private static readonly By BUTTON_CHAT_SESSION = By.XPath("(//div/ul[@id='nav-tabs-main']/li)[2]");
//        private static readonly By BUTTON_RESOURCES = By.XPath("(//div/ul[@id='nav-tabs-main']/li)[3]");
//        #region [RESOURCES BUTTONS]
//        private static readonly By BUTTON_GALLERY = By.XPath("//*[@id='dashboard']//*[@href='#/resources/gallery']");
//        private static readonly By BUTTON_CONTACT_LIST = By.XPath("//*[@id='dashboard']//*[@href='#/resources/contact-lists']");
//        private static readonly By BUTTON_TOPICS = By.XPath("//*[@id='dashboard']//*[@href='#/resources/topics']");
//        private static readonly By BUTTON_EMAIL = By.XPath("//*[@href='#/resources/email-templates']");
//        private static readonly By BYTTON_BRAND_COLORS = By.XPath("//*[@id='dashboard']//*[@href='#/resources/brand-colours']");
//        #endregion

//        #region [Expect Web Elements]
//        public static void ExpectWebElements(string role)
//        {
//            switch (role)
//            {
//                case "admin":
//                    ExpectWebElementsCommon();
//                    ExpectWebElementsAdmin();
//                    break;
//                case "user":
//                    ExpectWebElementsCommon();

//                    break;
//                default:
//                    Assert.Fail("Unknown user role detected, pelase add ExpectWebWlements for this role in Dashboard.cs");
//                    break;
//            }   
//        }
//        public static void ExpectWebElementsCommon()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_TOURVIDEO));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_HELP));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_MY_DETAILS));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_ACCOUNT_PROFILE));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_CHAT_SESSION));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_RESOURCES));
//        }
//        public static void ExpectWebElementsAdmin()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_ACCOUNT_DATABASE));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_PROMOTION_CODES));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_UPLOAD_BANNER));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_EMAIL_TEMPLATES));
//        }

//        public static void ExpectWebElementsResources()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_GALLERY));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_CONTACT_LIST));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_TOPICS));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_EMAIL));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BYTTON_BRAND_COLORS));
//        }
//        #endregion

//        #region [Button Navigation]
//        public static void ClickTourVideo()
//        {
//            Web.Click(BUTTON_TOURVIDEO);
//        }
//        public static void ClickHelp()
//        {
//            Web.Click(BUTTON_HELP);
//        }
//        public static void ClickMyDetails()
//        {
//            Web.Click(BUTTON_MY_DETAILS);
//        }
//        public static void ClickContactDetails()
//        {
//            Web.Click(BUTTON_CONTACT_DETAILS);
//        }
//        public static void ClickChangePassword()
//        {
//            Web.Click(BUTTON_CHANGE_PASSWORD);
//        }
//        public static void ClickMyDashboard()
//        {
//            Web.Click(BUTTON_MY_DASHBOARD);
//        }
//        public static void ClickPaymetDetails()
//        {
//            Web.Click(BUTTON_PAYMENT_DETAILS);
//        }
//        public static void ClickLogout()
//        {
//            Web.Click(BUTTON_LOGOUT);
//        }
//        #region [Account profile navigation]
//        public static void ClickAccountProfile()
//        {
//            Web.Click(BUTTON_ACCOUNT_PROFILE);
//        }
//        public static void ClickAccountDatabase()
//        {
//            Web.Click(BUTTON_ACCOUNT_DATABASE);
//        }
//        public static void ClickPromotionCodes()
//        {
//            Web.Click(BUTTON_PROMOTION_CODES);
//        }
//        public static void ClickUploadBanner()
//        {
//            Web.Click(BUTTON_UPLOAD_BANNER);
//        }

//        #endregion
//        #region [Resources navigation]

//        public static void ClickResources()
//        {
//            Web.Click(BUTTON_RESOURCES);
//        }
//        public static void ClickGallery()
//        {
//            Web.Click(BUTTON_GALLERY);
//        }
//        public static void ClickContactList()
//        {
//            Web.Click(BUTTON_CONTACT_LIST);
//        }
//        public static void ClickTopics()
//        {
//            Web.Click(BUTTON_TOPICS);
//        }
//        public static void ClickEmailTemplates()
//        {
//            Web.Click(BUTTON_EMAIL_TEMPLATES);
//        }
//        public static void ClickBranColors()
//        {
//            Web.Click(BYTTON_BRAND_COLORS);
//        }

//        #endregion
//        #endregion
//    }
//}
