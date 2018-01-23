using NUnit.Framework;
using OpenQA.Selenium;
using ProteusWeb.Extensions;
using ProteusWeb.Models; 
using ProteusWeb.WrapperFactory;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace ProteusWeb.SuppportingUtilites
{
    public class GeneralUtilites
    {
        public static string randomStringGenerator(int intSize)
        {
            return new string(Enumerable.Repeat("ABCEHJKLMPRSTWXY", intSize).Select(s => s[new Random().Next(s.Length)]).ToArray()).ToString();
        }

        public static int RandomNumber(int Low, int High)
        {
            return new Random().Next(Low, High);
        }

        public static void wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        public static string strDatasheetPath;

        public static void setDataSheetPath()
        {
            string strPath = Assembly.GetExecutingAssembly().CodeBase;
            //Substring it upto bin
            string strActualpath = strPath.Substring(0, strPath.LastIndexOf("bin"));
            //Get the Datasheet.xlsx Path
            strDatasheetPath = new Uri(strActualpath).LocalPath + "TestData\\" + ConfigurationManager.AppSettings["DataFileName"];

        }

        public static void wait(double seconds)
        {
            Thread.Sleep((int)(seconds * 1000));
        }

        public static void KillProcesses(string processName = "")
        {
            try
            {
                var chromeDriverProcesses = Process.GetProcesses().
                                     Where(pr => pr.ProcessName == "chromedriver");

                foreach (var process in chromeDriverProcesses)
                {
                    process.Kill();
                }

                GeneralUtilites.wait(1);

                chromeDriverProcesses = Process.GetProcesses().
                                     Where(pr => pr.ProcessName == "chrome");

                foreach (var process in chromeDriverProcesses)
                {
                    process.Kill();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        } 
 
    }
   
}
