using System;
using System.Collections.Generic;
using Kliiko.Ui.Tests.Utils;
using Kliiko.Ui.Tests.WebPages.StaticPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Kliiko.Ui.Tests.WebPages.LoggedPages
{
    class SelectPlanPage : WebPage
    {
       // private static readonly By CheckboxFreeTrial = By.Id("freeTrial");
        private static readonly By CheckboxFreeTrial = By.XPath(".//*[@id='login']/tbody/tr/td[1]/label");
        private static readonly By CheckboxPaidPlan = By.XPath(".//*[@id='login']/tbody/tr/td[2]/label");
        private static readonly By ButtonLearnMore = By.XPath("html/body/div[5]/div/form/div[2]/div/button[1]");
        private static readonly By ButtonNext = By.XPath("html/body/div[5]/div/form/div[2]/div/button[2]");
        private static readonly By PlaceHolderInstructionTxt = By.XPath("html/body/div[5]/div/p");
        
        private static readonly IList<By> ListLocators = new List<By>();

        public static void ExpectWebElements()
        {
            if (ListLocators.Count == 0) //check
            {
                ListLocators.Add(CheckboxFreeTrial);
                ListLocators.Add(CheckboxPaidPlan);
                ListLocators.Add(ButtonLearnMore);
                ListLocators.Add(ButtonNext);
                ListLocators.Add(PlaceHolderInstructionTxt);
            }

            Web.ExpectWebElements(ListLocators);

            HeaderBlock.ExpectedWebElements();
        }

        public static void ClickNextButton()
        {
            Web.Click(ButtonNext);
        }
        
        public static bool IsSelectedCheckboxFreeTrial()
        {
            Log.Info("IsSelectedCheckboxFreeTrial()" );


            //bool res = Web.IsElementSelected(CheckboxFreeTrial);
            WebDriverWait wait = new WebDriverWait(Web.WebDriver, TimeSpan.FromSeconds(3));
            IWebElement checkBox = wait.Until(ExpectedConditions.ElementExists(CheckboxFreeTrial));

            bool res = checkBox.Selected;
            Log.Info("res = " + res);

            return res;
        }
    }
}
