using OpenQA.Selenium;
using Kliiko.Ui.Tests.Environment;
using Kliiko.Ui.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Firefox;

namespace Kliiko.Ui.Tests.Selenium
{
    class WebApplications
    {
        private static readonly ThreadLocal<WebApplication> WebHolder = new ThreadLocal<WebApplication>();
        private static string _browserName = Config.DefaultBrowser;

        public static void ChangeBrowserName(string newBrowserName)
        {
            if (!_browserName.Equals(newBrowserName))
            {
                _browserName = newBrowserName;
            }
        }

        public static WebApplication Web
        {
           get {return NewOrExistingWebApplication(WebHolder); }
        }
        
        private static WebApplication NewOrExistingWebApplication(ThreadLocal<WebApplication> holder) //т.е. в Холдере Синглтон WebApplication , зачем добавляли в Thread
        {
            if (holder.Value == null)
            {
                holder.Value = NewWebApplication();
            }

            return holder.Value;
        }
        
        public static WebApplication NewWebApplication()
        {
            return new WebApplication(NewWebDriver());
        }

        public static IWebDriver NewWebDriver()
        {
            //string browser = browserName;
            switch (_browserName.ToLower())
            {
                case "firefox":
                 return new FirefoxDriver();

                case "firefox kliiko":
                    var allProfiles = new FirefoxProfileManager();

                    if (!allProfiles.ExistingProfiles.Contains("Kliiko"))
                    {
                        throw new Exception("SeleniumUser firefox profile does not exist, please create it first.");
                    }
                    var profile = allProfiles.GetProfile("Kliiko");

                    profile.SetPreference("webdriver.firefox.profile", "Kliiko");

                    return new FirefoxDriver(profile);

                case "chrome":
                    return WebDriverFactory.ChromeDriver;
                default: throw new ArgumentException(string.Format("No such driver '{0}' available!", _browserName));
            }
        }

        public static void PrepareEnvironment()
        {
            ApplicationContext.UserDrivers = new Dictionary<string, IWebDriver>();
        }



        public static void QuitDriver()
        {
           if (WebHolder.Value != null)
            {
                WebHolder.Value.WebDriver.Quit();
                WebHolder.Value = null;
            }
        }




        public static void TearDown()
        {
            try { }
            finally
            {
                foreach (var driver in ApplicationContext.UserDrivers.Values)
                {
                    if(Config.StayAlive != "true")
                    {
                        driver.Quit();
                    }
                    
                }
            }
        }
    }
}
