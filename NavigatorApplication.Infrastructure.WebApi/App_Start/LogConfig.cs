using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;

namespace NavigatorApplication.Infrastructure.WebApi.App_Start
{
    public class LogConfig
    {
        public static void Configure(string logFolder)
        {
            var logFolderPattern = ConfigurationManager.AppSettings["LogFolderPattern"];
            string dbConnectionString = ConfigurationManager.ConnectionStrings["SqlLiteConnStr"].ConnectionString;
            var logFilePath = dbConnectionString.Substring(dbConnectionString.IndexOf(@"\", StringComparison.Ordinal), dbConnectionString.IndexOf(@";", StringComparison.Ordinal) - dbConnectionString.IndexOf(@"\", StringComparison.Ordinal));
            dbConnectionString = dbConnectionString.Replace(logFolderPattern, logFolder);
            var logFile = logFolder + @"\" + logFilePath;


            if (!File.Exists(logFile))
            {
                // create log file
                // create new table
                SQLiteConnection.CreateFile(logFile);

                using (var dbConnection = new SQLiteConnection(dbConnectionString))
                {
                    dbConnection.Open();
                    string sql = "create table HttpRequest (Date datetime, Headers varchar(1000), HttpMethod varchar(255), UriAccessed varchar(500),  IpAddress varchar(100), ContentType varchar(200), BodyContent ntext)";
                    var command = new SQLiteCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                }
            }

            //configure log4net
            var hierarchy = LogManager.GetRepository() as Hierarchy;
            if (hierarchy != null && hierarchy.Configured)
            {
                foreach (IAppender appender in hierarchy.GetAppenders())
                {
                    if (appender is AdoNetAppender)
                    {
                        var adoNetAppender = (AdoNetAppender)appender;
                        adoNetAppender.ConnectionString = dbConnectionString;
                        adoNetAppender.ActivateOptions();
                    }
                }
            }
        }
    }
}