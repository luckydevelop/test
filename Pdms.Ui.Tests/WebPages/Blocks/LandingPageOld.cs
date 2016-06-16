//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using Kliiko.Ui.Tests.Environment;
//using System.Threading;
//using TechTalk.SpecFlow;

//namespace Kliiko.Ui.Tests.WebPages.Blocks
//{
//    class LandingPageOld : WebPage
//    {
//        private static readonly By VIDEO = By.XPath("//*[@id='video-placeholder']");
//        private static readonly By BUTTON_PDF = By.XPath("//*[@id='forgot-password']");
//        private static readonly By BUTTON_LETSGO = By.XPath("//*[@href='/dashboard']");

//        public static void ExpectWebElements()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(VIDEO));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_PDF));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_LETSGO));
//        }

//        public static void ClickLetsGo()
//        {
//            Web.Click(BUTTON_LETSGO);
//        }
//    }
//}
