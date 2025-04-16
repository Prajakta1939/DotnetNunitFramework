using NUnit.Framework;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using TestAutomation.Drivers;
using TestAutomation.Pages;
using TestAutomation.Utilities;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;


namespace TestAutomation.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Registration Form Tests")]
    public class RegisterFormTests
    {
        private IWebDriver driver;
        private RegisterPage registerPage;
        private ExtentReports extent = ExtentReportManager.GetInstance();
        private ExtentTest extentTest;


        [SetUp]
        public void SetUp()
        {
            WebDriverSetup setup = new WebDriverSetup();
            driver = setup.InitializeDriver();
            registerPage = new RegisterPage(driver);
        }

        [Test, Order(1)]
        [AllureName("Fill and Submit Registration Form with Hardcoded Data")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureDescription("Test to verify registration form with hardcoded values")]
        [AllureTag("Hardcoded")]
        public void Test_FillAndSubmitRegistrationForm_WithHardcodedData()
        {
            extentTest = extent.CreateTest("Test_FillAndSubmitRegistrationForm_WithHardcodedData");

            try
            {
                extentTest.Info("Navigating to Register Page");
                registerPage.NavigateToRegisterPage();
                extentTest.Pass("Navigated to Register Page");

                extentTest.Info("Filling out the form with hardcoded data");
                registerPage.FillRegistrationForm(
                    firstName: "Amit",
                    lastName: "Sharma",
                    address: "123 MG Road, Pune",
                    email: "amit.sharma@example.com",
                    phone: "9876543210",
                    gender: "Male",
                    hobbies: new string[] { "Cricket", "Movies" },
                    skill: "Java",
                    selectCountry: "India",
                    birthYear: "1990",
                    birthMonth: "April",
                    birthDay: "15",
                    password: "Password123!",
                    confirmPassword: "Password123!"
                );
                extentTest.Pass("Filled and submitted form with hardcoded data");
            }
            catch (Exception e)
            {
                extentTest.Fail($"Test failed due to: {e.Message}");
                throw;
            }
        }

        [Test, Order(2)]
        [AllureName("Fill and Submit Registration Form Using Excel Data")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureDescription("Test to verify registration form using Excel test data")]
        [AllureTag("ExcelData")]
        public void Test_FillAndSubmitRegistrationForm_UsingExcelData()
        {
            extentTest = extent.CreateTest("Test_FillAndSubmitRegistrationForm_UsingExcelData");

            try
            {
                string excelPath = Path.Combine(Directory.GetCurrentDirectory(), "TestData", "RegistrationTestData.xlsx");
                var excelData = ExcelReader.ReadExcel(excelPath);

                foreach (var data in excelData)
                {
                    extentTest.Info("Navigating to Register Page");
                    registerPage.NavigateToRegisterPage();
                    extentTest.Pass("Navigated to Register Page");

                    extentTest.Info($"Filling out the form with Excel data: {data["First Name"]} {data["Last Name"]}");

                    registerPage.FillRegistrationForm(
                        firstName: data["First Name"],
                        lastName: data["Last Name"],
                        address: data["Address"],
                        email: data["Email"],
                        phone: data["Phone"],
                        gender: data["Gender"],
                        hobbies: data["Hobbies"].Split(','),
                        skill: data["Skill"],
                        selectCountry: data["Country"],
                        birthYear: data["Birth Year"],
                        birthMonth: data["Birth Month"],
                        birthDay: data["Birth Day"],
                        password: data["Password"],
                        confirmPassword: data["Confirm Password"]
                    );

                    extentTest.Pass($"Form filled and submitted for {data["First Name"]} {data["Last Name"]}");
                }
            }
            catch (Exception e)
            {
                extentTest.Fail($"Test failed due to: {e.Message}");
                throw;
            }
        }

        [TearDown]
        public void TearDown()
        {
            extent.Flush();
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
