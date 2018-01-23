using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.IO;
using ProteusWeb.WrapperFactory;
using ProteusWeb.SuppportingUtilites;

namespace ProteusWeb
{
    [SetUpFixture]
    public class ExtentManager
    {
        static ExtentHtmlReporter htmlReporter;
        static ExtentReports extent;
        static ExtentTest test;

        static string strResultPath;
        public static string strReportPath;
        public static string strDataSheetPath;
        public static string strScreenshotPath;

        public static int i = 0;

      
        [OneTimeSetUp]
        public static void initializeReports()
        {
            //Get the Reports Folder Path from the App Config
            string strReportsFolderPath = ConfigurationManager.AppSettings["ReportsPath"];

            //Create a Result Folder based on datetime
            strResultPath = strReportsFolderPath + "Result_" + DateTime.Now.ToString("dd_MM_yyyy_hh_mm");

            //Create the Results Directory if it does not exists
            if (!Directory.Exists(strResultPath))
                Directory.CreateDirectory(strResultPath);

            //Get the report.html path
            strReportPath = strResultPath + "\\Report.html";
            strDataSheetPath = strResultPath + "\\TestData";

            //Get the Screenshot Path
            strScreenshotPath = strResultPath + "\\Screenshot";

            //Create the Screenshot Directory if it does not exists
            if (!Directory.Exists(strScreenshotPath))
                Directory.CreateDirectory(strScreenshotPath);

            //Setup the Report
            setupReport(strReportPath);
        }

        [OneTimeTearDown]
        public static void cleanupReports()
        {
            //Delete the unmanaged resources
            extent.Flush();
        }

        public ExtentManager()
        {

        }

   
        public static void setupReport(string strPath)
        {
            //Create the object for Extent Reports
            htmlReporter = new ExtentHtmlReporter(strPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            //Set the Document Title
            htmlReporter.Configuration().DocumentTitle = "RA Automation";

            //Set the Report Name
            htmlReporter.Configuration().ReportName = "Build-1";
        }

       
        public static void createTest(string strTestname)
        {
            //Create a test in Extent Reports
            test = extent.CreateTest(strTestname + "[" + i + "]", null);
            i++;
        }

 
        public static void Pass(string strMessage)
        {
            //Log the Message with status pass in Extent Reports
            test.Log(Status.Pass, strMessage);
        }

        public static void Skip(string strMessage)
        {
            //Log the Message with status pass in Extent Reports
            test.Log(Status.Skip, strMessage);
        }

        public static void Fail(string strErrorMessage, string strScreenPath)
        {
            //Log the Error Message with status Fail in Extent Reports
            test.Fail(strErrorMessage, MediaEntityBuilder.CreateScreenCaptureFromPath(strScreenPath).Build());
        }

   
        public static void endTest_Old()
        {
            //Get the Current Test Outcome Status
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            //get the Stack Trace
            var strStackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";

            //Get the Failed Error Message
            var strErrorMessage = TestContext.CurrentContext.Result.Message;

            //If the status is Failed get the Screenshot and Fail
            if (status == TestStatus.Failed)
            {
                Screenshot ss = ((ITakesScreenshot)BrowserFactory.Driver).GetScreenshot();
                string strScreenshot = ss.AsBase64EncodedString;
                byte[] screenshotasbytearray = ss.AsByteArray;
                string screenPath = strScreenshotPath + "\\Screenshot_" + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + ".png";
                ss.SaveAsFile(screenPath, ScreenshotImageFormat.Png);
                ss.ToString();

                Fail(strErrorMessage + strStackTrace, screenPath);
            }
        }

        public static void Fail(string strErrorMessage)
        {
            //Log the Error Message with status Fail in Extent Reports
            test.Fail(strErrorMessage);
        }


        public static void endTest()
        {
            //Get the Current Test Outcome Status
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            //get the Stack Trace
            var strStackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";

            //Get the Failed Error Message
            var strErrorMessage = TestContext.CurrentContext.Result.Message;
            if(ConfigurationManager.AppSettings["CopyDataSheet"] == "Yes")
                File.Copy(GeneralUtilites.strDatasheetPath, ExtentManager.strDataSheetPath + ".xlsx", true);

        }

    }
}
