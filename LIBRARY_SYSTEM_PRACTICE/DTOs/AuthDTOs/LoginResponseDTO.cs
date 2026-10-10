namespace LIBRARY_SYSTEM_PRACTICE.DTOs.AuthDTOs
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
