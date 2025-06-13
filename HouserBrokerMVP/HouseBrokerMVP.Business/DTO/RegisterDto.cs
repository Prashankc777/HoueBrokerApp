namespace HouseBrokerMVP.Business.DTO
{
    public class RegisterAdminDto
    {
        public string EmailAddress { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public string? PhoneNumber { get; set; }
    }
    public class RegisterUserDto : RegisterAdminDto
    {
        public new string PhoneNumber { get; set; } = null!;
    }
}
