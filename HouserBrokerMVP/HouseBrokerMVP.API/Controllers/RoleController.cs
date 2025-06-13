namespace HouseBrokerMVP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class RoleController(IRoleService roleService) : ControllerBase
{
    [HttpGet, Route("")]
    public async Task<IActionResult> GetRoles()
    {
        try
        {
            var data = await roleService.GetRoleList();
            return Ok(data);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
