//using Kliiko.Ui.Tests.WebPages.Login;
//using Kliiko.Ui.Tests.MailReader;
//using System;
//using TechTalk.SpecFlow;
//using Kliiko.Ui.Tests.Selenium;
//using Kliiko.Ui.Tests.WebPages;
//using Kliiko.Ui.Tests.WebPages.Blocks;
//using TechTalk.SpecFlow.Assist;

//namespace Kliiko.Ui.Tests.Steps
//{
//    [Binding]
//    class PromotionCodeSteps
//    {
//        [Then(@"filling form with data")]
//        public void ThenFillingFormWithData(Table table)
//        {
//            var data = table.CreateDynamicInstance();
//            PromotionCodePage.FillPromotionForm(data);
//        }

//        [Then(@"saving new promotion code")]
//        public void ThenSavingNewPromotionCode()
//        {
//            PromotionCodePage.ClickSave();
//        }

//        [Then(@"veryfy, that promotion code is saved")]
//        public void ThenVeryfyThatPromotionCodeIsSaved()
//        {
//            ScenarioContext.Current.Pending();
//        }



//    }
//}
