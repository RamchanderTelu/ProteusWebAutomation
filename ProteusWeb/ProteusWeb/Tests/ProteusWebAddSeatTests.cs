using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using ProteusWeb.PageObjects;
using ProteusWeb.Extensions;
using ProteusWeb.WrapperFactory;
using ProteusWeb.Models;
using ProteusWeb.SuppportingUtilites;
using System.Reflection;

namespace ProteusWeb
{
    public class ProteusWebAddSeatTests
    {
        static IEnumerable<ProteusWebTestData> ProteusWebTestData = ExcelDataAccess.getTestData<ProteusWebTestData>(ConfigurationManager.AppSettings["DataFileName"], ConfigurationManager.AppSettings["DataSheetName"]);

        [SetUp]
        public void ProteusWebSeatTests()
        {
            GeneralUtilites.KillProcesses();
            GeneralUtilites.setDataSheetPath();
            //Get the Projects Assembly path
            string strPath = Assembly.GetExecutingAssembly().CodeBase;
            //Substring it upto bin
            string strActualpath = strPath.Substring(0, strPath.LastIndexOf("bin"));
            //Get the Projects Path
            ExcelDataAccess.sStrProjectPath = new Uri(strActualpath).LocalPath;
            ExtentManager.createTest(TestContext.CurrentContext.Test.MethodName);
        }

        [Test , TestCaseSource("ProteusWebTestData")]
        public void ProteusWebAddNewSeat(ProteusWebTestData data)
        {             
            GeneralUtilites.ContunieTest = true;
            //Get the URL from App Config
            string strUrl = ConfigurationManager.AppSettings["ProteusWebURL"];
            //Get the Username from App Config
            string strUserName = ConfigurationManager.AppSettings["AdminUserName"];
            //Get the Password from App Config
            string strPassword = ConfigurationManager.AppSettings["AdminPassword"];
            //Intiate the browser
            BrowserFactory.initBrowser(ConfigurationManager.AppSettings["Browser"]);
            BrowserFactory.loadApplication(strUrl);

            Page.ProteusWebLogin.loginToApplication(strUserName, strPassword);
            Page.ProteusWebHome.NavigateProteusAdministration();
            Page.ProteusWebSeatList.AddSeat();
            Page.ProteusWebSeatAdd.EnterNewSeatDetailsAndSave();       
        }

        [TearDown]
        public void getResult()
        {
    //       BrowserFactory.closeAllDrivers();
           ExtentManager.endTest();
        }
    }
}
