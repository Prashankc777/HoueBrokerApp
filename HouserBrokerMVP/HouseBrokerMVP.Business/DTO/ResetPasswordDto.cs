using System.ComponentModel.DataAnnotations;

namespace HouseBrokerMVP.Business.DTO
{
    public class ChangePasswordDto
    {
        [Required]
        public string OldPassword { get; set; } = null!;
        [Required]
        public string NewPassword { get; set; } = null!;
    }
}
