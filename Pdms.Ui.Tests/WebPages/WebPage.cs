using Kliiko.Ui.Tests.Selenium;
using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.WebPages
{
    class WebPage
    {
        private static readonly By Video = By.XPath("//*[@id='video-placeholder']");

        public static WebApplication Web
        {
            get {return WebApplications.Web; }
        }
        
        public static void QuitDriver()
        {
            WebApplications.QuitDriver();
        }

        public static void InitializeSession(string userRole)
        {
            Web.AddSession(userRole);
        }

        public static void SwitchToUser(string userRole)
        {
            Web.SwitchTo(userRole);
        }
        
    }
}
