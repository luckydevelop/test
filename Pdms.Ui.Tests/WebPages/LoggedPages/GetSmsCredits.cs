using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.WebPages.LoggedPages
{
    class GetSmsCredits
    {
        private static readonly By IntSmsQuantity = By.XPath(".//*[@id='sms-credits']/span/span/div/div/h4");
        private static readonly By ButtonPurchase = By.CssSelector(".pull-right.btn.btn-addNewElement.btn-green");
        private static readonly By DropdownMenuQuanity = By.XPath(".//*[@id='sms-credits']/span/span/div/div/table/tbody/tr/td[3]/select");
        
    }
}
