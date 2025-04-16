using OpenQA.Selenium;
using TestAutomation.Utilities;

namespace TestAutomation.Pages
{
    public class AlertsPage : BasePage
    {
        // Locators for the buttons that trigger different types of alerts
        private readonly By simpleAlertButton = By.Id("alertButton");
        private readonly By confirmAlertButton = By.Id("confirmButton");
        private readonly By promptAlertButton = By.Id("promtButton");

        public AlertsPage(IWebDriver driver) : base(driver) { }

        // Navigate to the Alerts page
        public void NavigateTo() => driver.Navigate().GoToUrl("https://demoqa.com/alerts");

        // Trigger Simple Alert
        public void TriggerSimpleAlert() => Click(simpleAlertButton);

        // Trigger Confirm Alert
        public void TriggerConfirmAlert() => Click(confirmAlertButton);

        // Trigger Prompt Alert
        public void TriggerPromptAlert() => Click(promptAlertButton);

        // Accept an alert
        public void AcceptAlert() => driver.SwitchTo().Alert().Accept();

        // Dismiss an alert (click "Cancel")
        public void DismissAlert() => driver.SwitchTo().Alert().Dismiss();

        // Enter text into a prompt alert
        public void EnterTextInAlert(string text)
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys(text);
            alert.Accept();
        }
    }
}
