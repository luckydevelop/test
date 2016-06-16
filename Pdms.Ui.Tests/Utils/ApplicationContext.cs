using System.Collections.Generic;
using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.Utils
{
    class ApplicationContext
    {
        public static Dictionary<string, IWebDriver> UserDrivers { get; set; } //по-умолчанию тут пустая коллекция Dictionary?
    }
}
