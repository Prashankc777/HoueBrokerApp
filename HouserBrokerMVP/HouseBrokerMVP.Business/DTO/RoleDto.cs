using System.ComponentModel.DataAnnotations;

namespace HouseBrokerMVP.Business.DTO
{
    public class RoleAddDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
    public class RoleListDto : RoleAddDto
    {
    }
}
