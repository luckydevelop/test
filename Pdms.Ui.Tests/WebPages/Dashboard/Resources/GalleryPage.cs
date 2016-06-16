using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Kliiko.Ui.Tests.WebPages.Dashboard.Resources
{
    class GalleryPage : WebPage
    {
        private static readonly By ButtonChangeView = By.XPath(".//*[@id='GalleryController']/ng-include/div[1]/div/div/div[2]/button");
        private static readonly By ButtonAddNewResource = By.Id("uploadResourceDropdown");
        private static readonly By ButtonDownLoad = By.XPath(".//*[@id='select-section']/button[1]");
        private static readonly By ButtonDelete = By.XPath(".//*[@id='select-section']/button[2]");

        private static readonly By CheckboxSelectAll = By.Id("selectAll");

        private static readonly By LinkAchive = By.PartialLinkText("Achive");
        private static readonly By LinkYoutube = By.PartialLinkText("Youtube");
        private static readonly By LinkVideo = By.PartialLinkText("Video");
        private static readonly By LinkPdf = By.PartialLinkText("PDF");
        private static readonly By LinkAudio = By.PartialLinkText("Audio");
        private static readonly By LinkLogo = By.PartialLinkText("Brand Logo");
        private static readonly By LinkImage = By.PartialLinkText("Image");
        private static readonly By LinkAll = By.PartialLinkText("All");
    }
}
