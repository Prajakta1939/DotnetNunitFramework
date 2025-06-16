using NUnit.Framework;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using System;
using System.IO;
using TestAutomation.Drivers;
using TestAutomation.Pages;
using TestAutomation.Utilities;

namespace TestAutomation.Tests
{
    [TestFixture]
    public class RegisterFormTests : BaseTest
    {
        private IWebDriver driver;
        private RegisterPage registerPage;
        private ExtentReports extent = ExtentReportManager.GetInstance();
        private ExtentTest extentTest;

        [SetUp]
        public void SetUp()
        {
            driver = WebDriverSetup.InitializeDriver("edge");
            registerPage = new RegisterPage(driver);
        }

        [Test, Order(1)]
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
                        hobbies: data["Hobbies"].Split(','), // Assuming comma separated hobbies
                        skill: data["Skill"],
                        selectCountry: data["Country"],
                        birthYear: data["Birth Year"],
                        birthMonth: data["Birth Month"],
                        birthDay: data["Birth Day"],
                        password: data["Password"],
                        confirmPassword: data["Confirm Password"]
                    );

                    extentTest.Pass($"Submitted form for {data["First Name"]} {data["Last Name"]}");
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
    driver?.Quit();
    driver?.Dispose();
}


    }
}
