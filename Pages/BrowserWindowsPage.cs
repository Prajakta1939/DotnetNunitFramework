using OpenQA.Selenium;
using TestAutomation.Utilities;

namespace TestAutomation.Pages
{
    public class BrowserWindowsPage : BasePage
    {
        // Locator for the button that opens a new tab
        private readonly By newTabButton = By.Id("tabButton");

        public BrowserWindowsPage(IWebDriver driver) : base(driver) { }

        // Navigate to the Browser Windows page
        public void NavigateTo() => driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");

        // Click to open a new tab
        public void ClickNewTab() => Click(newTabButton);

        // Switch to the newly opened window (new tab)
        public void SwitchToNewWindow()
        {
            string originalWindow = driver.CurrentWindowHandle;
            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != originalWindow)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }
        }

        // Switch back to the original window
        public void SwitchToOriginalWindow()
        {
            string originalWindow = driver.CurrentWindowHandle;
            driver.SwitchTo().Window(originalWindow);
        }
    }
}
