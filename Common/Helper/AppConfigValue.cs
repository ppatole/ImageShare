using System;
using System.Configuration;

namespace Utility.Helper
{
    public static class AppConfigValue
    {
        public static string WebBaseUrl { get { return ConfigurationManager.AppSettings["WebBaseUrl"].ToString(); } }

        public static string SMTP_User { get { return ConfigurationManager.AppSettings["smtpUser"].ToString(); } }
        public static string SMTP_Server { get { return ConfigurationManager.AppSettings["smtpServer"].ToString(); } }
        public static string SMTP_Password { get { return ConfigurationManager.AppSettings["smtpPass"].ToString(); } }
        public static string SMTP_Port { get { return ConfigurationManager.AppSettings["smtpPort"].ToString(); } }
        public static bool SMTP_SSL { get { return Convert.ToBoolean(ConfigurationManager.AppSettings["smtpSSL"]); } }
        public static string AdminEmail { get { return ConfigurationManager.AppSettings["AdminEmail"].ToString(); } }
    }
}
