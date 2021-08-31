using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumDotNetCore.Tests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace SeleniumDotNetCore.Pages
{
    public class BasePage : BaseTest
    {
        protected new IWebDriver _driver;
        protected new ExtentTest _extentTest;
        private int _screenshotRandomNumber = 0;
        protected WebDriverWait _webDriverWait;
        protected bool capturePassScreenshot = Convert.ToBoolean(_configProperties["capturePassScreenshot"]);

        public BasePage(IWebDriver driver, ExtentTest test)
        {
            _driver = driver;
            _extentTest = test;
            _webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Convert.ToDouble(_configProperties["webdriverwait"])));

        }

        protected internal void AcceptAlert()
        {
            try
            {
                _driver.SwitchTo().Alert().Accept();

                _extentTest.Log(Status.Pass, "Able to accept the alert box");
            }
            catch (Exception ex)
            {
                _extentTest.Log(Status.Fail, "unable to accept the alert box");
            }
        }

        protected internal void EnterTheTextInAlert(string _alertText)
        {
            try
            {
                StaticWait(2500);

                _driver.SwitchTo().Alert().SendKeys(_alertText);

                StaticWait(2500);

                _driver.SwitchTo().Alert().Accept();

                _extentTest.Log(Status.Pass, "Able to enter the text in the alert box : " + _alertText);
            }
            catch (Exception ex)
            {
                _extentTest.Log(Status.Fail, "Unable to enter the text in the alert box");
            }
        }


        protected internal void EnterText(IWebElement _webElement, String text, String elementName)
        {
            try
            {
                _webElement.Clear();
                _webElement.SendKeys(text);

                if (capturePassScreenshot)
                {
                    _extentTest.Log(Status.Pass, "Able to enter the text in the field : " + elementName + " and the text : " + text + " ");
                }
                else
                {
                    _extentTest.Log(Status.Fail, "unable to enter the text in the field : " + elementName + " and the text : " + text + " ");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Tried to enter the text '" + text + "' into an element but failed", e);
            }
        }

        protected internal string GetText(IWebElement _webElement)
        {
            return _webElement.Text;   
        }

        public bool IsElementVisible(IWebElement _webElement)
        {
            try
            {
                return _webElement.Displayed;
            }
            catch (Exception ex)
            {
                return _webElement.Displayed;
            }
        }

        protected internal void Click(IWebElement _webElement, String elementName)
        {
            try
            {
                _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_webElement));
                _webElement.Click();

                if (capturePassScreenshot)
                {
                    _extentTest.Log(Status.Pass, "Succesfully clicked on the button : " + elementName);
                }
                else
                {
                    _extentTest.Log(Status.Fail, "Failed to click on the button : " + elementName);
                }
            }
            catch (NoSuchElementException ex)
            {
                throw new NoSuchElementException("Unable to click the element " + elementName + "throwing the exception " + ex.Message);
            }
        }

        public void SelectValue(IWebElement options, String optionToSelect)
        {
                try
                {
                    var selectElement = new SelectElement(options);

                    selectElement.SelectByText(optionToSelect);

                    _extentTest.Log(Status.Pass, "Selecting the Value  : " + optionToSelect + "from the drop down");
                }
                catch (Exception e)
                {
                    _extentTest.Log(Status.Fail, "Unable to select the Value  : " + optionToSelect + "from the drop down");
                    throw new Exception("Tried to select option '" + optionToSelect + "' but failed, available options:\n" +
                    String.Join(", ", options), e);
                }
        }

        protected internal void WaitForElementVisible(string _webElementXpath, string typeofIdentifier)
        {
            bool _webElementExist = false;
            int _iterationCount = 0;

            do
            {
                try
                {
                    switch (typeofIdentifier)
                    {
                        case "xpath":

                            _webElementExist = _driver.FindElement(By.XPath(_webElementXpath)).Displayed;

                            StaticWait(2000);

                            break;
                    }


                    _iterationCount++;
                }
                catch (Exception ex)
                {
                    StaticWait(2000);
                    continue;
                }

            } while (!_webElementExist && _iterationCount <= 9);
        }

        public void StaticWait(int staticWaitInMilliSeconds)
        {
            Thread.Sleep(staticWaitInMilliSeconds);
        }
    }
}