using System.ComponentModel.DataAnnotations;

namespace PropertyRenting.Web.Models.Account
{
    public class ForgotPasswordModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
