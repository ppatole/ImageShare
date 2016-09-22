using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.Globalization;

namespace Utility.Helper
{
    /// <summary>
    /// Helper methods
    /// </summary>
    public static class Helper
    {
        public static int ConvertToInt(string value)
        {
            int returnValue = 0;
            int.TryParse(value, out returnValue);
            return returnValue;
        }

        public static int? ConvertToIntNullable(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            int returnValue = 0;
            int.TryParse(value, out returnValue);
            return returnValue;
        }

        public static decimal ConvertToDecimal(string value)
        {
            decimal returnValue = 0;
            decimal.TryParse(value, out returnValue);
            return returnValue;
        }

        public static decimal? ConvertToDecimalNullable(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            decimal returnValue = 0;
            decimal.TryParse(value, out returnValue);
            return returnValue;
        }

        public static bool ConvertToBool(string value)
        {
            bool returnValue = false;
            bool.TryParse(value, out returnValue);
            return returnValue;
        }

        public static bool? ConvertToBoolNullable(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            bool returnValue = false;
            bool.TryParse(value, out returnValue);
            return returnValue;
        }

        public static string FullyQualifiedApplicationPath(HttpRequestBase httpRequestBase)
        {
            string appPath = string.Empty;

            if (httpRequestBase != null)
            {
                //Formatting the fully qualified website url/name
                appPath = string.Format("{0}://{1}{2}{3}",
                            httpRequestBase.Url.Scheme,
                            httpRequestBase.Url.Host,
                            httpRequestBase.Url.Port == 80 ? string.Empty : ":" + httpRequestBase.Url.Port,
                            httpRequestBase.ApplicationPath);
            }

            if (!appPath.EndsWith("/"))
            {
                appPath += "/";
            }

            return appPath;
        }

        /// <summary>
        /// Generate Random Password
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomPassword()
        {
            try
            {
                char[] chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                string pwd = string.Empty;
                Random random = new Random();
                for (int i = 0; i < 6; i++)
                {
                    int x = random.Next(1, chars.Length);
                    //Don't Allow Repetation of Characters
                    if (!pwd.Contains(chars.GetValue(x).ToString()))
                        pwd += chars.GetValue(x);
                    else
                        i--;
                }
                return pwd;
            }
            catch (Exception ex)
            {
                return "mYE54n";
            }
        }

        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="emailid"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Boolean SendEmail(string emailid, string subject, string message)
        {
            try
            {

                var fromAddress = new MailAddress(AppConfigValue.SMTP_User.ToString(), "YG - DBMS");
                var toAddress = new MailAddress(emailid, "");
                string fromPassword = AppConfigValue.SMTP_Password.ToString();
                var smtp = new SmtpClient
                {
                    Host = AppConfigValue.SMTP_Server.ToString(),
                    Port = Convert.ToInt32(AppConfigValue.SMTP_Port.ToString()),
                    EnableSsl = AppConfigValue.SMTP_SSL,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                MailMessage msg = new System.Net.Mail.MailMessage(AppConfigValue.SMTP_User.ToString(), emailid, subject, message);
                msg.IsBodyHtml = true;
                smtp.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DateTime ConvertToDate(string value, string format)
        {
            DateTime returnValue = new DateTime();
            //DateTime.TryParse(value, out returnValue);
            returnValue = DateTime.ParseExact(value, format, CultureInfo.InvariantCulture);
            return returnValue;
        }

        public static DateTime? ConvertToDateNullable(string value, string format)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            DateTime returnValue = new DateTime();
            returnValue = DateTime.ParseExact(value, format, CultureInfo.InvariantCulture);
            return returnValue;
        }

        public static int GetYearsFromDates(DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) +
                (((end.Month > start.Month) ||
                ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
        }
        //My Update Start*****************
        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        //My Update End*****************

        public static string ConvertBoolToString(bool value)
        {
            if (value)
                return "YES";
            else
                return "NO";
        }
    }
}
