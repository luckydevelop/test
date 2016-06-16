//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using Kliiko.Ui.Tests.Environment;
//using System.Threading;
//using TechTalk.SpecFlow;
//using Kliiko.Ui.Tests.Selenium;
//using System.Globalization;

//namespace Kliiko.Ui.Tests.WebPages.Blocks
//{
//    class PromotionCodePage : WebPage
//    {
//        private static readonly By LABEL_PROMOTION_CODES = By.XPath("//*[@id='promotion-code-content']//*[@class='text-center']");
//        private static readonly By BUTTON_ADD_PROMOTION = By.XPath("//*[@id='promotion-code-content']//*[@role='button']");
//        private static readonly By CODE_LIST = By.XPath("//*[@class='col-md-12 fixed-bottom-margin']");
//        private static readonly By INPUT_NAME = By.XPath("//*[@role='form']//*[@id='name']");
//        private static readonly By INPUT_START_DATE = By.XPath("(//*[@class='col-md-8']/input[@class='form-control ng-pristine ng-untouched ng-valid ng-isolate-scope ng-valid-date'])[1]");
//        private static readonly By INPUT_END_DATE = By.XPath("(//*[@class='col-md-8']/input[@class='form-control ng-pristine ng-untouched ng-valid ng-isolate-scope ng-valid-date'])[2]");
//        private static readonly By DROPDOWN_DISCOUNT_TYPE = By.XPath("//*[@id='discountType']");
//        private static readonly By INPUT_VALUE = By.XPath("//*[@id='discountValue']");
//        private static readonly By BUTTON_SAVE = By.XPath("(//*[@role='form']//*[@type='button'])[2]");
//        private static readonly By BUTTON_CLOSE = By.XPath("(//*[@role='form']//*[@type='button'])[1]");

//        public static void ExpectWebElements()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(LABEL_PROMOTION_CODES));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_ADD_PROMOTION));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(CODE_LIST));
//        }

//        public static void ExpectWebElementsEdit()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(INPUT_NAME));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(INPUT_START_DATE));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(INPUT_END_DATE));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(DROPDOWN_DISCOUNT_TYPE));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(INPUT_VALUE));
//        }

//        public static void ClickCreateNew()
//        {
//            Web.Click(BUTTON_ADD_PROMOTION);
//        }

//        public static void ClickSave()
//        {
//            Web.Click(BUTTON_SAVE);
//        }
//        public static void FillPromotionForm(object data)
//        {
//            #region [Fields]
//            string name = WebApplication.GetFieldDataFromDynamicClass(data, "PromotionName");
//            string startDate = WebApplication.GetFieldDataFromDynamicClass(data, "StartDate");
//            string endDate = WebApplication.GetFieldDataFromDynamicClass(data, "EndDate");
//            string discountType = WebApplication.GetFieldDataFromDynamicClass(data, "DiscountType");
//            string discountValue = WebApplication.GetFieldDataFromDynamicClass(data, "DiscountValue");
//            #endregion
           
//            startDate = WebApplication.TimeParser(startDate);
//            endDate = WebApplication.TimeParser(endDate);
//            Web.TypeNewText(INPUT_NAME, name);
//          //  Web.TypeNewText(INPUT_START_DATE, startDate);
//            Web.TypeNewText(INPUT_END_DATE, endDate);
//            Web.SelectByValue(DROPDOWN_DISCOUNT_TYPE, discountType);
//            Web.TypeNewText(INPUT_VALUE, discountValue);
//        }
//    }   
//}
