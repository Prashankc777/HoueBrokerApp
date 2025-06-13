namespace HouseBrokerMVP.API.Controllers;

[Route("api/property")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class PropertyController(IPropertyService propertyService, IReadFilePathProviderService fileService)
    : ControllerBase
{
    [HttpGet, Route("search")]
    [AllowAnonymous]
    public async Task<IActionResult> SearchProperty(string? location, decimal? minPrice, decimal? maxPrice, int? propertyType)
    {

        var data = (await propertyService.SearchProperty(location, minPrice, maxPrice, propertyType)).ToList();
        data.ForEach(x =>
        {
            x.Images = x.Images.Select(y => fileService.GetPropertyImageFilePath() + "/" + y).ToList();
        });
        return Ok(data);
    }

    [HttpGet, Route("")]
    public async Task<IActionResult> GetList()
    {
        var data = (await propertyService.GetList()).ToList();
        data.ForEach(x =>
        {
            x.Images = x.Images.Select(y => fileService.GetPropertyImageFilePath() + "/" + y).ToList();
        });
        return Ok(data);
    }

    [HttpGet, Route("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await propertyService.GetById(id);
        return Ok(data);
    }

    [HttpPost, Route("")]
    [Authorize(Roles = "Broker")]
    public async Task<IActionResult> AddPropertyType([FromForm] PropertyInsertDto formData)
    {
        var response = await propertyService.Create(formData);
        return Ok(response);

    }

    [HttpPut, Route("{id}")]
    [Consumes("multipart/form-data")]
    [Authorize(Roles = "Broker")]
    public async Task<IActionResult> UpdatePropType(int id, [FromForm] PropertyUpdateDto formData)
    {
        formData.Id = id;
        var response = await propertyService.Update(formData);
        return Ok(response);

    }
    [HttpDelete, Route("{id}")]
    [Authorize(Roles = "Broker")]
    public async Task<IActionResult> DeletePropType(int id)
    {
        await propertyService.Delete(id);
        return Ok("Property Type has been deleted");
    }
}

