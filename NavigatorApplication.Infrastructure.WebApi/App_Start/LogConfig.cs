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
        public static void Configure(string logFile, string logFolder)
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["SqlLiteConnStr"].ConnectionString;
            dbConnectionString = dbConnectionString.Replace("{LogFolder}", logFolder);
            
            
            if(!File.Exists(logFile))
            {
                // create log file
                // create new table
                SQLiteConnection.CreateFile(logFile);
                
                
                using (var dbConnection = new SQLiteConnection(dbConnectionString))
                {
                    dbConnection.Open();
                    
                    string sql = "create table Log4NetLog (Date datetime, Thread varchar(255), Level varchar(50), Logger varchar(500), Message ntext, Exception ntext)";

                    var command = new SQLiteCommand(sql, dbConnection);

                    command.ExecuteNonQuery();
                }
                
            }            
            
 





            
            //configure log4net
            var hierarchy = LogManager.GetRepository() as Hierarchy;
            if(hierarchy != null && hierarchy.Configured)
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