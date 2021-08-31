using AventStack.ExtentReports;
using Everlight_Automation.Pages.PageObjects;
using NUnit.Framework;
using SeleniumDotNetCore.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everlight_Automation.Tests.UITests
{
    public class JavaScriptAlertTest : BaseTest
    {
        ExtentTest _childTest = null;
        JavaScriptAlertHomePage _javaScriptAlertHomePage = null;

        [OneTimeSetUp]
        public void InvokeExtentTest()
        {
            createParentNode(this.GetType().Name.ToString());
        }

        [SetUp]
        public void TestSetup()
        {
            GoToUrl(_configProperties["JavaScriptAlertUrl"]);
        }

        [Test]
        [Category("UI")]
        public void RunJavascriptAlert()
        {
            _childTest = _createChildNode(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            _javaScriptAlertHomePage = new JavaScriptAlertHomePage(_driver, _childTest);

            _javaScriptAlertHomePage.ClickJSAlert();

            _javaScriptAlertHomePage.ValidateJSAlertBox();

            _javaScriptAlertHomePage.ClickJSConfirm();

            _javaScriptAlertHomePage.ValidateJSConfirmAlert();

            _javaScriptAlertHomePage.ClickJSPromt();

            _javaScriptAlertHomePage.EnterTheTextInPromt(Resources.UI.TestData.AlerText);

            _javaScriptAlertHomePage.ValidateJSPromt();
        }
    }
}