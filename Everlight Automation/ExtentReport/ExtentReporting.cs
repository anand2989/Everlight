using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Everlight_Automation.PropertiesFile;
using System;
using System.IO;

namespace Everlight_Automation.ExtentReport
{
    public class ExtentReporting : GetProperties
    {
        protected static ExtentReports _extentReports;
        protected ExtentHtmlReporter _htmlReporter = null;
        protected ExtentTest _extentTest = null;
        protected ExtentKlovReporter ExtentKlovReporter;
        protected static string hmtlreport;

        //Creating the extent report instance
        protected void createReportInstance()
        {
            if (_extentReports == null)
            {
                hmtlreport = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss");

                string reportname = _configProperties["reportName"] + "_" + hmtlreport + ".html";

                string _reportPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

                _reportPath = _reportPath + "\\ExtentReport\\Reports\\" + hmtlreport;

                if (!Directory.Exists(_reportPath))
                {
                    Directory.CreateDirectory(_reportPath);
                }

                _extentReports = new ExtentReports();

                _htmlReporter = new ExtentHtmlReporter(_reportPath + "\\" + reportname);

                string _testerName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString().Split('\\')[1].ToString();

                _extentReports.AttachReporter(_htmlReporter);

                _extentReports.AddSystemInfo("Reporter name", _testerName);

                _extentReports.AddSystemInfo("Environment", _configProperties["environment"].ToString());

                _extentReports.AddSystemInfo("username", _testerName);
            }
        }

        // Creating the parent node for the extent test report
        protected void createParentNode(string _scenarioName)
        {
            _extentTest = _extentReports.CreateTest(_scenarioName);
        }

        // Creating the parent node for the extent test report
        protected ExtentTest _createChildNode(string _childTestName)
        {
            return _extentTest.CreateNode(_childTestName);
        }
    }
}