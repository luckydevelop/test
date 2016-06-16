using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.WebPages.Blocks
{
    class Alert : WebPage
    {
        public static void FillIn(string text)
        {
            SwitchToAlert().SendKeys(text);
        }

        public static void Accept()
        {
            SwitchToAlert().Accept();
        }

        private static IAlert SwitchToAlert()
        {
            return Web.WebDriver.SwitchTo().Alert();
        }
    }
}
