using System;
using System.Collections.Generic;
using System.Linq;
using Kliiko.Ui.Tests.Selenium;
using Kliiko.Ui.Tests.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Kliiko.Ui.Tests.WebPages.Dashboard.AccountProfile
{
    class AccountManagersPage : WebPage
    {
        private static readonly By ButtonAddAccountManager = By.CssSelector(".btn.btn-addNewElement");
        private static readonly By TableHeader = By.CssSelector(".table.table-dashboardElements>thead");
        
        private static readonly string tableFirstNameXpath = ".//*[@id='account-manager-content']/ng-include/div/div[2]/table/tbody/tr[{0}]/td[1]";
        private static readonly string tableLastNameXpath = ".//*[@id='account-manager-content']/ng-include/div/div[2]/table/tbody/tr[{0}]/td[2]";
        private static readonly string tableGenderXpath = ".//*[@id='account-manager-content']/ng-include/div/div[2]/table/tbody/tr[{0}]/td[3]";
        private static readonly string tableEmailXpath = ".//*[@id='account-manager-content']/ng-include/div/div[2]/table/tbody/tr[{0}]/td[4]";
        private static readonly string tableMobileXpath = ".//*[@id='account-manager-content']/ng-include/div/div[2]/table/tbody/tr[{0}]/td[5]";
        private static readonly string tableStatusXpath = ".//*[@id='account-manager-content']/ng-include/div/div[2]/table/tbody/tr[{0}]/td[6]";
        private static readonly string tableEditXpath = ".//*[@id='account-manager-content']/ng-include/div/div[2]/table/tbody/tr[{0}]/td[7]/img[1]";
        private static readonly string tableRemoveXpath = ".//*[@id='account-manager-content']/ng-include/div/div[2]/table/tbody/tr[{0}]/td[7]/img[2]";
        
        private static Dictionary<string, string> GetMainTableCells()
        {
            Dictionary<string, string> tableCells = new Dictionary<string, string>();
            tableCells["firstName"] = tableFirstNameXpath;
            tableCells["lastName"] = tableLastNameXpath;
            tableCells["email"] = tableEmailXpath;
            tableCells["gender"] = tableGenderXpath;
            tableCells["mobileNumber"] = tableMobileXpath;
            return tableCells;
        }
        
        public static bool IsAllDataSavedInTable(Dictionary<string, string> dataFields)
        {
            string row = GetEmailRowNumber(dataFields["email"]);
            Dictionary<string, string> targetDictionary = new Dictionary<string, string>(dataFields);
            targetDictionary.Remove("landlineNumber");
            targetDictionary.Remove("phoneCode");
            targetDictionary.Remove("address");
            targetDictionary.Remove("city");
            targetDictionary.Remove("state");
            targetDictionary.Remove("postcode");
            targetDictionary.Remove("country");
            targetDictionary.Remove("company");
            Log.Info("firstNameRowNumber is " + row);
            return Helper.IsAllDataSavedInTable(targetDictionary, GetMainTableCells(), row);
            //return IsAllDataSavedInTable(dataFields, GetMainTableCells(), row);
        }

        public static string GetManagerStatus(string mangerEmail)
        {
            string rowNumber = GetEmailRowNumber(mangerEmail);
            Log.Info("String.Format(tableStatusXpath, rowNumber) = " + String.Format(tableStatusXpath, rowNumber));
            string status = Web.GetLocatorText(By.XPath(String.Format(tableStatusXpath, rowNumber)));
            return status;
        }

        
        public static string GetEmailRowNumber(string expectedEmail)
        {
            string firstNameRowNumber = Helper.GetRowNumber(expectedEmail, tableEmailXpath, 73);
            
            return firstNameRowNumber;
        }

       public static void ClickButtonAddNewAccountManager()
        {
            Web.Click(ButtonAddAccountManager);
        }

        public static void ClickIconEdit(string targetEmail)
        {
            string managerRow = GetEmailRowNumber(targetEmail);
            By targetXpath = By.XPath(String.Format(tableEditXpath, managerRow));
            Web.Click(targetXpath);
        }

        public static void ClickIconRemove(string targetEmail)
        {
            string managerRow = GetEmailRowNumber(targetEmail);
            By targetXpath = By.XPath(String.Format(tableRemoveXpath, managerRow));
            Web.Click(targetXpath);
            Web.ConfirmAlert();
        }

    }
}
