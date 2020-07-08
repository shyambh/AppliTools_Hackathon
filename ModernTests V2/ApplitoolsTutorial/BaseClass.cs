using System;
using System.Collections.Generic;
using System.Text;
using Applitools;
using Applitools.Selenium;
using Applitools.VisualGrid;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Configuration = Applitools.Selenium.Configuration;
using ScreenOrientation = Applitools.VisualGrid.ScreenOrientation;

namespace ApplitoolsTutorial
{
    public class BaseClass
    {
        public static BatchInfo batch { get; set; }
        public IWebDriver webDriver { get; set; }
        public Eyes eyes { get; set; }
        public VisualGridRunner runner { get; set; }
        public Configuration config { get; set; }

        [SetUp]
        public void SetUp()
        {
            webDriver = new ChromeDriver();
            runner = new VisualGridRunner(10);
            config = new Configuration();
            
            eyes = new Eyes(runner)
            {
                ApiKey = Environment.GetEnvironmentVariable("APPLITOOLS_API_KEY", EnvironmentVariableTarget.User)
            };

            config.SetBatch(new BatchInfo("UFG Hackathon"));

            // Adding browsers with different viewports
            config.AddBrowser(1200, 700, BrowserType.CHROME);
            config.AddBrowser(1200, 700, BrowserType.FIREFOX);
            config.AddBrowser(1200, 700, BrowserType.EDGE_CHROMIUM);
            config.AddBrowser(768, 700, BrowserType.CHROME);
            config.AddBrowser(768, 700, BrowserType.FIREFOX);
            config.AddBrowser(768, 700, BrowserType.EDGE_CHROMIUM);

            // Adding mobile emulation devices in Portrait mode
            config.AddDeviceEmulation(DeviceName.iPhone_X, ScreenOrientation.Portrait);
            config.AddDeviceEmulation(DeviceName.Pixel_2, ScreenOrientation.Portrait);

            // Setting the configuration object to eyes
            eyes.SetConfiguration(config);
        }

        [TearDown]
        public void TearDownForEverySingleTestMethod()
        {
            //Close your Selenium browser
            webDriver.Quit();
            //Close applitools eyes so that your test run is saved
            eyes.Close();
            //Quit applitools if it is not already closed
            eyes.AbortIfNotClosed();
        }

        public void GoToApplication()
        {
            //This uses Selenium to navigate to a url of the page below
            webDriver.Navigate().GoToUrl("https://demo.applitools.com/gridHackathonV2.html");
        }

        public bool IsElementPresentByCssOrXpath( string locator, bool cssSelector = true)
        {
            bool elementPresent = true;

            try
            {
                var element = (cssSelector) ? webDriver.FindElement(By.CssSelector(locator)) : 
                    webDriver.FindElement(By.XPath(locator));
            }
            catch (Exception e)
            {
                elementPresent = false;
            }

            return elementPresent;
        }
    }
}
