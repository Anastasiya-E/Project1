using System;

namespace WebApplication1.Models
{
    public class LoginModel
    {
        // [Display(nameof="Login")]
        public string login { get; set; }
        //[Display(nameof = "Password")]
        public string password { get; set; }
        public bool? Success { get; set; }
    }
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
