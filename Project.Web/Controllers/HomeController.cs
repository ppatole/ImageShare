using BAL;
using Project.Entity;

using Project.Web.App_Start;
using Project.Web.Common;
using Project.Web.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility.Helper;
using System.Security.Cryptography;
using System.IO;
using System.Text;


namespace Project.Web.Controllers
{
    public class HomeController : Controller
    {
        SessionHelper session = new SessionHelper();


        public static string Encrypt(String input)
        {
            using (AesManaged aes = new AesManaged())
            {

                // 5470303844313567
                //string keystring = "Tp08D15g";

                // Key has to be 16 bytes and empty bytes should be 0
                byte[] key = new byte[16];
                byte[] hex = Encoding.UTF8.GetBytes("Tp08D15g");
                Array.Copy(hex, key, hex.Length);

                // iv size should match key. So it is 16 bytes too
                var iv = new byte[] { 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30 };

                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.BlockSize = 128;
                aes.KeySize = 128;

                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);

                using (MemoryStream inputStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(inputStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cryptoStream))
                        {
                            writer.Write(input);
                        }

                        return Convert.ToBase64String(inputStream.ToArray());
                    }
                }
            }
        }

        
        [HttpGet]
        [AllowAnonymous]
        public string EncryptFilter(String filter) {

            String EcnBase64 = Encrypt(filter);
            // ******* The filter cannot have inverted commas outside
            // INCORRECT - '{"filter.accession_number.equals":"1963943"} '
            // CORRECT -    {"filter.accession_number.equals":"1963943"}
            String uncodeUrl = System.Net.WebUtility.UrlEncode(EcnBase64);
            //return "Hello";
            return uncodeUrl;

        }

        [Authorize]
        [SessionExpire]
        public ActionResult Index()
        {
            //List<TextValue> list = new List<TextValue>();
            //List<StudyViewModel> studies = new List<StudyViewModel>();
            //StudyModel model = new StudyModel();
            if (session.UserSession == null)
            //{
                Url.Action("LogOut", "Account");
            //}
           // else {

                //String url = "https://access.dicomgrid.com/";
                //RestSharp.RestClient clientnew = new RestSharp.RestClient { BaseUrl = url };
                //var request = new RestRequest("api/v3/study/list", Method.POST) { RequestFormat = DataFormat.Json };
                //request.AddParameter("sid", session.UserSession.sid);
                ////request.AddParameter("uuid", session.UserSession.uuid);
                //var response = clientnew.Execute<List<StudyViewModel>>(request);
                //var content = response.Content;
                //studies = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<StudyViewModel>>(content);
                //model.studies = studies;
            //}

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public string encryptAccessionn(string filter)
        {
            
            string encstring = EncryptionDecryption.Encrypt(filter,"0123456abcdf");
            return encstring;
        }

        [AllowAnonymous]
        public ActionResult UserSetting()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult AdminSetting() {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Location()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Group()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult UploadStudy()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult OrgSetting()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult NewUser()
        {
            return View();
        }
        //Fetch UserRoleList
   

      



        //My Update End*****************

    }
}