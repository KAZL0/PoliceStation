using System.ComponentModel.DataAnnotations;

namespace PoliceStation.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username or Email")]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
