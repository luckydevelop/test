using System;
using System.Collections.Generic;
using System.Diagnostics;
using Kliiko.Ui.Tests.Selenium;
using Kliiko.Ui.Tests.Utils;
using Kliiko.Ui.Tests.WebPages.Dashboard.AccountProfile;
using Kliiko.Ui.Tests.WebPages.Others;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Kliiko.Ui.Tests.Steps
{
    [Binding]
    public sealed class UpgradePlanSteps
    {
        [StepDefinition(@"Page '(.*)' loads")]
        public void PageLoads(string pageName)
        {
           Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            Log.Info("Name of page from STEP is - " + pageName);
            bool res = Helper.IsPageLoaded(pageName);
         //  WebApplications.Web.InvokeClassMethodReturnValueReflection(pageName, "CheckSpecialElements");
           Assert.True(res, "Page should be loaded");
        }

        //[Given(@"Page '(.*)' loads"), Scope(Tag = "plans")]
        //public void PageLoadsUpgradePlanFunc(string pageName)
        //{
        //    Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);
        //    bool res = WebApplications.Web.IsPageLoaded(pageName);
        //    Assert.True(res, "Page should be loaded");
        //}
        
        [Given(@"User check Order Summary")]
        public void GivenUserCheckOrderSummary()
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            string planName = (string)ScenarioContext.Current["planNameNew"];
            int planPriceNew = (int)ScenarioContext.Current["planPriceNew"];
            int planPriceOld = (int)ScenarioContext.Current["planPriceOld"];

            PlanConfirmPage.CheckPlanNameCorrect(planName);
            PlanConfirmPage.CheckPriceCorrect(planPriceNew-planPriceOld);
            PlanConfirmPage.CheckOrderTotalCorrect(planPriceNew);
        }

        [StepDefinition(@"User is subcribed for '(.*)' plan")]
        public void GivenUserIsSubcribedForPlan(string expectedPlanName)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            string actualPlanName = "";
            int coefficient = 1;

            if (expectedPlanName.Equals("Fixed 1 year"))
            {
                expectedPlanName = actualPlanName.Substring(0, 4);
                coefficient = 12;
            }

            try
            {
                actualPlanName = PlanSelectPage.GetCurrentPlanName();
                ScenarioContext.Current["planPriceOld"] = PlanSelectPage.GetPlanPrice(actualPlanName) * coefficient;
            }
            catch (Exception e)
            {
                if (expectedPlanName.Equals("None"))
                {
                    ScenarioContext.Current["planPriceOld"] = 0;
                    Log.Info("True. User did not subscribe any plan");
                    return;

                }
                else
                {
                    Log.Error(e.Message);
                    throw e;
                }
            }

            Assert.AreEqual(expectedPlanName, actualPlanName, "plans should be equal");
        }
        
        [Given(@"User selects '(.*)' plan for '(.*)' USD")]
        public void UserSelectsPlan(string newPlanName, int planPrice)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            PlanSelectPage.SelectPlan(newPlanName);
            Log.Info("Plan selected successfully");

            ScenarioContext.Current["planPrice"] = planPrice;
            ScenarioContext.Current["planName"] = newPlanName;
        }

        [Given(@"User selects '(.*)' plan")]
        public void GivenUserSelectsPlan(string newPlanName)
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);

            int planPrice = PlanSelectPage.GetPlanPrice(newPlanName);
            ScenarioContext.Current["planPriceNew"] = planPrice;
            ScenarioContext.Current["planNameNew"] = newPlanName;

            PlanSelectPage.SelectPlan(newPlanName);
            Log.Info("Plan selected successfully");
            
        }




        [Given(@"User check Order Summary and Account Information")]
        public void GivenUserCheckOrderSummaryAndAccountInformation()
        {
            Log.StartStep(ScenarioContext.Current.CurrentScenarioBlock + " " + new StackTrace().GetFrame(0).GetMethod().Name);
            Log.Info("Check now Key planNameNew ");
            string planName = (string)ScenarioContext.Current["planNameNew"];
            Log.Info("Check now Key planPriceNew ");
            int planPrice = (int)ScenarioContext.Current["planPriceNew"];
            Log.Info("Check now Key userEmail ");
            string expectedEmail = (string)ScenarioContext.Current["userEmail"];

            CheckOutPage.CheckPlanNameCorrect(planName + " Plan");
            CheckOutPage.CheckOrderTotalCorrect(planPrice);
            CheckOutPage.CheckPriceCorrect(planPrice);
            
            string actualEmail = CheckOutPage.GetActualEmail();

            Assert.AreEqual(expectedEmail, actualEmail);
            
        }


        [Given(@"User fill Payment Method Information with '(.*)' data")]
        public void GivenUserFillPaymentMethodInformationWithData(string isValidData)
        {
            CheckOutPage.InputFirstName("insider");
            CheckOutPage.InputLastName("user");
            if (isValidData.Equals("INVALID"))
            {
                CheckOutPage.SelectInvalidCardNumber();
            }
            else
            {
                CheckOutPage.SelectValidCardNumber();
            }
            
        }





    }
}
