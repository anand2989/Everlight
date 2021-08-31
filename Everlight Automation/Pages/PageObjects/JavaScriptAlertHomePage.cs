using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumDotNetCore.Pages;

namespace Everlight_Automation.Pages.PageObjects
{
    class JavaScriptAlertHomePage : WebElementLocators
    {
        private string JavaScriptHomePage_btn_JSAlert = "//button[text()='Click for JS Alert']";
        private string JavaScriptHomePage_btn_JSConfirm = "//button[@onclick='jsConfirm()']";
        private string JavaScriptHomePage_btn_JSPromt = "//button[@onclick='jsPrompt()']";

        private string JavaScriptHomePage_txt_Result = "//p[@id='result']";

        public JavaScriptAlertHomePage(IWebDriver driver, ExtentTest extentTest) : base(driver, extentTest)
        {

        }

        protected internal void ClickJSAlert()
        {
            Click(_returnWebElementByXpath(JavaScriptHomePage_btn_JSAlert), "JS Alert");

            AcceptAlert();
        }

        protected internal void ClickJSConfirm()
        {
            Click(_returnWebElementByXpath(JavaScriptHomePage_btn_JSConfirm), "JS Confirm");

            AcceptAlert();
        }

        protected internal void ClickJSPromt()
        {
            Click(_returnWebElementByXpath(JavaScriptHomePage_btn_JSPromt), "JS Promt");
        }

        protected internal string GetTheResultofJSAction()
        {
            WaitForElementVisible(JavaScriptHomePage_txt_Result, "xpqath");
            return _returnWebElementByXpath(JavaScriptHomePage_txt_Result).Text;
        }

        protected internal void EnterTheTextInPromt(string _alerttextMessage)
        {
            EnterTheTextInAlert(_alerttextMessage);
        }

        protected internal void ValidateJSAlertBox()
        {
            Assert.AreEqual(Resources.UI.TestData.JS_AlertMessage, GetTheResultofJSAction());
        }

        protected internal void ValidateJSConfirmAlert()
        {
            Assert.AreEqual(Resources.UI.TestData.JS_ConfirmMessage, GetTheResultofJSAction());
        }

        protected internal void ValidateJSPromt()
        {
            Assert.True(GetTheResultofJSAction().ToString().Contains(Resources.UI.TestData.AlerText));
        }
    }
}