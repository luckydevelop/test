using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using Kliiko.Ui.Tests.Environment;
using Kliiko.Ui.Tests.Utils;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Kliiko.Ui.Tests.Selenium
{
    public class Helper
    {
        private static WebApplication web = WebApplications.Web;
        private static Type[] _types;

        #region [Messages]
        public static IList<By> GetValidationAndWarningMessages(string pageName)
        {
            IList<By> validationAndWarningMessages = new List<By>();
            string fullClassName = GetFullClassName(pageName);
            Type type = System.Type.GetType(fullClassName); //почему System ?
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.NonPublic | BindingFlags.Static);
            foreach (var fieldInfo in fieldInfos)
            {
                if (fieldInfo.Name.Contains("Msg"))
                {
                    validationAndWarningMessages.Add((By)fieldInfo.GetValue(null));
                    Log.Info("fieldInfo.GetValue = " + (By)fieldInfo.GetValue(null));
                }
            }

            return validationAndWarningMessages;
        }

        public static bool IsValidationMessagePresent(string message, IList<By> listMessages)
        {
            Log.Info(new StackTrace().GetFrame(0).GetMethod().Name);
            return IsMessagePresent(message, listMessages, 500, false);
        }

        public static bool IsValidationMessagesPresent(string message, IList<By> listMessages)
        {
            Log.Info(new StackTrace().GetFrame(0).GetMethod().Name);
            return IsMessagesPresent(message, listMessages, 500, false);
        }

        public static bool IsWarningMessagePresent(string message, IList<By> listMessages)
        {
            return IsMessagePresent(message, listMessages, 500, true);
        }

        public static bool IsMessagePresent(string message, IList<By> listWarningsMessages, int millisecondsWaitMessage, bool waitMessageDisappear)
        {
            Log.Info("string message - " + message);

            foreach (var messages in listWarningsMessages)
            {
                if (web.IsElementVisibleMilliseconds(messages, millisecondsWaitMessage))
                {
                    Log.Info("Next locator IS VISIBLE - " + messages);
                    string locatorText = web.GetLocatorText(messages);
                    Log.Info("Locator text is - " + locatorText + " Text SHOULD be - " + message);
                    if (locatorText.Equals(message))
                    {
                        if (waitMessageDisappear)
                        {
                            web.WaitUntilInVisible(messages);
                        }
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsMessagesPresent(string message, IList<By> AllWarningsMessages, int milliseconds, bool waitMessageDisapear)
        {
            Log.Info("string message - " + message);

            string[] expectedMessagesArray = message.Split('*');
            IList<string> expectedMessagesList = new List<string>(expectedMessagesArray);

            foreach (var expectedMessage in expectedMessagesList)
            {
                Log.Info(expectedMessage);
            }

            foreach (var oneMessage in AllWarningsMessages)
            {
                if (web.IsElementVisibleMilliseconds(oneMessage, milliseconds))
                {
                    Log.Info("Next locator IS VISIBLE - " + oneMessage);
                    string locatorText = web.GetLocatorText(oneMessage);
                    Log.Info("Locator text is - " + locatorText + " Text SHOULD be one of - " + message);
                    if (expectedMessagesList.Contains(locatorText))
                    {
                        if (waitMessageDisapear)
                        {
                            web.WaitUntilInVisible(oneMessage);
                        }
                        expectedMessagesList.Remove(locatorText);
                        // return true;
                    }
                    if (expectedMessagesList.Count == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion

        #region [Reflection Invoke method]

        private static String GetFullClassName(string pageName)
        {
            String res = "null";
            if (_types == null)
            {
                _types = Assembly.GetExecutingAssembly().GetTypes();
            }
            Regex regex = new Regex(@Config.PathPages);

            foreach (Type t in _types)
            {
                string typeTxt = t.ToString();
                Match match = regex.Match(typeTxt);

                if (typeTxt.Contains(pageName))
                {
                    res = typeTxt;
                }
            }

            Log.Info("Full class name is - " + res);
            return res;
        }

        public static object InvokeClassMethodReturnValueReflection(string className, string methodName)
        {
            String classNameFull = GetFullClassName(className);
            Type type = System.Type.GetType(classNameFull);
            Log.Info("Full class name is - " + classNameFull + " Method name is - " + methodName);
            MethodInfo method;
            try
            {
                method = type.GetMethod(methodName);
            }
            catch (Exception e)
            {
                Log.Error("Exception!!! - Thre is not such method in Class " + className);
                throw e;
            }
            Log.Info("Again Full class name is - " + classNameFull + " Method name is - " + methodName);
            return method.Invoke(type, null);
        }

        public static object InvokeClassMethodReturnValueWithParameterReflection(string className, string methodName, String value)
        {
            String classNameFull = GetFullClassName(className);
            Type type = System.Type.GetType(classNameFull);
            Log.Info("Full class name is - " + classNameFull + " Method name is - " + methodName + " Value is - " + value);
            MethodInfo method;
            try
            {
                method = type.GetMethod(methodName);
            }
            catch (Exception e)
            {
                Log.Error("Exception!!! - Thre is not such method in Class " + className);
                throw e;
            }


            return method.Invoke(type, new object[] { value });
        }

        public static object InvokeClassMethodReturnValueWithParameterReflection(string className, string methodName, Dictionary<string, string> dictionary)
        {
            String classNameFull = GetFullClassName(className);
            Type type = System.Type.GetType(classNameFull);
            Log.Info("Full class name is - " + classNameFull + " Method name is - " + methodName);
            MethodInfo method;
            try
            {
                method = type.GetMethod(methodName);
            }
            catch (Exception e)
            {
                Log.Error("Exception!!! - Thre is not such method in Class " + className);
                throw e;
            }


            return method.Invoke(type, new object[] { dictionary });
        }

        #endregion

        #region [Data in table and pop-up]
        public static string GetRowNumber(string expectedEmail, string targetXpath, int rowOrder)
        {
            string rowNumber = "-1";
            int n = 1;
            bool elementVisible = web.IsElementVisible(By.XPath(String.Format(targetXpath, n)));
            Log.Info("bool elementVisible = " + elementVisible + " expectedEmail - " + expectedEmail);

            while (elementVisible)
            {
                string XpathString = String.Format(targetXpath, n);

                // .//*[@id='account-manager-content']/ng-include/div/div/div[2]/table/tbody/tr[2]/td[1]

                IWebElement emailElement = web.FindElementMilliSeconds(By.XPath(XpathString), 100);
                string actualEmail = emailElement.Text;

                Log.Info("actualEmail = " + actualEmail);

                n++;
                elementVisible = web.IsElementVisible(By.XPath(String.Format(targetXpath, n)));

                if (actualEmail.Equals(expectedEmail))
                {
                    rowNumber = XpathString.Substring(rowOrder, 2);
                    bool containsOtherCharacters = rowNumber.Contains("]");
                    if (containsOtherCharacters)
                    {
                        rowNumber = rowNumber.Substring(0, 1);
                    }
                    Log.Info("rowNumber = " + rowNumber);
                    elementVisible = false;
                }

            }
            if (rowNumber.Equals("-1"))
            {
                Log.Info("Row is not known for email - " + expectedEmail);
            }
            return rowNumber;
        }

        public static void FillFields(Dictionary<String, By> fileds, Dictionary<string, string> values)
        {
            foreach (var pair in values)
            {
                if (!pair.Value.Equals(""))
                {
                    if (pair.Key.Equals("firstName"))
                    {
                        web.Type(fileds["firstName"], pair.Value);
                    }
                    else if (pair.Key.Equals("lastName"))
                    {
                        web.Type(fileds["lastName"], pair.Value);
                    }
                    else if (pair.Key.Equals("email"))
                    {
                        web.Type(fileds["email"], pair.Value);
                    }
                    else if (pair.Key.Equals("gender"))
                    {
                        if (pair.Value.Equals("male"))
                        {
                            web.Click(fileds["male"]);
                        }
                        else
                        {
                            web.Click(fileds["female"]);
                        }
                    }
                    else if (pair.Key.Equals("mobileNumber"))
                    {
                        web.ClearField(fileds["mobileNumber"]);
                        web.Type(fileds["mobileNumber"], pair.Value);
                    }
                    else if (pair.Key.Equals("landlineNumber"))
                    {
                        web.ClearField(fileds["landlineNumber"]);
                        web.Type(fileds["landlineNumber"], pair.Value);
                    }
                    else if (pair.Key.Equals("address"))
                    {
                        web.Type(fileds["address"], pair.Value);
                    }
                    else if (pair.Key.Equals("city"))
                    {
                        web.Type(fileds["city"], pair.Value);
                    }
                    else if (pair.Key.Equals("state"))
                    {
                        web.Type(fileds["state"], pair.Value);
                    }
                    else if (pair.Key.Equals("postcode"))
                    {
                        web.Type(fileds["postcode"], pair.Value);
                    }
                    else if (pair.Key.Equals("country"))
                    {
                        web.Type(fileds["country"], pair.Value);
                    }
                    else if (pair.Key.Equals("company"))
                    {
                        web.Type(fileds["company"], pair.Value);
                    }

                }
            }
        }

        public static void ClearFields(Dictionary<String, By> fieldsXPath, Dictionary<string, string> fieldsToClear)
        {
            foreach (var pair in fieldsToClear)
            {

                if (!pair.Key.Equals("gender") && !pair.Key.Equals("phoneCode"))
                {
                    Log.Info("Current Key is - " + pair.Key);
                    web.ClearField(fieldsXPath[pair.Key]);
                }
            }
        }

        public static bool IsAllDataSavedInTable(Dictionary<string, string> expectedData, Dictionary<string, string> actualDataXPath, string rowNumber)
        {

            foreach (var pair in expectedData)
            {
                Log.Info("Curent key is - " + pair.Key);
                string actualValue =
                    web.GetLocatorText(By.XPath(String.Format(actualDataXPath[pair.Key], rowNumber)));
                try
                {
                    Log.Info("!!!! - expectedValue - " + pair.Value);
                }
                catch (Exception e)
                {
                    Log.Info("Next pair.Key is absent in actualDataXPath[pair.Key]" + pair.Key);
                    throw e;
                }

                string expectedValue = pair.Value;
                if (pair.Key.Equals("mobileNumber") || pair.Key.Equals("landlineNumber"))
                {
                    int spaceIndex = expectedValue.IndexOf(" ");
                    expectedValue = expectedValue.Remove(spaceIndex) + expectedValue.Substring(spaceIndex + 1);
                }

                bool res = actualValue.Equals(expectedValue);
                Log.Info("res = " + res + " expectedValue  = " + expectedValue + "///  actualValue = " + actualValue);
                if (!res)
                {
                    return false;
                }

            }

            return true;
        }

        public static bool IsAllFieldsSavedInPopUp(Dictionary<string, string> expectedValues, Dictionary<string, By> actualValues)
        {
            foreach (var pair in expectedValues)
            {
                if (pair.Key.Equals("gender"))
                {
                    if (pair.Value.Equals("male"))
                    {
                        bool selected = web.IsElementSelected(actualValues["male"]);
                        if (!selected)
                        {
                            return false;
                        }
                    }
                    else if (pair.Value.Equals("female"))
                    {
                        bool selected = web.IsElementSelected(actualValues["female"]);
                        if (!selected)
                        {
                            return false;
                        }
                    }
                }

                else if (pair.Key.Equals("phoneCode"))
                {
                    string fieldValueMoblie = web.GetAttributeText(actualValues["flagsMobile"], "title");
                    string fieldValueLandline = web.GetAttributeText(actualValues["flagsLandline"], "title");
                    Log.Info("expectedValue is - " + expectedValues["phoneCode"] + "// actualValue is - " + fieldValueMoblie);
                    Log.Info("expectedValue is - " + expectedValues["phoneCode"] + "// actualValue is - " + fieldValueLandline);
                    if (!fieldValueMoblie.Equals(pair.Value) && !fieldValueLandline.Equals(pair.Value))
                    {
                        return false;
                    }
                }

                else
                {
                    string fieldValue = web.GetAttributeText(actualValues[pair.Key], "value");
                    Log.Info("expectedValue is - " + pair.Value + "// actualValue is - " + fieldValue);
                    if (!fieldValue.Equals(pair.Value))
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        #endregion

        #region [Table to DataTable and Dictionary]

        public static DataTable ToDataTable(Table table)
        {
            var dataTable = new DataTable();
            foreach (var header in table.Header)
            {
                dataTable.Columns.Add(header, typeof(string));
            }

            foreach (var row in table.Rows)
            {
                var newRow = dataTable.NewRow();
                foreach (var header in table.Header)
                {
                    newRow.SetField(header, row[header]);
                }
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

#endregion

        public static bool IsPageLoaded(string pageName)
        {
            Log.Info(new StackTrace().GetFrame(0).GetMethod().Name);

            try
            {
                InvokeClassMethodReturnValueReflection(pageName, "CheckSpecialElements");
                Log.Info("Method \"CheckSpecialElements\" was invoked successfuly");
            }
            catch (WebDriverTimeoutException e)
            {
                throw e;
            }
            catch (NullReferenceException e)
            {
                Log.Info("Method \"CheckSpecialElements\" is not avialable in the page - " + pageName);
            }

            IList<By> locators = new List<By>();
            string fullClassName = GetFullClassName(pageName);
            Type type = System.Type.GetType(fullClassName);
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.NonPublic | BindingFlags.Static);
            foreach (var fieldInfo in fieldInfos)
            {
                if (fieldInfo.FieldType.Name.Equals("By") && !fieldInfo.Name.Contains("Special") && !fieldInfo.Name.Contains("Msg"))
                {
                    locators.Add((By)fieldInfo.GetValue(null));
                }
            }

            try
            {
                web.ExpectWebElements(locators);
                return true;
            }
            catch (Exception e)
            {
                Log.Info("Locator/s is/are not visible on the page - " + e.Message);
                return false;
            }
        }


        public static Dictionary<string, string> GetHalfDictionary(Dictionary<string, string> dictionary, int partNumber)
        {
            int half = dictionary.Count/2;
            Dictionary <string, string> firstHalf = new Dictionary<string, string>();
            Dictionary <string, string> secondHalf = new Dictionary<string, string>();
            
            firstHalf["firstName"] = dictionary["firstName"];
            firstHalf["lastName"] = dictionary["lastName"];
            firstHalf["email"] = dictionary["email"];
            firstHalf["gender"] = dictionary["gender"];
            firstHalf["city"] = dictionary["city"];
            firstHalf["state"] = dictionary["state"];

            secondHalf["mobileNumber"] = dictionary["mobileNumber"];
            secondHalf["landlineNumber"] = dictionary["landlineNumber"];
            secondHalf["postcode"] = dictionary["postcode"];
            secondHalf["country"] = dictionary["country"];
            secondHalf["company"] = dictionary["company"];
            
            return (partNumber == 1) ? firstHalf : secondHalf;
        }

    }
}