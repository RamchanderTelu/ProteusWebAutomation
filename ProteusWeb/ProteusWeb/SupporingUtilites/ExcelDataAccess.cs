using Dapper;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Reflection; 
using System.Configuration;

namespace ProteusWeb.Extensions
 
{
    class ExcelDataAccess
    {
        public static string sStrProjectPath;      

      
        public static string testDataFileConnection(string fileName)
        {
            //Get the Projects Assembly path
            string strPath = Assembly.GetExecutingAssembly().CodeBase;

            //Substring it upto bin
            string strActualpath = strPath.Substring(0, strPath.LastIndexOf("bin"));

            //Get the Projects Path
            sStrProjectPath = new Uri(strActualpath).LocalPath;

            //Get the Datasheet.xlsx Path
            var strFileName = sStrProjectPath + "TestData\\" + fileName;

            //var strFileName = sStrProjectPath + "TestData\\RegDataSheet.xlsx";

            //Get the Connection String for the Datasheet.xlsx
            var strCon = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Extended Properties= ""Excel 12.0;ReadOnly=False;HDR=Yes;""", strFileName);

            //Return the connection string
            return strCon;
        }


     
        public static IEnumerable<T> getTestData<T>(string fileName, string strKeyName) where T : new()
        {
            //Get the Connection String
            string strConString = testDataFileConnection(fileName);

            //Execute the query and return the result as IEnumerable
            using (var con = new OleDbConnection(strConString))
            {             
                con.Open();
                var strQuery = string.Format("select * from [{0}$]", strKeyName);
                var value = con.Query<T>(strQuery);
                con.Close();
                return value;
            }
        }


        public static bool updateResponseData(string fileName, string strKeyName, string strTestName, string strColunmName, string strColunmValue)
        {
            //Get the Connection String
            string strConString = testDataFileConnection(fileName);

            //Execute the query and return the result as IEnumerable
            using (var con = new OleDbConnection(strConString))
            {
                con.Open();
                var strQuery = string.Format("UPDATE [{0}$] SET " + strColunmName + " = @Value    WHERE TestName = @TestName", strKeyName);
                var value = con.Execute(strQuery, new { @Value = strColunmValue, @TestName = strTestName });
                con.Close(); 
                return true;
            }
        }

        public static void ClearActualResults(string TestName)
        {
            updateQuoteResults(TestName, "ActualQuotesCount", "0");
            updateQuoteResults(TestName, "ActualErrorsCount", "0");
            // ExcelDataAccess.ClearActualResults(TestName, "ActualQuotesCount");
            // ExcelDataAccess.ClearActualResults(TestName, "ActualErrorsCount");
            ExcelDataAccess.ClearActualResults(TestName, "IterationStartDateTime");
            ExcelDataAccess.ClearActualResults(TestName, "IterationEndDateTime");
            ExcelDataAccess.ClearActualResults(TestName, "TRAQuoteNumber");
            ExcelDataAccess.ClearActualResults(TestName, "GAQuoteNumber");
            ExcelDataAccess.ClearActualResults(TestName, "TRAResultQuoteDetails");
            ExcelDataAccess.ClearActualResults(TestName, "GAResultQuoteDetails");
            ExcelDataAccess.ClearActualResults(TestName, "TRAErrorDetails");
            ExcelDataAccess.ClearActualResults(TestName, "GAErrorDetails");
            ExcelDataAccess.ClearActualResults(TestName, "ValidationErrors");
        }

        public static bool ClearActualResults(  string strTestName, string strColunmName )
        {
            //Get the Connection String

            string fileName = ConfigurationManager.AppSettings["DataFileName"];
            string strKeyName = ConfigurationManager.AppSettings["DataSheetName"];
            string strConString = testDataFileConnection(fileName);

            //Execute the query and return the result as IEnumerable
            using (var con = new OleDbConnection(strConString))
            {
                con.Open();
                var strQuery = string.Format("UPDATE [{0}$] SET " + strColunmName + " = null   WHERE TestName = @TestName", strKeyName);
                var value = con.Execute(strQuery, new {   @TestName = strTestName });
                con.Close();
                return true;
            }
        }

        public static bool updateQuoteResults(string strTestName, string strColunmName, string strColunmValue)
        {
            return updateResponseData(ConfigurationManager.AppSettings["DataFileName"], ConfigurationManager.AppSettings["DataSheetName"] , strTestName, strColunmName, strColunmValue);
        }
    }
}
