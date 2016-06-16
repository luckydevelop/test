using System;
using System.Collections.Generic;
using System.Linq;
using Kliiko.Ui.Tests.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.WebPages.Dashboard.AccountProfile
{
    //user.kliiko.diatomdemo.com:8080/dashboard#/account-profile/upgrade-plan
    class PlanSelectPage : WebPage
    {

        private static readonly By ActiveStep = By.CssSelector(".ng-binding.step-number");
        private static readonly By StepSelectPlan = By.XPath(".//*[@id='steps-row']/div[1]/span[1]");
        private static readonly By StepConfirmation = By.XPath(".//*[@id='steps-row']/div[2]/span[1]");
        private static readonly By StepSubmitted = By.XPath(".//*[@id='steps-row']/div[3]/span[1]");

        private static readonly By PlanDetailsCommon = By.CssSelector(".row.benefits");
        private static readonly By PlanDetailsDifference = By.CssSelector(".container.plans-table");

        private static readonly By PlansNameListSpecial = By.CssSelector(".ng-binding.list-group-item-heading");
        private static readonly By PlansPriceListSpecial = By.CssSelector(".outline.ng-binding");
        private static readonly By CurrentPlanLabelSpecial = By.CssSelector(".label");
        private static readonly By CurrentPlanNameSpecial = By.XPath("//div[contains(text(), 'CURRENT')]/following::h4");

        private static readonly By ButtonLearnMoreList = By.CssSelector(".btn-dashboard-plans.pull-right.learn");
        private static readonly By ButtonIWantThisPlanList = By.CssSelector(".btn-dashboard-plans.pull-right.want.btn-brown");

        public static void CheckSpecialElements()
        {
            int quantityElements = Web.FindElements(PlansNameListSpecial).Count;
            Assert.AreEqual(3, quantityElements);
            quantityElements = Web.FindElements(ButtonLearnMoreList).Count;
            Assert.AreEqual(3, quantityElements);
            quantityElements = Web.FindElements(ButtonIWantThisPlanList).Count;
            Assert.AreEqual(3, quantityElements);
        }

        public static string GetCurrentPlanName()
        {
            IReadOnlyCollection<IWebElement> currentPlanLabels = Web.WebDriver.FindElements(CurrentPlanLabelSpecial);

            int numberCurrentPlan = -1;

            for (int i = 0; i < currentPlanLabels.Count; i++)
            {
                if (currentPlanLabels.ElementAt(i).Displayed)
                {
                    numberCurrentPlan = i;
                }
            }

            IReadOnlyCollection<IWebElement> currentPlanNames = Web.FindElements(CurrentPlanNameSpecial);

            return currentPlanNames.ElementAt(numberCurrentPlan).Text;
        }

        public static void SelectPlan(string planName)
        {
            IReadOnlyCollection<IWebElement> currentPlanNames = Web.WebDriver.FindElements(CurrentPlanNameSpecial);

            int numberCurrentPlan = -1;

            for (int i = 0; i < currentPlanNames.Count; i++)
            {
                if (currentPlanNames.ElementAt(i).Text.Equals(planName))
                {
                    numberCurrentPlan = i;
                }
            }

            IReadOnlyCollection<IWebElement> currentPlansIWant = Web.FindElements(ButtonIWantThisPlanList);

            currentPlansIWant.ElementAt(numberCurrentPlan).Click();
        }

        public static int GetPlanPrice(string planName)
        {
            IReadOnlyCollection<IWebElement> planNames = Web.WebDriver.FindElements(PlansNameListSpecial);

            int numberTargetPlan = -1;

            for (int i = 0; i < planNames.Count; i++)
            {
                if (planNames.ElementAt(i).Text.Equals(planName))
                {
                    numberTargetPlan = i;
                }
            }

            IReadOnlyCollection<IWebElement> currentPlansPrices = Web.FindElements(PlansPriceListSpecial);

            Log.Info("currentPlansPrice - " + currentPlansPrices.ElementAt(numberTargetPlan).Text);
            string planPriceString = currentPlansPrices.ElementAt(numberTargetPlan).Text.Substring(3);
            Log.Info("Price of plan " + planName + " is " + planPriceString);

            return Int32.Parse(planPriceString);
        }

    }
}
