using OpenQA.Selenium;
using System.Threading;
using TestAutomation.Utilities;

namespace TestAutomation.Pages
{
    public class TestLoginPage : BasePage
    {
        public TestLoginPage(IWebDriver driver) : base(driver) { }

        // Locators
        public By UsernameField = By.Id("username");
        public By PasswordField = By.Id("password");
        public By LoginButton = By.Id("submit");
        public By PostContent = By.CssSelector("p.has-text-align-center");
        public By PracticeMenu = By.CssSelector("#menu-item-20");
        public By PostTitleForPractice = By.CssSelector(".post-title");
        public By TestExceptionsLink = By.LinkText("Test Exceptions");
        public By EditButton = By.CssSelector("button#edit_btn");
        public By InputFields = By.CssSelector("input.input-field");
        public By SaveButton = By.CssSelector("button#save_btn");
        public By AddButton = By.CssSelector("button#add_btn");
        public By ConfirmationMessage = By.CssSelector("div#confirmation");

        // Actions
        public void NavigateToLoginPage()
        {
            driver.Navigate().GoToUrl(TestConfig.BaseUrl);
        }

        public void PerformLogin(string username, string password)
        {
            EnterText(UsernameField, username);
            EnterText(PasswordField, password);
            Click(LoginButton);
        }

        public string GetPostTitle()
        {
            return GetText(PostTitleForPractice);
        }

        public string GetPostContent()
        {
            return GetText(PostContent);
        }

        public void ClickPracticeMenu()
        {
            Click(PracticeMenu);
        }

        public void ClickTestExceptions()
        {
            Click(TestExceptionsLink);
        }

        public void EditFirstRow()
        {
            Click(EditButton);
            var inputFields = driver.FindElements(InputFields);
            inputFields[0].Clear();
            inputFields[0].SendKeys("Momos");
            Click(SaveButton);
            Click(AddButton);
            Thread.Sleep(9000); // Consider replacing this with explicit waits
        }
    }
}
