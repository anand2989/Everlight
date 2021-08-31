using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumDotNetCore.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everlight_Automation.Pages.PageObjects
{
    public class ComputerBasedHomePage : WebElementLocators
    {
        ExtentTest extent = null;

        private string ComputerBasedHomePage_txt_TotalComputers = "//section[@id='main']/h1";

        private string ComputerBasedHomePage_textbox_Searchbox = "//input[@id='searchbox']";
        private string ComputerBasedHomePage_btn_FilterByname = "//input[@id='searchsubmit']";

        private string ComputerBasedHomePage_btn_AddNewComputer = "//a[text()='Add a new computer']";

        private string ComputerBasedHomePage_table_header_computerTable = "//table[@class='computers zebra-striped']/thead/tr/th";
        private string ComputerBasedHomePage_table_body_computerTable = "//table[@class='computers zebra-striped']/tbody/tr";

        private string ComputerBasedHomePage_txtbox_ComputerName = "//input[@id='name']";
        private string ComputerBasedHomePage_txtbox_Introduced = "//input[@id='introduced']";
        private string ComputerBasedHomePage_txtbox_Discontinued = "//input[@id='discontinued']";
        private string ComputerBasedHomePage_txtbox_CompanyName = "//select[@id='company']";

        private string ComputerBasedHomePage_btn_CreateComputer = "//input[@value='Create this computer']";
        private string ComputerBasedHomePage_btn_SaveComputer = "//input[@value='Save this computer']";
        
        private string ComputerBasedHomePage_btn_Cancel = "//a[text()='Cancel']";

        private string ComputerBasedHomePage_txt_SucessMessage1 = "//div[@class='alert-message warning']/strong";
        private string ComputerBasedHomePage_txt_SucessMessage2 = "//div[@class='alert-message warning']";


        public ComputerBasedHomePage(IWebDriver driver, ExtentTest extentTest) : base(driver, extentTest)
        {
            extent = extentTest;
        }

        protected internal void VerifyTotalNumberofCompueters()
        {
            string _totalNumberofComputers = GetText(_returnWebElementByXpath(ComputerBasedHomePage_txt_TotalComputers));

            if(_totalNumberofComputers != null)
            {
                extent.Log(Status.Pass, "Total Number of compueters available in the database are : " + _totalNumberofComputers.Split("computers")[0].Trim());
            }
            else
            {
                extent.Log(Status.Pass, "Total Number of compueters available in the database are : 0");
            }
        }

        protected internal void SearchComputerNameInSearchBox(string _compueterName)
        {
            EnterText(_returnWebElementByXpath(ComputerBasedHomePage_textbox_Searchbox), _compueterName, "Search Box");
            Click(_returnWebElementByXpath(ComputerBasedHomePage_btn_FilterByname), "Filter by name");
        }

        protected internal void AddNewComputer()
        {
            Click(_returnWebElementByXpath(ComputerBasedHomePage_btn_AddNewComputer), "Add New Computer");
        }

        protected internal Boolean FindTheComputerNameInTable(string _computerName)
        {
            int _columnSize = 0;
            int _rowSize = 0;
            int _computerNameColumnNumber = 0;
            string _ComputercolumnName = null;
            string _expectedcomputerName = null;

            _columnSize = _returnWebElementsByXpath(ComputerBasedHomePage_table_header_computerTable).Count;

            _rowSize = _returnWebElementsByXpath(ComputerBasedHomePage_table_body_computerTable).Count;

            for (int _columnrotator = 1; _columnrotator <= _columnSize; _columnrotator++)
            {
                _ComputercolumnName = _returnWebElementByXpath(ComputerBasedHomePage_table_header_computerTable + "[" + _columnrotator + "]/a").Text;

                if (_ComputercolumnName.Equals("Computer name"))
                {
                    _computerNameColumnNumber = _columnrotator;
                    break;
                }
            }

            for (int _rowIterator = 1; _rowIterator <= _rowSize; _rowIterator++)
            {
                _expectedcomputerName = _returnWebElementByXpath(ComputerBasedHomePage_table_body_computerTable + "[" + _rowIterator + "]/td[" + _computerNameColumnNumber + "]/a").Text;

                if (_expectedcomputerName.Equals(_computerName))
                {
                    return true;
                }
            }

            return false;
        }

        protected internal void EditComputerData(string _computerName)
        {
            int _columnSize = 0;
            int _rowSize = 0;
            int _computerNameColumnNumber = 0;
            string _ComputercolumnName = null;
            string _expectedcomputerName = null;

            _columnSize = _returnWebElementsByXpath(ComputerBasedHomePage_table_header_computerTable).Count;

            _rowSize = _returnWebElementsByXpath(ComputerBasedHomePage_table_body_computerTable).Count;

            for (int _columnrotator = 1; _columnrotator <= _columnSize; _columnrotator++)
            {
                _ComputercolumnName = _returnWebElementByXpath(ComputerBasedHomePage_table_header_computerTable + "[" + _columnrotator + "]/a").Text;

                if (_ComputercolumnName.Equals("Computer name"))
                {
                    _computerNameColumnNumber = _columnrotator;
                    break;
                }
            }

            for (int _rowIterator = 1; _rowIterator <= _rowSize; _rowIterator++)
            {
                _expectedcomputerName = _returnWebElementByXpath(ComputerBasedHomePage_table_body_computerTable + "[" + _rowIterator + "]/td[" + _computerNameColumnNumber + "]/a").Text;

                if (_expectedcomputerName.Equals(_computerName))
                {
                   Click(_returnWebElementByXpath(ComputerBasedHomePage_table_body_computerTable + "[" + _rowIterator + "]/td[" + _computerNameColumnNumber + "]/a"),"Edit the program");
                    break;
                }
            }

            EnterText(_returnWebElementByXpath(ComputerBasedHomePage_txtbox_Introduced), Resources.UI.TestData.Introduced, "Entering the date value");
        }

        protected internal void EnterTheDetailsToCreateTheComputer(string _computerName, string _introduced, string companyName)
        {
            WaitForElementVisible(ComputerBasedHomePage_txtbox_ComputerName, "xpath");
            EnterText(_returnWebElementByXpath(ComputerBasedHomePage_txtbox_ComputerName), _computerName, "Computer Name");
            EnterText(_returnWebElementByXpath(ComputerBasedHomePage_txtbox_Introduced), _introduced, "Introduced");
            
            SelectValue(_returnWebElementByXpath(ComputerBasedHomePage_txtbox_CompanyName), companyName);
        }

        protected internal void ClickoncreateComputer()
        {
            WaitForElementVisible(ComputerBasedHomePage_btn_CreateComputer, "xpath");
            Click(_returnWebElementByXpath(ComputerBasedHomePage_btn_CreateComputer), "Create Computer");
            WaitForElementVisible(ComputerBasedHomePage_txt_SucessMessage1, "xpath");
        }

        protected internal void ClickonSaveComputerData()
        {
            WaitForElementVisible(ComputerBasedHomePage_btn_SaveComputer, "xpath");
            Click(_returnWebElementByXpath(ComputerBasedHomePage_btn_SaveComputer), "Save Computer");
            WaitForElementVisible(ComputerBasedHomePage_txt_SucessMessage1, "xpath");
        }

        

        protected internal void CancelCreateComputer()
        {
            WaitForElementVisible(ComputerBasedHomePage_btn_Cancel, "xpath");
            Click(_returnWebElementByXpath(ComputerBasedHomePage_btn_Cancel), "Cancel add New Computer");
        }

        protected internal Boolean VerifyCreatedComputerCreatedMessage()
        {
            try
            {
                return IsElementVisible(_returnWebElementByXpath(ComputerBasedHomePage_txt_SucessMessage1));
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        protected internal Boolean VerifyCreatedComputerCreatedMessage(string _computerName)
        {
           try
            {
                return _returnWebElementByXpath(ComputerBasedHomePage_txt_SucessMessage2).Text.Contains(_computerName);
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}