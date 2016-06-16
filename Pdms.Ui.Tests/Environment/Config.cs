using System;
using System.Configuration;

namespace Kliiko.Ui.Tests.Environment
{
    class Config
    {
        public static string Browser
        {
            get { return ConfigurationManager.AppSettings["browser"]; }
        }
        public static string StayAlive
        {
            get { return ConfigurationManager.AppSettings["stayAlive"]; }
        }
        public static string HomePage
        {
            get { return ConfigurationManager.AppSettings["homePage"]; }
        }

        public static int TimeOut
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]); }
        }
        public static string Email
        {
            get { return (ConfigurationManager.AppSettings["Email"]); }
        }
        public static string Email2
        {
            get { return (ConfigurationManager.AppSettings["Email2"]); }
        }
        public static string Email3
        {
            get { return (ConfigurationManager.AppSettings["Email3"]); }
        }
        public static string Password
        {
            get { return (ConfigurationManager.AppSettings["Password"]); }
        }
        public static string PathPages
        {
            get { return (ConfigurationManager.AppSettings["pathPages"]); }
        }
        public static string DefaultBrowser
        {
            get { return (ConfigurationManager.AppSettings["defaultBrowser"]); }
        }
        public static string ScreenShotPath
        {
            get { return (ConfigurationManager.AppSettings["screenShotPath"]); }
        }
    }
}
