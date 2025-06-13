namespace HouseBrokerMVP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginDto model)
    {
        var result = await authService.LoginUser(model);
        return Ok(result);

    }

    [Route("register-broker")]
    [HttpPost]
    public async Task<IActionResult> RegisterBroker(RegisterUserDto registerDto)
    {
        var user = await authService.RegisterBroker(registerDto);
        return Ok(user.UserName);
    }

    [Route("change-password")]
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto data)
    {
        await authService.ChangePassword(data);
        return Ok("Password has been changed successfully");

    }
    [Route("me")]
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetMyDetails()
    {
        var data = await authService.GetMyDetails();
        return Ok(data);
    }
}

