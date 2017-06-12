using Blog.UI.Tests.Models;
using System.Configuration;
using Dapper;
using System;
using System.Data.OleDb;
using System.Linq;


namespace Blog.UI.Tests.Models
{
    public class AccessExcelData<T>
    {
        private static string pathToExcel = "";
        public static string TestDataFileConnection()
        {
            var path = ConfigurationManager.AppSettings["TestDataSheetPath"];
            //get the full path to this.project dll. See App.config for more
            var relativePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //replace the path to point to the excell databind
            pathToExcel = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;
		                              Data Source = {0}; 
		                              Extended Properties=Excel 12.0;", 
                                      System.IO.Path.Combine(relativePath.Replace("\\bin\\Debug\\Blog.UI.Tests.dll", String.Empty)
                                      .ToString(), path));
            return pathToExcel;
        }

        public static T GetTestData(string sheet, string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [{0}$] where key = '{1}'", sheet, keyName);
                var value = connection.Query<T>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }

        //public static User GetUserTestData(string keyName)
        //{
        //    using (var connection = new OleDbConnection(TestDataFileConnection()))
        //    {
        //        connection.Open();
        //        var query = string.Format("select * from [UserDataSet$] where key = '{0}'", keyName);
        //        var value = connection.Query<User>(query).FirstOrDefault();
        //        connection.Close();
        //        return value;
        //    }
        //}
    }
}