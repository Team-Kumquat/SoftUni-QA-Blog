using Blog.UI.Tests.Models;
using System.Configuration;
using Dapper;
using System;
using System.Data.OleDb;
using System.Linq;


namespace Blog.UI.Tests.Models
{
    public class AccessExcelData
    {
        private static string pathToExcel = "";
        public static string TestDataFileConnection()
        {
                var path = ConfigurationManager.AppSettings["TestDataSheetPath"];
                var relativepath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    pathToExcel = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;
		                              Data Source = {0}; 
		                              Extended Properties=Excel 12.0;", System.IO.Path.Combine(relativepath.Replace("\\bin\\Debug\\Blog.UI.Tests.dll", String.Empty).ToString(), path));
            return pathToExcel;
        }

        public static User GetUserTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [UserDataSet$] where key = '{0}'", keyName);
                var value = connection.Query<User>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}