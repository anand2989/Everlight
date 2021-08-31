using Everlight_Automation.Extensions;
using Everlight_Automation.ExtentReport;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace SeleniumDotNetCore.Tests
{
    [TestFixture]
    public class BaseTest : ExtentReporting
    {
        protected IWebDriver _driver;

        [OneTimeSetUp]
        public void setUp()
        {
            // read properties
            LoadPropertiesFromFile();

            //Creating report instance
            createReportInstance();
        }

        [SetUp]
        protected void BaseTestSetup()
        {
            switch (_configProperties["browser"].ToLower())
            {
                case "chrome":
                    {

                        String path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "\\Configuration";
                        _driver = new ChromeDriver(path);

                        break;
                    }
                case "firefox":
                    {
                        _driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                        break;
                    }
                case "ie":
                    {
                        var options = new InternetExplorerOptions();
                        options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                        options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
                        _driver = new InternetExplorerDriver(options);
                        break;
                    }
                default:
                    {
                        throw new Exception("No browser type specified in the propoerties file");
                    }
            }

            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = 5.Seconds();
            _driver.Manage().Timeouts().PageLoad = 20.Seconds();
          }

        [TearDown]
        protected void BaseTestCleanup()
        {
            // if the test failed, take a screenshot
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                var screenShotFileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/" +
                    TestContext.CurrentContext.Test.FullName + DateTime.Now.ToString("MMM-dd-HHmm") + ".jpg";
                screenshot.SaveAsFile(screenShotFileName);
                Console.WriteLine("Screenshot saved at: " + screenShotFileName);
            }

            _extentReports.Flush();


            _driver.Quit();
            
        }

        protected void GoToUrl(String url)
        {
            _driver.Navigate().GoToUrl(url);

            Thread.Sleep(3000);
        }
    }
}