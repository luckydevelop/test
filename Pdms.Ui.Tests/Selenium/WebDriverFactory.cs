using OpenQA.Selenium;
using Kliiko.Ui.Tests.Selenium.Driver;

namespace Kliiko.Ui.Tests.Selenium
{
    class WebDriverFactory
    {
        public static IWebDriver FirefoxDriver
        {
            get { return FirefoxDriverProvider.FireFoxDriver; }
        }

        public static IWebDriver ChromeDriver
        {
            get { return ChromeDriverProvider.ChromeDriver; }
        }
    }
}
