namespace Project.Web.Common
{
    public class UserSession
    {
        public string uuid { get; set; }
        public string sid { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string RouteName { get; set; }
        public int? UserTypeId { get; set; }
        public string UserType { get; set; }
        public string aeskey { get; set; }
       
    }
}