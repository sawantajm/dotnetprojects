using System.ComponentModel.DataAnnotations;


namespace Microservices.AuthApi.Models.DTO
{
    public class ResetPasswordDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string OldPassword {  get; set; }
        [Required]
        public string NewPassword { get; set; } = string.Empty;
    }
}
