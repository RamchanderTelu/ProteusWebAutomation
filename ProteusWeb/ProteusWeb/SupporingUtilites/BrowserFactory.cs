using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Remote;
using ProteusWeb.Extensions;
using System.Security.Principal;

namespace ProteusWeb.WrapperFactory  
{
    class BrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;
        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The Webdriver Browser instance is not initialized. You should first call the method InitBrowser");

                return driver;
            }
            private set
            {
                driver = value;
            }
        } 
     
        public static IWebDriver initBrowser(string strBrowserName)
        {
            //Get the Libraries Path
            var librariespath = ExcelDataAccess.sStrProjectPath + "\\Libraries";

            //Launch the Browser based on the Browser name
            switch (strBrowserName)
            {
                case "Firefox":
                    if (driver == null)
                    {
                        driver = new FirefoxDriver();
                        Drivers.Add("Firefox", Driver);
                    }
                    break;

                case "IE":
                    if (driver == null)
                    {
                        InternetExplorerOptions options = new InternetExplorerOptions();
                        options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                        options.EnableNativeEvents = false;
                        driver = new InternetExplorerDriver(librariespath, options);
                        Drivers.Add("IE", Driver);
                    }
                    break;
                case "Chrome":
                    if (driver == null)
                    {
                        ChromeOptions options = new ChromeOptions();
                        string strOptions = "user-data-dir=C:\\Users\\" + WindowsIdentity.GetCurrent().Name.Split('\\')[1]  + "\\AppData\\Local\\Google\\Chrome\\User Data";
                        options.AddArguments(strOptions);
                        options.AddArgument("no-sandbox");
                        driver = new ChromeDriver(librariespath,options);
                        Drivers.Add("Chrome", Driver);
                    }
                    break;
                case "Headless":
                    if (driver == null)
                    {
                        driver = new RemoteWebDriver(DesiredCapabilities.HtmlUnit());                      
                        Drivers.Add("Headless", Driver);
                    }
                    break;
            }

            //Set the Timeouts
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.SwitchTo().DefaultContent();
            //Return the Driver
            return driver;
        }
       
        public static void loadApplication(string strUrl)
        {
            //Load the URL
            Driver.Url = strUrl;

        }
         
        public static void closeAllDrivers()
        {
            //Loop through and Close all the browsers
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }

            Drivers.Clear();
            driver = null;
        }
    }
}
