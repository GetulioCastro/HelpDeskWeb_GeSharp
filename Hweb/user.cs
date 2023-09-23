using System.ComponentModel.DataAnnotations;

namespace Hweb
{
    public class Login_Credentials
    {
        [Key]
        public string username { get; set; }
        public string user_password { get; set; }
        public string user_role { get; set; }
    }
}
