using System.ComponentModel.DataAnnotations;

namespace LIBRARY_SYSTEM_PRACTICE.DTOs.AuthDTOs
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required, MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string PasswordHash { get; set; }
    }
}
