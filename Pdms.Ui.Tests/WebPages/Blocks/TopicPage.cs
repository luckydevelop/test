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
//    class TopicPage : WebPage
//    {    
//        private static readonly By LABEL_TOPICS = By.XPath("//*[@class='text-center']");
//        private static readonly By BUTTON_CREATE_NEW = By.XPath("(//*[@id='resources-topics']//*[@ng-click='topics.createNew()'])[2]");
//        private static readonly By BUTTON_CREATE_NEW2 = By.XPath("(//*[@id='resources-topics']//*[@ng-click='topics.createNew()'])[1]");
//        private static readonly By LABEL_CREATE_NEW_TOPIC = By.XPath("//*[@id='createNewTopic']//*[@class='modal-title text-center']");
//        private static readonly By BUTTON_CANCEL = By.XPath("//*[@id='createNewTopic']//*[@class='pull-left btn-standart btn-red']");
//        private static readonly By BUTTON_CREATE = By.XPath("//*[@id='createNewTopic']//*[@class='pull-right btn-standart btn-green']");
//        private static readonly By INPUT_TOPIC_NAME = By.XPath("//*[@id='createNewTopic']//*[@id='new-topic-input']");
//        private static readonly By VALIDATION_OK = By.XPath("//*[@class='message animated ok fadeOutDown']");
//        private static readonly By VALIDATION_COUNT = By.XPath("//*[@id='new-topic-input-help']");
//        private static readonly By VALIDATION_COUNT_EDIT = By.XPath("//*[@ng-if='topics.editBlockHelper == $index']");

//        public static void ExpectWebElements()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(LABEL_TOPICS));
//        }
//        public static void ExpectWebElementsCreate()
//        {
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(INPUT_TOPIC_NAME));
//            Web.WaitUntil(ExpectedConditions.ElementIsVisible(BUTTON_CREATE));
//        }
//        public static void FillNewTopic(object data)
//        {
//            string topicName = WebApplication.GetFieldDataFromDynamicClass(data, "Topic");
//            Web.TypeNewText(INPUT_TOPIC_NAME, topicName);
//        }
//        public static void ClickOnButtonByRowName(string searchString, string button)
//        {
//            int index = GetTableRowIndexByName(searchString);
//            switch (button)
//            {
//                case "Edit":
//                    ClickEditDynamic(index);
//                    break;
//                case "Delete":
//                    ClickDeleteDynamic(index);
//                    Alert.Accept();
//                    break;
//                default:
//                    Console.WriteLine("No such button");
//                    break;
//            }
//        }

//        public static int GetTableRowIndexByName(string name)
//        {
//            const string tableRow = "//*[@class='ng-scope']//*[@class='panel-heading']";
//            return Web.GetTableRowIndex(tableRow, name);
//        }

//        public static void ClickEditDynamic(int index)
//        {
//            By button = By.XPath("(//*[@id='resources-topics']//*[@title='Edit'])" + "[" + index + "]");
//            Web.Click(button);
//            Thread.Sleep(1000);
//            By rename = By.XPath("(//*[@title='Rename'])" + "[" + index + "]");
//            Web.Click(rename);
//        }
//        public static void ClickDeleteDynamic(int index)
//        {
//            By button = By.XPath("(//*[@title='Delete'])" + "[" + index + "]");
//            Web.Click(button);
//        }

//        public static void ClickNewButton()
//        {
//            Thread.Sleep(1000);
//            Web.Click(Web.FindElement(BUTTON_CREATE_NEW).Displayed ? BUTTON_CREATE_NEW : BUTTON_CREATE_NEW2);
//        }

//        public static void ClickCreate()
//        {
//            Web.Click(BUTTON_CREATE);
//        }

//        public static bool ValidateTopicCount()
//        {
//            string labelCount = " ";
//            if (Web.FindElement(VALIDATION_COUNT).Displayed)
//            {
//                labelCount = Web.FindElement(VALIDATION_COUNT).Text;
//                return labelCount.Contains("0");
//            }
//            else
//            {
//                labelCount = Web.FindElement(VALIDATION_COUNT_EDIT).Text;
//                return labelCount.Contains("0");
//            }
//        } 

//        public static void EditTopic(object data, string searchString)
//        {
//            int index = GetTableRowIndexByName(searchString);
//            string text = WebApplication.GetFieldDataFromDynamicClass(data, "Topic");
//            By EDIT = By.XPath("//*[@maxlength='15']");
//            Web.TypeNewText(EDIT, text);
            

//        }
//    }
//}
