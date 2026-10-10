using System.ComponentModel.DataAnnotations;

namespace LIBRARY_SYSTEM_PRACTICE.DTOs.AuthDTOs
{
    public class RegisterDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required, MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
    }
}
