using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace TestAutomation.Drivers
{
    public class WebDriverSetup
    {
        public static IWebDriver InitializeDriver(string browserName = "chrome")
        {
            IWebDriver driver;

            if (browserName.ToLower() == "edge")
            {
                var edgeOptions = new EdgeOptions();
                // Remove or comment out edgeOptions.UseChromium = true;
                // It's either default or can be configured differently.
                driver = new EdgeDriver(edgeOptions);
            }
            else // default is chrome
            {
                var chromeOptions = new ChromeOptions();
                driver = new ChromeDriver(chromeOptions);
            }

            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
