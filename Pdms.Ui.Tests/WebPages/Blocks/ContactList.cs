using OpenQA.Selenium;


namespace Kliiko.Ui.Tests.WebPages.Blocks
{
    class ContactList : WebPage
    {
        private static readonly By ButtonRecruiter = By.XPath("//*[@id='dashboard-contact-lists']//*[@href='#/resources/survey']");

        public static void ExpectWebElements()
        {
            
        }

        public static void ClickRecruiter()
        {
            Web.Click(ButtonRecruiter);
        }
    }
}
