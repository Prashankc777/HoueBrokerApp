using System.ComponentModel.DataAnnotations;

namespace HouseBrokerMVP.Business.DTO
{
    public class LoginDto
    {
        [Required]
        public string EmailAddress { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
