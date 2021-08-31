using AventStack.ExtentReports;
using Everlight_Automation.Pages.PageObjects;
using NUnit.Framework;
using SeleniumDotNetCore.Tests;

namespace Everlight_Automation.Tests.UITests
{
    public class ComputerDatabaseTests : BaseTest
    {
        ComputerBasedHomePage _computerBasedHome = null;
        ExtentTest _childTest = null;

        [OneTimeSetUp]
        public void InvokeExtentTest()
        {
            createParentNode(this.GetType().Name.ToString());
        }

        [SetUp]
        public void TestSetup()
        {
            GoToUrl(_configProperties["ComputerDatabaseUrl"]);
        }

        [Test]
        [Category("UI")]
        public void VerifyTotalNumberofComputers()
        {
            _childTest = _createChildNode(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            _computerBasedHome = new ComputerBasedHomePage(_driver, _childTest);

            _computerBasedHome.VerifyTotalNumberofCompueters();
        }

        [Test]
        [Category("UI")]
        public void AddNewComputerToDatabase()
        {
            _childTest = _createChildNode(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            _computerBasedHome = new ComputerBasedHomePage(_driver, _childTest);

            _computerBasedHome.AddNewComputer();

            _computerBasedHome.EnterTheDetailsToCreateTheComputer(Resources.UI.TestData.ComputerName, Resources.UI.TestData.Introduced, Resources.UI.TestData.CompanyName);

            _computerBasedHome.ClickoncreateComputer();

            Assert.True(_computerBasedHome.VerifyCreatedComputerCreatedMessage());

            Assert.True(_computerBasedHome.VerifyCreatedComputerCreatedMessage(Resources.UI.TestData.ComputerName));
        }

        [Test]
        [Category("UI")]
        public void CancelAddNewComputer()
        {
            _childTest = _createChildNode(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            _computerBasedHome = new ComputerBasedHomePage(_driver, _childTest);

            _computerBasedHome.AddNewComputer();

            _computerBasedHome.EnterTheDetailsToCreateTheComputer(Resources.UI.TestData.ComputerName, Resources.UI.TestData.Introduced, Resources.UI.TestData.CompanyName);

            _computerBasedHome.CancelCreateComputer();

            Assert.True(!_computerBasedHome.VerifyCreatedComputerCreatedMessage());

            Assert.True(!_computerBasedHome.VerifyCreatedComputerCreatedMessage(Resources.UI.TestData.ComputerName));
        }

        [Test]
        [Category("UI")]
        public void SearchForComputer()
        {
            _childTest = _createChildNode(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            _computerBasedHome = new ComputerBasedHomePage(_driver, _childTest);

            _computerBasedHome.SearchComputerNameInSearchBox(Resources.UI.TestData.SearchComputerName);

            Assert.True(_computerBasedHome.FindTheComputerNameInTable(Resources.UI.TestData.SearchComputerName));
        }

        [Test]
        [Category("UI")]
        public void EditExistingComputer()
        {
            _childTest = _createChildNode(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());

            _computerBasedHome = new ComputerBasedHomePage(_driver, _childTest);

            _computerBasedHome.SearchComputerNameInSearchBox(Resources.UI.TestData.SearchComputerName);

            _computerBasedHome.EditComputerData(Resources.UI.TestData.SearchComputerName);

            _computerBasedHome.ClickonSaveComputerData();

            Assert.True(_computerBasedHome.VerifyCreatedComputerCreatedMessage());

            Assert.True(_computerBasedHome.VerifyCreatedComputerCreatedMessage(Resources.UI.TestData.SearchComputerName));
        }
    }
}