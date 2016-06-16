using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Kliiko.Ui.Tests.Utils;
using System.Text.RegularExpressions;


namespace Kliiko.Ui.Tests.Selenium
{
    class WebApplication
    {
        private static List<IWebDriver> _allDrivers;
        private static int _emailCountBefore = 0;
        private static int _emailCountAfter = 0;
        private Type[] _types;

        public IWebDriver WebDriver { get; private set; }

        public WebApplication(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            _allDrivers = new List<IWebDriver>();
        }
        
        public void MaximizeWindow()
        {
            WebDriver.Manage().Window.Maximize();
        }

       #region [Navigation]
        public void Refresh()
        {
            WebDriver.Navigate().Refresh();
        }

        public void Open(string path)
        {
            WebDriver.Navigate().GoToUrl(path);
        }

        public string GetCurrentPage()
        {
            return WebDriver.Url;
        }
      #endregion

       #region [Find, Wait, Visible, InVsible]
        public IWebElement FindElement(By locator)
        {
            return FindElementMilliSeconds(locator, 5000);
        }
        
        public IWebElement FindElementMilliSeconds(By locator, int milliSeconds)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromMilliseconds(milliSeconds));

            try
            {
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
                Log.Info("WebElement is VISIBLE!!! It's locatot is - " + locator);
                return element;
            }
            catch (Exception e)
            {
                Log.Error("WebDriverTimeoutException. WebElement is NOT VISIBLE!!! It's type is - " + locator);
                int quantityOfElements = WebDriver.FindElements(locator).Count;
                if (quantityOfElements > 0)
                {
                    Log.Warn("May be reason of EXCEPTION is that locator is not UNIQUE. Quantity of elements for this locator is - " + quantityOfElements);
                }
                throw e;
            }
        }

        public IReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            FindElement(locator);
            return WebDriver.FindElements(locator);
        }

        public bool IsElementVisible(By locator)
        {
            return IsElementVisibleMilliseconds(locator, 5000);
        }

        public bool IsElementVisibleMilliseconds(By locator, int milliSeconds)
        {
            try
            {
                FindElementMilliSeconds(locator, milliSeconds);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void ExpectWebElements(IList<By> listLocators)
        {
            for (int i = 0; i < listLocators.Count; i++)
            {
                FindElementMilliSeconds(listLocators[i], 4000);
            }
        }
        
        public void WaitUntilInVisible(By locator)
        {
            Log.Info("Methos - " + new StackTrace().GetFrame(0).GetMethod().Name);
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
                Log.Info("WebElement is already INvisible!! It's locatot is - " + locator);
            }
            catch (Exception e) //уточнить исключение
            {
                Log.Error("WebElement is STILL VISIBLE!! It's locatot is - " + locator);
                throw e;
            }
        }

        public void WaitUntilToBeClicable(By locator)
        {
            Log.Info("Methos - " + new StackTrace().GetFrame(0).GetMethod().Name);
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                Log.Info("WebElement is already Clickable!! It's locatot is - " + locator);
            }
            catch (Exception e) //уточнить исключение
            {
                Log.Error("WebElement is STILL UnClickable!! It's locatot is - " + locator);
                throw e;
            }
        }

        #endregion

       #region[Text - Get, Type, Clear]

        public void Type(By locator, string text)
        {
            FindElement(locator).SendKeys(text);
        }

        public void TypeNewText(By locator, string text)
        {
            IWebElement element = FindElement(locator);
            element.Clear();
            element.SendKeys(text);
        }

        public void ClearField(By locator)
        {
            IWebElement element = FindElement(locator);
            element.Clear();
        }

        public string GetAttributeText(By locator, string attribute)
        {
            string attributeText = FindElementMilliSeconds(locator, 5000).GetAttribute(attribute);
            Log.Info(new StackTrace().GetFrame(0).GetMethod().Name + "TEXT of ATTRIBUTE is - " + attributeText + " LOCATOR is - " + locator);
            return attributeText;
        }

        public string GetLocatorText(By locator)
        {
            // string locatorText = FindElement2(locator).Text;
            string locatorText = FindElement(locator).Text;
            locatorText = Regex.Replace(locatorText, @"\r\n", " ");
            Log.Info(new StackTrace().GetFrame(0).GetMethod().Name + "TEXT of LOCATOR is - " + locatorText + " LOCATOR is - " + locator);
            return locatorText;
        }
        #endregion

       #region[Click, Submit]
        public void Click(By locator)
        {
            FindElement(locator).Click();
        }

        public void ClickWithActions(By locator)
        {
            IWebElement element = FindElement(locator);
            Actions action = new Actions(WebDriver);
            action.MoveToElement(element).Click().Perform();
        }
        
        public void ClickJavascriptExecutor(By locator)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriver;
            executor.ExecuteScript("arguments[0].click();", FindElement(locator));
        }
        
        public void Submit(By locator)
        {
            FindElement(locator).Submit();
        }
        #endregion

       #region [Selected, Select]
        public bool IsElementSelected(By locator)
        {
            return FindElement(locator).Selected;
        }
        
        public SelectElement SelectElement(By locator)
        {
            var select = FindElement(locator); //почему var, а не IWebElement
            return new SelectElement(select);
        }
        
        public void SelectByValue(By locator, string value)
        {
            SelectElement(locator).SelectByValue(value);
        }
        #endregion


        public void MoveMouse(By locator)
        {
            IWebElement element = FindElement(locator);
            Actions action = new Actions(WebDriver);
            action.MoveToElement(element).Perform();
        }

        public void ScrollHorizontalLeft(string elementId)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriver;
            string targetString = string.Format("document.getElementById('{0}').scrollLeft += 250", elementId);
            executor.ExecuteScript(targetString, "");
        }

        public void ScrollHorizontalRight(string elementId)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriver;
            string targetString = string.Format("document.getElementById('{0}').scrollRight += 250", elementId);
            executor.ExecuteScript(targetString, "");
        }
        
        public void ConfirmAlert()
        {
            IAlert alert = WebDriver.SwitchTo().Alert();
            alert.Accept();
        }

        

        #region[Artur]
        //Artur
        public static int GetEmailCountBefore() //C# delegators
        {
            return _emailCountBefore;
        }
        public static int GetEmailCountAfter()
        {
            return _emailCountAfter;
        }


        public static void ResetEmailCounter()
        {
            _emailCountBefore = 0;
            _emailCountAfter = 0;
        }

        public void AddSession(string userRole) //непонимаю манёвром с allDrivers. Зачем нам там хранить драйвера
        {
            IWebDriver newDriver;
            if (_allDrivers.Count != 0)
            {
                newDriver = WebApplications.NewWebDriver(); //создаём новый драйвер
                WebDriver = newDriver; //присваиваем переменной класса новый драйвер
            }
            else
            {
                newDriver = WebDriver; //присваиваем драйвер с конструктора
            }
            _allDrivers.Add(newDriver);
            ApplicationContext.UserDrivers.Add(userRole, newDriver); //непонятно почему мы можем испльзовать метод Add применительно к UserDrivers. Ведь этот относиться 
        }

        public void SwitchTo(string userRole)
        {
            var newWebDriver = ApplicationContext.UserDrivers[userRole];
            WebDriver = newWebDriver;
        }


        internal void DeleteMailLogOut()
        {
            throw new NotImplementedException();
        }

        //TODO: MOVE TO MAILREADER
        public static void CountEmail(string email, string password)
        {
            Log.Info("emailCountBefore - " + _emailCountBefore + " emailCountAfter - " + _emailCountAfter + " email" + email + " password" + password);

            if (_emailCountBefore == 0)
            {
                _emailCountBefore = MailReader.MailReader.GmailUnreadCount(email, password);
            }
            else
            {
                _emailCountAfter = MailReader.MailReader.GmailUnreadCount(email, password);
            }
            Log.Info("emailCountBefore - " + _emailCountBefore + " emailCountAfter - " + _emailCountAfter);
        }
        //TODO: MOVE TO MAILREADER
        public static bool CompareEmailCount()
        {
            return _emailCountAfter > _emailCountBefore;
        }

        //TODO: MOVE TO SEPARATE CLASS
        public static string GetFieldDataFromDynamicClass(object data, string fieldName)
        {
            return ((IDictionary<string, object>)data)[fieldName].ToString(); //[]
        }

        //TODO: MOVE TO SEPARATE CLASS
        public static string TimeParser(string time)
        {
            string[] data = time.Split('/');
            string n1 = data[0];
            string n2 = data[1];
            string n3 = data[2];
            return "0" + n1 + "-" + "0" + n2 + "-" + n3.Remove(4);
        }

        public int GetTableRowIndex(string xpath, string name)
        {
            Thread.Sleep(1000);
            var items = WebDriver.FindElements(By.XPath(xpath));
            int rowIndex = -1;
            foreach (var i in items.Where(i => i.Text.Equals(name))) //не совсем понятно =>
            {
                rowIndex = items.IndexOf(i) + 1;
            }
            return rowIndex;
        }
#endregion
        
    }
}
