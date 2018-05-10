using System.ComponentModel.DataAnnotations;

namespace My_blog.ViewModels.Account
{
    public class LoginViewModel
    {
        
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
