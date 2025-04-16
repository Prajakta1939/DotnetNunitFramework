using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestAutomation.Utilities
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void Click(By locator) =>
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator)).Click();

        public void EnterText(By locator, string text)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)).Clear();
            driver.FindElement(locator).SendKeys(text);
        }

        public string GetText(By locator) =>
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)).Text;
    }
}
