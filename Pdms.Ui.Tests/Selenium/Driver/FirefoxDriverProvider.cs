using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Kliiko.Ui.Tests.Selenium.Driver
{
    class FirefoxDriverProvider
    {
        public static IWebDriver FireFoxDriver
        {
            get { return new FirefoxDriver(FirefoxProfile); }
        }

        private static FirefoxProfile FirefoxProfile
        {
            get
            {
                FirefoxProfile firefoxProfile = new FirefoxProfile();

                firefoxProfile.AcceptUntrustedCertificates = true;
                firefoxProfile.SetPreference("browser.cache.disk.enable", false);
                firefoxProfile.SetPreference("browser.cache.memory.enable", false);
                firefoxProfile.SetPreference("browser.cache.offline.enable", false);
                firefoxProfile.SetPreference("network.http.use-cache", false);
                firefoxProfile.SetPreference("browser.download.folderList", 2);
                //firefoxProfile.SetPreference("browser.download.dir", "");
                firefoxProfile.SetPreference("browser.download.manager.showWhenStarting", false);

                firefoxProfile.SetPreference("browser.helperApps.neverAsk.saveToDisk",
                        string.Format("text{0}csv,application{0}x-msexcel,application{0}excel,application{0}x-excel,application{0}vnd.ms-excel,image{0}png,image{0}jpeg,text{0}html,text{0}plain,application{0}msword,application{0}xml,application{0}json", Path.AltDirectorySeparatorChar));

                //firefoxProfile.SetPreference("browser.helperApps.neverAsk.saveToDisk",
                //       "text/csv,application/x-msexcel,application/excel,application/x-excel,application/vnd.ms-excel,image/png,image/jpeg,text/html,text/plain,application/msword,application/xml,application/json");
                
                firefoxProfile.SetPreference("browser.helperApps.alwaysAsk.force", false);
                firefoxProfile.SetPreference("browser.download.manager.alertOnEXEOpen", false);
                firefoxProfile.SetPreference("browser.download.manager.focusWhenStarting", false);
                firefoxProfile.SetPreference("browser.download.manager.useWindow", false);
                firefoxProfile.SetPreference("browser.download.manager.showAlertOnComplete", false);
                firefoxProfile.SetPreference("browser.download.manager.closeWhenDone", false);

                return firefoxProfile;
            }
        }
    }
}
