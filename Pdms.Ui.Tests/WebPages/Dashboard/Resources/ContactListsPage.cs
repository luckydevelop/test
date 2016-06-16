using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kliiko.Ui.Tests.Selenium;
using Kliiko.Ui.Tests.Utils;
using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.WebPages.Dashboard.Resources
{
    class ContactListsPage : WebPage
    {
        private static readonly By DropdownMenuAddContactsNoRowsSpecial = By.Id("contact-lists-add-button-2");
        private static readonly By DropdownMenuAddContactsSpecial = By.Id("contact-lists-add-button-1");
        
        private static readonly By LinkMenuItemManualInputSpecial = By.LinkText("Manual Input");
        private static readonly By LinkMenuItemImportExcelSpecial = By.LinkText("Import Excel");
        private static readonly By LinkMenuItemImportCsvSpecial = By.LinkText("Import CSV");

        private static readonly By CheckboxSelectAllSpecial = By.XPath(".//*[@id='list-mass-actions']/span/div[1]/label");
        private static readonly By CheckboxDeleteSpecial = By.XPath(".//*[@id='list-mass-actions']/span/div[2]/img");

        private static readonly By MenuItemAccountManagers = By.XPath(".//*[@id='list-of-contacts']/div[2]/div[1]");
        private static readonly By MenuItemFacilitators = By.XPath(".//*[@id='list-of-contacts']/div[3]/div[1]");
        private static readonly By MenuItemAccountObservers = By.XPath(".//*[@id='list-of-contacts']/div[4]/div[1]");

        private static readonly By ButtonAddNewList = By.CssSelector(".btn-standart.btn-green");
        private static readonly By ButtonRecruiter = By.CssSelector(".btn-standart.btn-blue.ng-scope");

        private static readonly By TableHeaderFirstNameSpecial = By.XPath(".//*[@id='dashboard-contact-lists-main-table']/table/thead/tr/th[2]/span[3]");
        private static readonly By TableHeaderLastNameSpecial = By.XPath(".//*[@id='dashboard-contact-lists-main-table']/table/thead/tr/th[3]/span[3]");
        private static readonly By TableHeaderGenderSpecial = By.XPath(".//*[@id='dashboard-contact-lists-main-table']/table/thead/tr/th[4]/span[3]");
        private static readonly By TableHeaderEmailSpecial = By.XPath(".//*[@id='dashboard-contact-lists-main-table']/table/thead/tr/th[5]/span[3]");
        private static readonly By TableHeaderCitySpecial = By.XPath(".//*[@id='dashboard-contact-lists-main-table']/table/thead/tr/th[6]/span[3]");
        private static readonly By TableHeaderStateSpecial = By.XPath(".//*[@id='dashboard-contact-lists-main-table']/table/thead/tr/th[7]/span[3]");
        private static readonly By TableHeaderCountrySpecial = By.XPath(".//*[@id='dashboard-contact-lists-main-table']/table/thead/tr/th[8]/span[3]");
        private static readonly By TableHeaderCodeSpecial = By.XPath(".//*[@id='dashboard-contact-lists-main-table']/table/thead/tr/th[9]/span[3]");
        private static readonly By TableHeaderCompanySpecial = By.XPath(".//*[@id='dashboard-contact-lists-main-table']/table/thead/tr/th[10]/span[3]");
        private static readonly By TableHeaderLandlineSpecial = By.XPath(".//*[@id='dashboard-contact-lists-main-table']/table/thead/tr/th[11]/span[3]");
        private static readonly By TableHeaderMobileSpecial = By.XPath(".//*[@id='dashboard-contact-lists-main-table']/table/thead/tr/th[12]/span[3]");

        private static readonly By TableManageColumnsSpecial = By.XPath(".//*[@id='dashboard-contact-lists-main-table']/table/thead/tr/th[13]/img");

        //  private static readonly By TestRemove = By.XPath(".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr/td[13]/span/img[2]");


        private static readonly String TableCellSelect =".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr[1]/td[{0}]/div/label";
        private static readonly String TableCellFirstName = ".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr[{0}]/td[2]";
        private static readonly String TableCellLastName = ".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr[{0}]/td[3]";
        private static readonly String TableCellGender = ".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr[{0}]/td[4]";
        private static readonly String TableCellEmail = ".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr[{0}]/td[5]";
        private static readonly String TableCellCity = ".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr[{0}]/td[6]";
        private static readonly String TableCellState = ".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr[{0}]/td[7]";
        private static readonly String TableCellCountry = ".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr[{0}]/td[8]";
        private static readonly String TableCellCode = ".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr[{0}]/td[9]";
        private static readonly String TableCellCompany = ".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr[{0}]/td[10]";
        private static readonly String TableCellLandline = ".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr[{0}]/td[11]";
        private static readonly String TableCellMobile = ".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr[{0}]/td[12]";
        private static readonly String TableCellActions = ".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr[{0}]/td[13]";
        private static readonly String TableCellEdit = ".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr[{0}]/td[13]/span/img[1]";
        private static readonly String TableCellRemove = ".//*[@id='dashboard-contact-lists-main-table']/table/tbody/tr[{0}]/td[13]/span/img[2]";

        private static readonly String TableID = "dashboard-contact-lists-main-table";
        
     public static void SelectManualInput()
        {
            if (Web.IsElementVisibleMilliseconds(DropdownMenuAddContactsNoRowsSpecial, 500))
            {
                Web.Click(DropdownMenuAddContactsNoRowsSpecial);
            }
            else
            {
                Web.Click(DropdownMenuAddContactsSpecial);
            }
            Web.Click(LinkMenuItemManualInputSpecial);
        }

        private static Dictionary<string, string> GetMainTableCells()
        {
          Dictionary<string, string> mainTableCells = new Dictionary<string, string>();
          mainTableCells["firstName"] = TableCellFirstName;
          mainTableCells["lastName"] = TableCellLastName;
          mainTableCells["email"] = TableCellEmail;
          mainTableCells["gender"] = TableCellGender;
          return mainTableCells;
        }

        private static Dictionary<string, string> GetAllTableCells()
        {
            Dictionary<string, string> allTableCells = GetMainTableCells();
            allTableCells["city"] = TableCellCity;
            allTableCells["state"] = TableCellState;
            allTableCells["mobileNumber"] = TableCellMobile;
            allTableCells["landlineNumber"] = TableCellLandline;
            allTableCells["postcode"] = TableCellCode;
            allTableCells["country"] = TableCellCountry;
            allTableCells["company"] = TableCellCompany;
            return allTableCells;
        }

        public static bool IsAllDataSavedInTable(Dictionary<string, string> expectedData)
        {
            Web.Refresh();
            bool res = false;
            string rowNumber = GetEmailRowNumber(expectedData["email"]);
            Log.Info("EmailRowNumber is " + rowNumber);
            if (expectedData.ContainsKey("phoneCode"))
            {
                expectedData.Remove("phoneCode");
            }
            if (expectedData.ContainsKey("address"))
            {
                expectedData.Remove("address");
            }

            res = Helper.IsAllDataSavedInTable(expectedData, GetAllTableCells(), rowNumber);

            //if (expectedData.Count < 3)
            //{
            //    res = Helper.IsAllDataSavedInTable(expectedData, GetAllTableCells(), rowNumber);
            //}
            //else
            //{
            //    Dictionary<string, string> firstPart = Helper.GetHalfDictionary(expectedData, 1);
            //    Dictionary<string, string> secondPart = Helper.GetHalfDictionary(expectedData, 2);

            //    res = Helper.IsAllDataSavedInTable(firstPart, GetAllTableCells(), rowNumber);
            //    if (res)
            //    {
            //        foreach (var pair in secondPart)
            //        {
            //            Log.Info("secondPart - " + pair.Key +" " + pair.Value);
            //        }
            //      //  ScrollHorizontalLeftTable();
            //        res = Helper.IsAllDataSavedInTable(secondPart, GetAllTableCells(), rowNumber);
            //    }
            //}
            //ScrollHorizontalRightTable();
            return res;
        }

        public static string GetEmailRowNumber(string expectedEmail)
        {
            string emailRowNumber = Helper.GetRowNumber(expectedEmail, TableCellEmail, 62);

            return emailRowNumber;
        }

        //public static void ScrollHorizontalRightTable()
        //{
        //    Web.ScrollHorizontalRight(TableID);
        //}

        public static void ClickIconEdit(string targetEmail)
        {
            string contactRow = GetEmailRowNumber(targetEmail);
            By actionsCell = By.XPath(String.Format(TableCellActions, contactRow));
            By editAction = By.XPath(String.Format(TableCellEdit, contactRow));
            Web.MoveMouse(actionsCell);
            Web.Click(editAction);
        }

        public static void ClickIconRemove(string targetEmail)
        {
            string contactRow = GetEmailRowNumber(targetEmail);
            Log.Info("contactRow = " + contactRow);
            By actionsCell = By.XPath(String.Format(TableCellActions, contactRow));
            By targetXpath = By.XPath(String.Format(TableCellRemove, contactRow));
            Web.MoveMouse(actionsCell);
            Web.Click(targetXpath);
            Web.ConfirmAlert();
        }

      
        public static void SelectDeleteCheckBox()
        {
            Web.Click(CheckboxDeleteSpecial);
            Web.ConfirmAlert();
        }

        public static void SelectSelectAllCheckBox()
        {
            Web.Click(CheckboxSelectAllSpecial);
        }

    }
}
