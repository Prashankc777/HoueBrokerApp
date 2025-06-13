using System.ComponentModel.DataAnnotations;

namespace HouseBrokerMVP.Business.DTO
{
    public class PropertyTypeListDto : PropertyTypeUpdateDto
    {

    }
    public class PropertyTypeInsertDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
    public class PropertyTypeUpdateDto : PropertyTypeInsertDto
    {
        public int Id { get; set; }
    }
    public class PropertyTypeDeleteDto
    {
        public int Id { get; set; }
    }
}
