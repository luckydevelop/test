using OpenQA.Selenium;
using System.Threading;


namespace Kliiko.Ui.Tests.WebPages.Blocks
{
    class Validation : WebPage
    {
        private static readonly By ValidationOk = By.XPath("//*[@class='message animated ok fadeOutDown']");

        public static bool CheckValidation(string tab)
        {
            Thread.Sleep(3000);
            switch (tab)
            {
                case "Topic Create":
                    return Web.WebDriver.PageSource.Contains("New Topic has been added");
                    break;
                case "Topic Edit":
                    return Web.WebDriver.PageSource.Contains("Topic name changed");
                    break;
                case "Topic Delete":
                    return Web.WebDriver.PageSource.Contains("Topic has been removed");
                    break;
                case "Survey":
                    return Web.WebDriver.PageSource.Contains("Successfully created survey!");
                    break;

                default:
                    return false;
                    break;
            }
        }
    }
}
