using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BAL
{
    public class Constants
    {
        private static string connString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        private static string _token = "YG-DBMS";
        private static string _passPhrase = "WEL2015";
        private static string _LOGINURL = "http://vp.nimarforesters.org/";
        public static string PassPhrase
        {
            get { return _passPhrase; }
            set { _passPhrase = value; }
        }
        public static string ConnectionString
        {
            get { return connString; }
        }
        public static string TOKEN
        {
            get { return _token; }
        }
        public static string LOGINURL {

            get { return _LOGINURL; }
        }

    }
}
