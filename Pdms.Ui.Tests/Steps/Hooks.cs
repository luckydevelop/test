using System.Drawing.Imaging;
using Kliiko.Ui.Tests.Environment;
using Kliiko.Ui.Tests.Selenium;
using Kliiko.Ui.Tests.Utils;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Kliiko.Ui.Tests.Steps
{
    [Binding]
    public sealed class Hooks
    {
        
        [BeforeFeature]
        private static void BeforeFeature()
        {
            Log.StartFeature(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        private void BeforeScenario()
        {
            Log.StartScenario(ScenarioContext.Current.ScenarioInfo.Title);
        }

        //[AfterScenario]
        //public void TakeScreeShot()
        //{
        //   if (ScenarioContext.Current.TestError != null)
        //    {
        //        TakeScreeShot(WebApplications.Web.WebDriver);
        //    }
        //}
        
        [AfterScenario]
        public void CloseSession()
        {
            WebApplications.QuitDriver();
        }
        
        private void TakeScreeShot(IWebDriver driver)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string featureName = FeatureContext.Current.FeatureInfo.Title;
            string scenarioName = ScenarioContext.Current.ScenarioInfo.Title;
            string subFolderName = Config.ScreenShotPath + featureName.Substring(0, 15);
            System.IO.Directory.CreateDirectory(subFolderName);
            screenshot.SaveAsFile(subFolderName +"\\" + scenarioName + ".png", ImageFormat.Png); //добавить в константы
        }

    }
}
