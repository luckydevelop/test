using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace Kliiko.Ui.Tests.Selenium.Driver
{
    class ChromeDriverProvider
    {

        private static string ChromeDriverPath = String.Format("{0}Resources{0}Drivers{0}Chrome", Path.AltDirectorySeparatorChar);
       // private static string ChromeDriverPath = String.Format($"{Path.AltDirectorySeparatorChar}Resources{Path.AltDirectorySeparatorChar}Drivers{Path.AltDirectorySeparatorChar}Chrome");
        //private const string ChromeDriverPath = @"\Resources\Drivers\Chrome";

        public static IWebDriver ChromeDriver
        {
            get
            {
                string test = String.Format("{0}{1}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), ChromeDriverPath);
                var chromeDriver = new ChromeDriver(String.Format("{0}{1}", Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), ChromeDriverPath), ChromeOptions);
                return chromeDriver;
            }
        }

        private static ChromeOptions ChromeOptions
        {
            get
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("--disable-cache", "--aggressive-cache-discard");
                //chromeOptions.BinaryLocation = executablePath;
                return chromeOptions;
            }
        }
    }
}
