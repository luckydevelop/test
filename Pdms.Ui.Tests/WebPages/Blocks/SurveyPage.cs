//using System;
//using System.CodeDom;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using Kliiko.Ui.Tests.Environment;
//using System.Threading;
//using TechTalk.SpecFlow;
//using Kliiko.Ui.Tests.Selenium;
//using System.Globalization;
//namespace Kliiko.Ui.Tests.WebPages.Blocks
//{
//    class SurveyPage : WebPage
//    {
//        private static readonly By LABEL_SURVEY = By.XPath("//*[@id='survey-content']//*[@class='text-center']");
//        private static readonly By BUTTON_CREATE_NEW = By.XPath("//*[@id='survey-content']//*[@class='btn btn-addNewElement btn-green']");
//        private static readonly By CONTAINER_SURVEY = By.XPath("//*[@id='survey-content']//*[@class='background-green']");
//        private static readonly By LABEL_MANAGE_SURVEY = By.XPath("//*[@id='manageForm']");
//        private static readonly By BUTTON_BACK = By.XPath("(//*[@id='manageForm']//*[@class='btn btn-addNewElement btn-green'])[1]");
//        private static readonly By PANEL_INTRODUCTION = By.XPath("//*[@id='panel-introduction']");
//        private static readonly By BUTTON_QUESTION_ONE_PLUS = By.XPath("(//*[@name='answers']//*[@src='/icons/add_new_list_blue.png'])[1]");
//        private static readonly By BUTTON_QUESTION_TWO_PLUS = By.XPath("(//*[@name='answers']//*[@src='/icons/add_new_list_blue.png'])[2]");
//        #region [Introduction]
//        private static readonly By INTRODUCTION_INPUT_NAME = By.XPath("//*[@id='panel-introduction']//*[@id='surveyName']");
//        private static readonly By INTRODUCTION_INPUT_DESCRIPTION = By.XPath("//*[@id='panel-introduction']//*[@id='description']");
//        private static readonly By INTRODUCTION_VALIDATION_NAME = By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[3]");
//        #endregion
//        #region [Question 1]
//        private static readonly By PANEL_QUESTION_ONE = By.XPath("//*[@id='manageForm']//*[@id='panel-0']");
//        private static readonly By QUESTION_ONE_INPUT_NAME = By.XPath("//*[@id='panel-0']//*[@name='name']");
//        private static readonly By QUESTION_ONE_INPUT_QUESTION = By.XPath("//*[@id='panel-0']//*[@name='question']");
//        private static readonly By QUESTION_ONE_INPUT_ANSWER_ONE = By.XPath("//*[@id='panel-0']//*[@id='answer-0-0']");
//        private static readonly By QUESTION_ONE_INPUT_ANSWER_TWO = By.XPath("//*[@id='panel-0']//*[@id='answer-0-1']");
//        private static readonly By QUESTION_ONE_INPUT_ANSWER_THREE = By.XPath("//*[@id='panel-0']//*[@id='answer-0-2']");
//        private static readonly By QUESTION_ONE_BUTTON_ENABLE = By.XPath("//*[@id='panel-0']//*[@ng-click='sc.changeQuestions(question, object.order)']");
//        private static readonly By QUESTION_ONE_VALDIATION_NAME = By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[9]");
//        private static readonly By QUESTION_ONE_VALIDATION_ANSWER_ONE =By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[15]");
//        private static readonly By QUESTION_ONE_VALIDATION_ANSWER_TWO = By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[18]");
//        #endregion
//        #region [Question 2]
//        private static readonly By PANEL_QUESTION_TWO = By.XPath("//*[@id='manageForm']//*[@id='panel-1']");
//        private static readonly By QUESTION_TWO_INPUT_NAME = By.XPath("//*[@id='panel-1']//*[@id='questionName-1']");
//        private static readonly By QUESTION_TWO_INPUT_QUESTION = By.XPath("//*[@id='panel-1']//*[@name='question']");
//        private static readonly By QUESTION_TWO_INPUT_ANSWER_ONE = By.XPath("//*[@id='panel-1']//*[@id='answer-1-0']");
//        private static readonly By QUESTION_TWO_INPUT_ANSWER_TWO = By.XPath("//*[@id='panel-1']//*[@id='answer-1-1']");
//        private static readonly By QUESTION_TWO_INPUT_ANSWER_THREE = By.XPath("//*[@id='panel-1']//*[@id='answer-1-2']");
//        private static readonly By QUESTION_TWO_BUTTON_ENABLE = By.XPath("//*[@id='panel-1']//*[@ng-click='sc.changeQuestions(question, object.order)']");
//        private static readonly By QUESTION_TWO_VALIDATION_NAME = By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[21]");
//        private static readonly By QUESTION_TWO_VALIDATION_ANSWER_ONE =By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[27]");
//        private static readonly By QUESTION_TWO_VALIDATION_ANSWER_TWO = By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[30]");
//        #endregion
//        #region [Question 3]
//        private static readonly By PANEL_QUESTION_THREE = By.XPath("");
//        #endregion
//        #region [LikeDislke]
//        private static readonly By PANEL_LIKE_DISLIKE = By.XPath("(//*[@id='panel-3']//*[@class='ng-scope'])[1]");
//        private static readonly By LIKE_DISLIKE_INPUT_NAME = By.XPath("//*[@id='panel-3']//*[@id='questionName-3']");
//        private static readonly By LIKE_DISLIKE_INPUT_QUESTION = By.XPath("//*[@id='panel-3']//*[@name='question']");
//        private static readonly By LIKE_DISLIKE_INPUT_ANSWER_ONE = By.XPath("//*[@id='panel-3']//*[@id='answer-3-0']");
//        private static readonly By LIKE_DISLIKE_INPUT_ANSWER_TWO = By.XPath("//*[@id='panel-3']//*[@id='answer-3-1']");
//        private static readonly By LIKE_DISLIKE_BUTTON_ENABLE = By.XPath("//*[@id='panel-3']//*[@ng-click='sc.changeQuestions(question, object.order)']");
//        private static readonly By LIKE_DISLIKE_VALIDATION_NAME = By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[39]");
//        private static readonly By LIKE_DISLIKE_VALIDATION_ANSWER_ONE = By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[48]");
//        private static readonly By LIKE_DISLIKE_VALIDATION_ANSWER_TWO = By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[51]");
//        #endregion
//        #region [Importance]
//        private static readonly By PANEL_IMPORTANCE = By.XPath("//*[@id='panel-4']//*[@class='panel-title']");
//        private static readonly By IMPORTANCE_INPUT_NAME = By.XPath("//*[@id='panel-4']//*[@id='questionName-4']");
//        private static readonly By IMPORTANCE_INPUT_QUESTION = By.XPath("//*[@id='panel-4']//*[@name='question']");
//        private static readonly By IMPORTANCE_ANSWER_ONE = By.XPath("//*[@id='panel-4']//*[@id='answer-4-0']");
//        private static readonly By IMPORTANCE_ANSWER_TWO = By.XPath("//*[@id='panel-4']//*[@id='answer-4-1']");
//        private static readonly By IMPORTANCE_BUTTON_ENABLE = By.XPath("//*[@id='panel-4']//*[@ng-click='sc.changeQuestions(question, object.order)']");
//        private static readonly By IMPORTANCE_VALIDATION_NAME = By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[54]");
//        private static readonly By IMPORTANCE_VALIDATION_ANSWER_ONE = By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[63]");
//        private static readonly By IMPORTANCE_VALIDATION_ANSWER_TWO = By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[66]");
//        #endregion
//        #region [Most Important]
//        private static readonly By PANEL_MOST_IMPORTANT = By.XPath("//*[@id='panel-5']//*[@class='panel-title']");
//        private static readonly By MOST_IMPORTANT_INPUT_NAME = By.XPath("//*[@id='panel-5']//*[@id='questionName-5']");
//        private static readonly By MOST_IMPORTANT_INPUT_QUESTION = By.XPath("//*[@id='panel-5']//*[@name='question']");
//        private static readonly By MOST_IMPORTANT_QUESTION_ONE = By.XPath("//*[@id='panel-5']//*[@id='answer-5-0']");
//        private static readonly By MOST_IMPORTANT_QUESTION_TWO = By.XPath("//*[@id='panel-5']//*[@id='answer-5-0']");
//        private static readonly By MOST_IMPORTANT_BUTTON_ENABLE = By.XPath("//*[@id='panel-5']//*[@ng-click='sc.changeQuestions(question, object.order)']");
//        private static readonly By MOST_IMPORTANT_VALIDATION_NAME = By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[69]");
//        private static readonly By MOST_IMPORTANCE_VALIDATION_ANSWER_ONE = By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[75]");
//        private static readonly By MOST_IMPORTANCE_VALIDATION_ANSWER_TWO = By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[78]");
//        #endregion
//        #region [Interest]
//        private static readonly By PANEL_INTEREST =By.XPath("//*[@id='panel-6']");
//        private static readonly By INTEREST_QUESTION = By.XPath("//*[@id='panel-6']//*[@name='question']");
//        private static readonly By INETEREST_ANSWER = By.XPath("//*[@id='panel-6']//*[@id='answer-6-0']");
//        private static readonly By INTEREST_BUTTON_SUBMIT = By.XPath("//*[@id='panel-6']//*[@ng-click='sc.changeQuestions(question, object.order)']");
//        private static readonly By INTEREST_VALDIATION_NAME = By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[84]");
//        #endregion
//        #region [Prize Draw]
//        private static readonly By PANEL_PRIZE_DRAW = By.XPath("//*[@name='7']");
//        private static readonly By PRIZE_DRAW_INPUT_QUESTION = By.XPath("//*[@name='7']//*[@name='question']");
//        private static readonly By PRIZE_DRAW_INPUT_ANSWER = By.XPath("//*[@name='7']//*[@id='answer-7-0']");
//        private static readonly By PRIZE_DRAW_BUTTON_SUBMIT = By.XPath("//*[@name='7']//*[@ng-click='sc.changeQuestions(question, object.order)']");
//        private static readonly By PRIZE_DRAW_VALIDATION_NAME = By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[90]");
//        #endregion
//        #region [Contact Details]
//        private static readonly By PANEL_CONTACT_DETAILS = By.XPath("//*[@name='8']");
//        private static readonly By CONTACT_DETAILS_INPUT_QUESTION = By.XPath("//*[@name='8']//*[@name='question']");
//        private static readonly By CONTACT_DETAILS_INPUT_ANSWER = By.XPath("//*[@name='8']//*[@id='answer-8-0']");
//        private static readonly By CONTACT_DETAILS_INPUT_FIRST_NAME = By.XPath("//*[@name='8']//*[@id='First Name']");
//        private static readonly By CONTACT_DETAILS_INPUT_LAST_NAME = By.XPath("//*[@name='8']//*[@id='Last Name']");
//        private static readonly By CONTACT_DETAILS_DROP_DOWN_AGE = By.XPath("//*[@name='answers']//*[@id='Gender']");
//        private static readonly By CONTACT_DETAILS_INPUT_AGE = By.XPath("//*[@name='answers']//*[@id='Age']");
//        private static readonly By CONTACT_DETAILS_INPUT_EMAIL = By.XPath("//*[@name='answers']//*[@id='Email']");
//        private static readonly By CONTACT_DETAILS_INPUT_MOBILE = By.XPath("//*[@name='answers']//*[@id='Mobile']");
//        private static readonly By CONTACT_DETAILS_INPUT_LANDLINE = By.XPath("//*[@name='answers']//*[@id='Landline Number']");
//        private static readonly By CONTACT_DETAILS_INPUT_POSTAL_ADDRESS = By.XPath("//*[@name='answers']//*[@id='Postal Address']");
//        private static readonly By CONTACT_DETAILS_INPUT_CITY = By.XPath("[@id='City']");
//        private static readonly By CONTACT_DETAILS_INPUT_STATE = By.XPath("//*[@name='answers']//*[@id='State']");
//        private static readonly By CONTACT_DETAILS_INPUT_POSTAL_CODE = By.XPath("//*[@name='answers']//*[@id='Postcode']");
//        private static readonly By CONTACT_DETAILS_INPUT_COUNTRY = By.XPath("//*[@name='answers']//*[@id='Country']");
//        private static readonly By CONTACT_DETAILS_INPUT_COMPANY_NAME = By.XPath("[@id='Company Name']");
//        private static readonly By CONTACT_DETAILS_BUTTON_LANDLINE = By.XPath("(//*[@ng-if='object.contact']//*[@role='button'])[1]");
//        private static readonly By CONTACT_DETAILS_BUTTON_POSTAL_ADDRESS = By.XPath("(//*[@ng-if='object.contact']//*[@role='button'])[2]");
//        private static readonly By CONTACT_DETAILS_BUTTON_CITY = By.XPath("(//*[@ng-if='object.contact']//*[@role='button'])[3]");
//        private static readonly By CONTACT_DETAILS_BUTTON_STATE = By.XPath("(//*[@ng-if='object.contact']//*[@role='button'])[4]");
//        private static readonly By CONTACT_DETAILS_BUTTON_POSTAL_CODE = By.XPath("(//*[@ng-if='object.contact']//*[@role='button'])[5]");
//        private static readonly By CONTACT_DETAILS_BUTTON_COUNTRY = By.XPath("(//*[@ng-if='object.contact']//*[@role='button'])[6]");
//        private static readonly By CONTACT_DETAILS_BUTTON_COMPANY_NAME = By.XPath("(//*[@ng-if='object.contact']//*[@role='button'])[7]");
//        private static readonly By CONTACT_DETAILS_BUTTON_ENABLE = By.XPath("//*[@id='panel-8']//*[@ng-click='sc.changeQuestions(question, object.order)']");
//        private static readonly By CONTACT_DETAILS_VALDIATION_ANSWER = By.XPath("(//*[@ng-repeat='error in sc.validationErrors'])[96]");
//        #endregion
//        #region [Thanks]
//        private static readonly By PANEL_THANKS = By.XPath("//*[@id='manageForm']//*[@id='panel-thanks']");
//        private static readonly By INPUT_THANKS =By.XPath("//*[@id='panel-thanks']//*[@name='thanks']");
//        private static readonly By BUTTON_PREVIEW = By.XPath("//*[@id='manageForm']//*[@data-target='#previewModal']");
//        private static readonly By BUTTON_FINISH = By.XPath("//*[@id='manageForm']//*[@ng-click='sc.finishManage()']");
//        #endregion
//        #region [Enable Contact Details Fields]

//        public static void EnableLandlineNumber()
//        {
//            Web.Click(CONTACT_DETAILS_BUTTON_LANDLINE);
//        }

//        public static void EnablePostalAddress()
//        {
//            Web.Click(CONTACT_DETAILS_BUTTON_POSTAL_ADDRESS);
//        }

//        public static void EnableCity()
//        {
//            Web.Click(CONTACT_DETAILS_BUTTON_CITY);
//        }

//        public static void EnableState()
//        {
//            Web.Click(CONTACT_DETAILS_BUTTON_STATE);
//        }

//        public static void EnablePostcode()
//        {
//            Web.Click(CONTACT_DETAILS_BUTTON_POSTAL_CODE);
//        }

//        public static void EnableCountry()
//        {
//            Web.Click(CONTACT_DETAILS_BUTTON_COUNTRY);
//        }

//        public static void EnableCompanyName()
//        {
//            Web.Click(CONTACT_DETAILS_BUTTON_COMPANY_NAME);
//        }
//        #endregion
//        #region [Enter fields]

//        public static void FillIntroduction(object data)
//        {
//            string name = WebApplication.GetFieldDataFromDynamicClass(data, "Name");
//            string introduction = WebApplication.GetFieldDataFromDynamicClass(data, "Introduction");
//            Web.TypeNewText(INTRODUCTION_INPUT_NAME, name);
//            Web.TypeNewText(INTRODUCTION_INPUT_DESCRIPTION, introduction);
//        }

//        public static void FillQuestionOne(object data)
//        {
//            string name = WebApplication.GetFieldDataFromDynamicClass(data, "Name");
//            string question = WebApplication.GetFieldDataFromDynamicClass(data, "Question");
//            string answerOne = WebApplication.GetFieldDataFromDynamicClass(data, "Answer1");
//            string answerTwo = WebApplication.GetFieldDataFromDynamicClass(data, "Answer2");
//            string answerThree = WebApplication.GetFieldDataFromDynamicClass(data, "Answer3");
//            Web.TypeNewText(QUESTION_ONE_INPUT_NAME, name);
//            Web.TypeNewText(QUESTION_ONE_INPUT_QUESTION, question);
//            Web.TypeNewText(QUESTION_ONE_INPUT_ANSWER_ONE, answerOne);
//            Web.TypeNewText(QUESTION_ONE_INPUT_ANSWER_TWO, answerTwo);
//            if(Web.IsElementPresent(QUESTION_ONE_INPUT_ANSWER_THREE)) { Web.TypeNewText(QUESTION_ONE_INPUT_ANSWER_THREE, answerThree); }
//            bool result = Web.IsElementPresent(QUESTION_ONE_INPUT_ANSWER_THREE);
//        }

//        public static void FillQuestionTwo(object data)
//        {
//            string name = WebApplication.GetFieldDataFromDynamicClass(data, "Name");
//            string question = WebApplication.GetFieldDataFromDynamicClass(data, "Question");
//            string answerOne = WebApplication.GetFieldDataFromDynamicClass(data, "Answer1");
//            string answerTwo = WebApplication.GetFieldDataFromDynamicClass(data, "Answer2");
//            string answerThree = WebApplication.GetFieldDataFromDynamicClass(data, "Answer3");
//            Web.TypeNewText(QUESTION_TWO_INPUT_NAME, name);
//            Web.TypeNewText(QUESTION_TWO_INPUT_QUESTION, question);
//            Web.TypeNewText(QUESTION_TWO_INPUT_ANSWER_ONE, answerOne);
//            Web.TypeNewText(QUESTION_TWO_INPUT_ANSWER_TWO, answerTwo);
//            if (Web.IsElementDisplayed(QUESTION_TWO_INPUT_ANSWER_THREE)) { Web.TypeNewText(QUESTION_TWO_INPUT_ANSWER_THREE, answerThree); }
//        }
//        public static void FillLikeDislike(object data)
//        {
//            string name = WebApplication.GetFieldDataFromDynamicClass(data, "Name");
//            string question = WebApplication.GetFieldDataFromDynamicClass(data, "Question");
//            string answerOne = WebApplication.GetFieldDataFromDynamicClass(data, "Answer1");
//            string answerTwo = WebApplication.GetFieldDataFromDynamicClass(data, "Answer2");
//            Web.TypeNewText(LIKE_DISLIKE_INPUT_NAME, name);
//            Web.TypeNewText(LIKE_DISLIKE_INPUT_QUESTION, question);
//            Web.TypeNewText(LIKE_DISLIKE_INPUT_ANSWER_ONE, answerOne);
//            Web.TypeNewText(LIKE_DISLIKE_INPUT_ANSWER_TWO, answerTwo);
//        }
//        public static void FillImportance(object data)
//        {
//            string name = WebApplication.GetFieldDataFromDynamicClass(data, "Name");
//            string question = WebApplication.GetFieldDataFromDynamicClass(data, "Question");
//            string answerOne = WebApplication.GetFieldDataFromDynamicClass(data, "Answer1");
//            string answerTwo = WebApplication.GetFieldDataFromDynamicClass(data, "Answer2");
//            Web.TypeNewText(IMPORTANCE_INPUT_NAME, name);
//            Web.TypeNewText(IMPORTANCE_INPUT_QUESTION, question);
//            Web.TypeNewText(IMPORTANCE_ANSWER_ONE, answerOne);
//            Web.TypeNewText(IMPORTANCE_ANSWER_TWO, answerTwo);
//        }
//        public static void FillMostImportant(object data)
//        {
//            string name = WebApplication.GetFieldDataFromDynamicClass(data, "Name");
//            string question = WebApplication.GetFieldDataFromDynamicClass(data, "Question");
//            string answerOne = WebApplication.GetFieldDataFromDynamicClass(data, "Answer1");
//            string answerTwo = WebApplication.GetFieldDataFromDynamicClass(data, "Answer2");
//            Web.TypeNewText(MOST_IMPORTANT_INPUT_NAME, name);
//            Web.TypeNewText(MOST_IMPORTANT_INPUT_QUESTION, question);
//            Web.TypeNewText(MOST_IMPORTANT_QUESTION_ONE, answerOne);
//            Web.TypeNewText(MOST_IMPORTANT_QUESTION_TWO, answerTwo);
//        }

//        public static void FillContactDetails(object data)
//        {
//            string question = WebApplication.GetFieldDataFromDynamicClass(data, "Question");
//            string firstName = WebApplication.GetFieldDataFromDynamicClass(data, "FirstName");
//            string lastName = WebApplication.GetFieldDataFromDynamicClass(data, "LastName");
//            string gender = WebApplication.GetFieldDataFromDynamicClass(data, "Gender");
//            string age = WebApplication.GetFieldDataFromDynamicClass(data, "Age");
//            string email = WebApplication.GetFieldDataFromDynamicClass(data, "Email");
//            string mobile = WebApplication.GetFieldDataFromDynamicClass(data, "Mobile");
//            Web.TypeNewText(CONTACT_DETAILS_INPUT_QUESTION, question);
//            Web.TypeNewText(CONTACT_DETAILS_INPUT_FIRST_NAME, firstName);
//            Web.TypeNewText(CONTACT_DETAILS_INPUT_LAST_NAME, lastName);
//            Web.SelectByValue(CONTACT_DETAILS_DROP_DOWN_AGE, gender); 
//            Web.TypeNewText(CONTACT_DETAILS_INPUT_AGE,age);
//            Web.TypeNewText(CONTACT_DETAILS_INPUT_EMAIL,email);
//            Web.TypeNewText(CONTACT_DETAILS_INPUT_MOBILE, mobile);
//        }

//        public static void FillThanks(object data)
//        {
//            string thanks = WebApplication.GetFieldDataFromDynamicClass(data, "Thanks");
//            string answer = WebApplication.GetFieldDataFromDynamicClass(data, "Answer");
//            Web.TypeNewText(CONTACT_DETAILS_INPUT_ANSWER, answer);
//            Web.TypeNewText(INPUT_THANKS, thanks);
//        }
//        #endregion
//        #region [Common Navigation]
//        public static void ClickCreteNew()
//        {
//            Web.Click(BUTTON_CREATE_NEW);
//        }

//        public static void ClickFinish()
//        {
//            Web.Click(BUTTON_FINISH);
//        }
//        #endregion
//        #region [Expect Web Elements]
//        public static void ExpectWebElements()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(LABEL_SURVEY));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_CREATE_NEW));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(CONTAINER_SURVEY));
//        }
//        public static void ExpectWebElementsCreateNew()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(LABEL_SURVEY));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_CREATE_NEW));
//          //  Web.WaitUntil(ExpectedConditions.ElementIsVisible(CONTAINER_SURVEY));
//        }
//        public static void ExpectWebElementsSurveyCreate()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(PANEL_INTRODUCTION));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(PANEL_QUESTION_ONE));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(PANEL_QUESTION_TWO));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(PANEL_LIKE_DISLIKE));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(PANEL_IMPORTANCE));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(PANEL_MOST_IMPORTANT));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(PANEL_INTEREST));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(PANEL_PRIZE_DRAW));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(PANEL_CONTACT_DETAILS));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(PANEL_THANKS));
//        }

//        public static void ExpectIntroductionValidation()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(INTRODUCTION_VALIDATION_NAME));
//        }
//        public static void ExpectQuestionOneValidation()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(QUESTION_ONE_VALDIATION_NAME));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(QUESTION_ONE_VALIDATION_ANSWER_ONE));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(QUESTION_ONE_VALIDATION_ANSWER_TWO));
//        }
//        public static void ExpectQuestionTwoValidation()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(QUESTION_TWO_VALIDATION_NAME));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(QUESTION_TWO_VALIDATION_ANSWER_ONE));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(QUESTION_TWO_VALIDATION_ANSWER_TWO));
//        }
//        public static void ExpectLikeDislikeValidation()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(LIKE_DISLIKE_VALIDATION_NAME));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(LIKE_DISLIKE_VALIDATION_ANSWER_ONE));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(LIKE_DISLIKE_VALIDATION_ANSWER_TWO));
//        }

//        public static void ExpectImportanceValidation()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(IMPORTANCE_VALIDATION_NAME));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(IMPORTANCE_VALIDATION_ANSWER_ONE));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(IMPORTANCE_VALIDATION_ANSWER_TWO));
//        }

//        public static void ExpectMostImportantValidation()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(MOST_IMPORTANT_VALIDATION_NAME));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(MOST_IMPORTANCE_VALIDATION_ANSWER_ONE));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(MOST_IMPORTANCE_VALIDATION_ANSWER_TWO));
//        }
//        public static void ExpectContactDetailsValidation()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(CONTACT_DETAILS_VALDIATION_ANSWER));        
//        }
//        #endregion
//        #region [Enable Blocks]

//        public static void EnableQuestionOneBlock()
//        {
//            Web.Click(QUESTION_ONE_BUTTON_ENABLE);
//        }

//        public static void EnableQUestionTwoBlock()
//        {
//            Web.Click(QUESTION_TWO_BUTTON_ENABLE);
//        }

//        public static void EnableLikeDislikeBlock()
//        {
//            Web.Click(LIKE_DISLIKE_BUTTON_ENABLE);
//        }

//        public static void EnableImportanceBlock()
//        {
//            Web.Click(IMPORTANCE_BUTTON_ENABLE);
//        }

//        public static void EnableMostImportantBlock()
//        {
//            Web.Click(MOST_IMPORTANT_BUTTON_ENABLE);
//        }

//        public static void EnableInterestBlock()
//        {
//            Web.Click(INTEREST_BUTTON_SUBMIT);
//        }

//        public static void EnablePrizeDrawBlock()
//        {
//            Web.Click(PRIZE_DRAW_BUTTON_SUBMIT);
//        }

//        public static void EnableContactDetailsBlock()
//        {
//            Web.Click(CONTACT_DETAILS_BUTTON_ENABLE);
//        }

//        public static void EnableBlockByName(string name)
//        {
//            switch (name)
//            {
//                case "Question One":
//                    EnableQuestionOneBlock();
//                    break;
//                case "Question Two":
//                    EnableQUestionTwoBlock();
//                    break;
//                case "Like-Dislike":
//                    EnableLikeDislikeBlock();
//                    break;
//                case "Importance":
//                    EnableImportanceBlock();
//                    break;
//                case "Most Important":
//                    EnableMostImportantBlock();
//                    break;
//                case "Interest":
//                    EnableInterestBlock();
//                    break;
//                case "Prize Draw":
//                    EnablePrizeDrawBlock();
//                    break;
//                case "Contact Details":
//                    EnableContactDetailsBlock();
//                    break;
//            }
//        }
//        #endregion

//        public static void AddQuestions(int block)
//        {
//            switch (block)
//            {
//                case 1:
//                    Web.Click(BUTTON_QUESTION_ONE_PLUS);
//                    break;
//                case 2:
//                    Web.Click(BUTTON_QUESTION_TWO_PLUS);
//                    break;
//            }
//        }
//        public static void EnableSectionByName(string section)
//        {
//            switch (section)
//            {
//                case "Like Dislike":
//                    Web.Click(PANEL_LIKE_DISLIKE);
//                    break;
//                case "Importance":
//                    Web.Click(PANEL_IMPORTANCE);
//                    break;
//                case "Most Important":
//                    Web.Click(PANEL_MOST_IMPORTANT);
//                    break;
//            }
//        }
//        public static void CheckValidation(string panel)
//        {
//            switch (panel)
//            {
//                case "introduction":
//                    ExpectIntroductionValidation();
//                    break;
//                case "Question One":
//                    ExpectQuestionOneValidation();
//                    break;
//                case "Question Two":
//                    ExpectQuestionTwoValidation();
//                    break;
//                case "Like Dislike":
//                    ExpectLikeDislikeValidation();
//                    break;
//                case "Importance":
//                    ExpectImportanceValidation();
//                    break;
//                case "Most Important":
//                    ExpectImportanceValidation();
//                    break;
//                case "Contact Details":
//                    ExpectImportanceValidation();
//                    break;
//            }
//        }
//    }   
//}
