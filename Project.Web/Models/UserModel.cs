
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Web.Models
{
    public class UserModel
    {
        public int User_ID { get; set; }
        public string User_Name { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
        public int CreatedBy_User { get; set; }
        public int UpdatedBy_User { get; set; }
        public string Status { get; set; }
        public int errorCode { get; set; }
        public string errorMessage { get; set; }
        public string Action { get; set; }
     
    }
}