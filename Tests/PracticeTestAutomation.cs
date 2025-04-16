using NUnit.Framework;
using OpenQA.Selenium;
using TestAutomation.Drivers;
using TestAutomation.Pages;
using TestAutomation.Utilities;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;


namespace TestAutomation.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    [AllureSuite("Practice Test Automation")]
    public class PracticeTestAutomation
    {
        private IWebDriver driver;
        private TestLoginPage loginPage;
        private ExtentReports extent = ExtentReportManager.GetInstance();
        private ExtentTest test;


        [SetUp]
        public void SetUp()
        {
            WebDriverSetup setup = new WebDriverSetup();
            driver = setup.InitializeDriver();
            loginPage = new TestLoginPage(driver);
        }

        [Test, Order(1)]
        [AllureName("Navigate to Practice Page")]
        [AllureSeverity(SeverityLevel.normal)]
        public void NavigateToPracticePageTest()
        {
            test = extent.CreateTest("Navigate to Practice Page");

            try
            {
                loginPage.NavigateToLoginPage();
                loginPage.ClickPracticeMenu();
                WaitHelper.WaitForElementVisible(driver, By.TagName("h1"));

                string actualTitle = loginPage.GetPostTitle();
                Assert.That(actualTitle, Is.EqualTo("Practice"), "Practice Page Title Mismatch");

                test.Pass("Successfully navigated to Practice Page and verified title.");
            }
            catch (Exception ex)
            {
                test.Fail($"Navigation test failed: {ex.Message}");
                throw;
            }
        }

        [Test, Order(2)]
        [AllureName("Test Exceptions Page Actions")]
        [AllureSeverity(SeverityLevel.normal)]
        public void TestExceptionsPageTest()
        {
            test = extent.CreateTest("Test Exceptions Page Actions");

            try
            {
                loginPage.NavigateToLoginPage();
                loginPage.ClickPracticeMenu();
                WaitHelper.WaitForElementVisible(driver, loginPage.TestExceptionsLink);
                loginPage.ClickTestExceptions();
                WaitHelper.WaitForElementVisible(driver, loginPage.EditButton);
                loginPage.EditFirstRow();

                test.Pass("Successfully performed actions on Test Exceptions page.");
            }
            catch (Exception ex)
            {
                test.Fail($"Exception handling failed: {ex.Message}");
                throw;
            }
        }

        [Test, Order(3)]
        [AllureName("Edit Food Items Inline Test")]
        [AllureSeverity(SeverityLevel.normal)]
        public void EditFoodItemsInlineTest()
        {
            test = extent.CreateTest("Edit Food Items Inline Test");

            try
            {
                loginPage.NavigateToLoginPage();
                loginPage.ClickPracticeMenu();
                WaitHelper.WaitForElementVisible(driver, loginPage.TestExceptionsLink);
                loginPage.ClickTestExceptions();
                WaitHelper.WaitForElementVisible(driver, loginPage.EditButton);

                driver.FindElement(loginPage.EditButton).Click();
                var inputFields = driver.FindElements(loginPage.InputFields);
                inputFields[0].Clear();
                inputFields[0].SendKeys("Idli");
                WaitHelper.WaitForClickable(driver, loginPage.SaveButton);
                driver.FindElement(loginPage.SaveButton).Click();

                driver.FindElement(loginPage.EditButton).Click();
                inputFields = driver.FindElements(loginPage.InputFields);
                inputFields[0].Clear();
                inputFields[0].SendKeys("Dosa");
                WaitHelper.WaitForClickable(driver, loginPage.SaveButton);
                driver.FindElement(loginPage.SaveButton).Click();

                test.Pass("Successfully edited food items to Idli and Dosa.");
            }
            catch (Exception ex)
            {
                test.Fail($"Edit operation failed: {ex.Message}");
                throw;
            }
        }

        [Test, Order(4)]
        [AllureName("Login Test Using CSV Data")]
        [AllureSeverity(SeverityLevel.normal)]
        public void LoginTest_WithCsvData()
        {
            test = extent.CreateTest("Login Test Using CSV Data");

            var testData = CsvReader.ReadCsv("TestData/TestData.csv");

            foreach (var data in testData)
            {
                string username = data["Username"];
                string password = data["Password"];
                string expectedTitle = data["ExpectedTitle"];

                try
                {
                    loginPage.NavigateToLoginPage();
                    loginPage.PerformLogin(username, password);

                    string actualTitle = loginPage.GetPostTitle();
                    Assert.That(actualTitle, Is.EqualTo(expectedTitle), $"Login failed for user: {username}");

                    test.Pass($"Login passed for user: {username}");
                }
                catch (Exception ex)
                {
                    test.Fail($"Login failed for user: {username}. Error: {ex.Message}");
                }
            }

            test.Info("CSV-based login test completed.");
        }

        [Test, Order(5)]
        [AllureName("Login Test Using Excel Data")]
        [AllureSeverity(SeverityLevel.normal)]
        public void LoginTest_WithExcelData()
        {
            test = extent.CreateTest("Login Test Using Excel Data");

            var testData = ExcelReader.ReadExcel("TestData/LoginTestData.xlsx");

            foreach (var data in testData)
            {
                string username = data["Username"];
                string password = data["Password"];
                string expectedTitle = data["ExpectedTitle"];

                try
                {
                    loginPage.NavigateToLoginPage();
                    loginPage.PerformLogin(username, password);

                    string actualTitle = loginPage.GetPostTitle();

                    if (actualTitle == expectedTitle)
                    {
                        test.Pass($"Login result matched for user: {username}");
                    }
                    else
                    {
                        test.Fail($"Expected: '{expectedTitle}', but got: '{actualTitle}' for user: {username}");
                        Assert.Fail($"Mismatch for user: {username}");
                    }
                }
                catch (Exception ex)
                {
                    test.Fail($"Exception during login for user: {username}. Error: {ex.Message}");
                    Assert.Fail($"Login failed for user: {username}. Error: {ex.Message}");
                }
            }

            test.Info("Excel-based login test completed.");
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
            extent.Flush();
        }
    }
}
