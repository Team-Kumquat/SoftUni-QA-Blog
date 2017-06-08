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
        public static string TestDataFileConnection()
        {
            var path = ConfigurationManager.AppSettings["TestDataSheetPath"];
            var filename = "UserData.xlsx";
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;
		                              Data Source = {0}; 
		                              Extended Properties=Excel 12.0;", path + filename);
            return con;
        }
    
    }
}
