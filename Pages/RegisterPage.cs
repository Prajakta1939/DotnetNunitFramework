using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace TestAutomation.Pages
{
    public class RegisterPage
    {
        private readonly IWebDriver driver;

        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToRegisterPage()
        {
            driver.Navigate().GoToUrl("https://demo.automationtesting.in/Register.html");
        }

        // Text fields
        public By FirstName => By.XPath("//input[@placeholder='First Name']");
        public By LastName => By.XPath("//input[@placeholder='Last Name']");
        public By Address => By.XPath("//textarea[@ng-model='Adress']");
        public By Email => By.XPath("//input[@type='email']");
        public By Phone => By.XPath("//input[@type='tel']");

        // Radio buttons
        public By GenderMale => By.XPath("//input[@value='Male']");
        public By GenderFemale => By.XPath("//input[@value='FeMale']");

        // Checkboxes
        public By HobbiesCricket => By.Id("checkbox1");
        public By HobbiesMovies => By.Id("checkbox2");
        public By HobbiesHockey => By.Id("checkbox3");

        // Dropdowns
        public By SkillsDropdown => By.Id("Skills");
        public By CountryDropdown => By.Id("countries");
        public By SelectCountryDropdown => By.XPath("//span[@role='combobox']");
        public By SelectCountryInput => By.XPath("//input[@type='search']");
        public By YearDropdown => By.Id("yearbox");
        public By MonthDropdown => By.XPath("//select[@placeholder='Month']");
        public By DayDropdown => By.Id("daybox");

        // Password fields
        public By Password => By.Id("firstpassword");
        public By ConfirmPassword => By.Id("secondpassword");

        // Submit
        public By SubmitButton => By.Id("submitbtn");

        // Method to fill the registration form
        public void FillRegistrationForm(
            string firstName, 
            string lastName, 
            string address,
            string email, 
            string phone, 
            string gender, 
            string[] hobbies, 
            string skill,
            string selectCountry, 
            string birthYear, 
            string birthMonth,
            string birthDay, 
            string password, 
            string confirmPassword)
        {
            driver.FindElement(FirstName).SendKeys(firstName);
            driver.FindElement(LastName).SendKeys(lastName);
            driver.FindElement(Address).SendKeys(address);
            driver.FindElement(Email).SendKeys(email);
            driver.FindElement(Phone).SendKeys(phone);

            // Selecting Gender
            if (gender.ToLower() == "male")
                driver.FindElement(GenderMale).Click();
            else
                driver.FindElement(GenderFemale).Click();

            // Selecting hobbies
            if (hobbies.Contains("Cricket"))
                driver.FindElement(HobbiesCricket).Click();
            if (hobbies.Contains("Movies"))
                driver.FindElement(HobbiesMovies).Click();
            if (hobbies.Contains("Hockey"))
                driver.FindElement(HobbiesHockey).Click();

            // Selecting Skills
            new SelectElement(driver.FindElement(SkillsDropdown)).SelectByText(skill);

            // Selecting country from the dropdown
            driver.FindElement(SelectCountryDropdown).Click();
            driver.FindElement(SelectCountryInput).SendKeys(selectCountry + Keys.Enter);

            // Selecting Date of Birth
            new SelectElement(driver.FindElement(YearDropdown)).SelectByText(birthYear);
            new SelectElement(driver.FindElement(MonthDropdown)).SelectByText(birthMonth);
            new SelectElement(driver.FindElement(DayDropdown)).SelectByText(birthDay);

            // Filling Password
            driver.FindElement(Password).SendKeys(password);
            driver.FindElement(ConfirmPassword).SendKeys(confirmPassword);
        }

        // Method to submit the form
        public void SubmitForm()
        {
            driver.FindElement(SubmitButton).Click();
        }
    }
}
