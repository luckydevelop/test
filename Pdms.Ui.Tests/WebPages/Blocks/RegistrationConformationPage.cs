using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Kliiko.Ui.Tests.Environment;
using System.Threading;
using TechTalk.SpecFlow;
using Kliiko.Ui.Tests.Selenium;

namespace Kliiko.Ui.Tests.WebPages.Blocks
{
    class RegistrationConformationPage : WebPage
    {
        private static readonly By CHECKBOX_FREE_TRIAL = By.XPath("//*[@id='login']//*[@for='freeTrial']");
        private static readonly By CHECKBOX_PAID_PLAN = By.XPath("//*[@id='login']//*[@for='paidPlan']");
        private static readonly By BUTTON_LEARN_MORE = By.XPath("(//*[@id='login']//*[@type='button'])[1]");
        private static readonly By BUTTON_NEXT = By.XPath("(//div//button)[3]");

        public static void ExpectWebElements()
        {
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(CHECKBOX_FREE_TRIAL));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(CHECKBOX_PAID_PLAN));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_LEARN_MORE));
            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_NEXT));

        }
        public static void ClickNextButton()
        {
            Web.Click(BUTTON_NEXT);
        }
    }
}
