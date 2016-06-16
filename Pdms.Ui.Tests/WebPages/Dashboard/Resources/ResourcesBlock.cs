using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.WebPages.Dashboard.Resources
{
    class ResourcesBlock : WebPage
    {
        private static readonly By ButtonGallery = By.XPath(".//*[@id='dashboard']/div/section/div[1]/div/div[1]");
        private static readonly By ButtonContactList = By.XPath(".//*[@id='dashboard']/div/section/div[1]/div/div[2]");
        private static readonly By ButtonTopics = By.XPath(".//*[@id='dashboard']/div/section/div[1]/div/div[3]");
        private static readonly By ButtonEmailTemplates = By.XPath(".//*[@id='dashboard']/div/section/div[1]/div/div[4]");
        private static readonly By ButtonBrandColours = By.XPath(".//*[@id='dashboard']/div/section/div[1]/div/div[5]");

        public static void ClickButtonContactList()
        {
            Web.Click(ButtonContactList);
        }
    }
}
