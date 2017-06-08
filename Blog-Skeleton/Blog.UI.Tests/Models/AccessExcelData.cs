using Blog.UI.Tests.Models;
using Configuration;
using Dapper;
using System;
using System.Data.OleDb;
using System.IO;
using System.Linq;


namespace Blog.UI.Tests.Models
{
    public class AccessExcelData
    {
        private static string _testExcelFiles = "";
        public static string TestDataFileConnection()
        {
            var filename = "UserData.xlsx";
            var path = ConfigurationManager.AppSettings["TestDataSheetPath"];
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            else
                _testExcelFiles = Path.Combine(path, filename);

            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;
		                              Data Source = {0}; 
		                              Extended Properties=Excel 12.0;", _testExcelFiles);
            return con;
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

        public static Post GetPostTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [PostDataSet$] where key = '{0}'", keyName);
                var value = connection.Query<Post>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}
