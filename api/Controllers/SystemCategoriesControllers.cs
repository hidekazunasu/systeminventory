using systeminventory_sample.Models.DbFirst;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace inHouseSysmte.Controllers;

[ApiController]
[Route("[Controller]")]

public class SystemCategoriesController : ControllerBase
{
    private readonly inHouseDbContext _cotext;

    public SystemCategoriesController(inHouseDbContext context)
    {
        _cotext = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SystemCategory>>> Get()
    {
        var data = await _cotext.SystemCategories.ToListAsync();
        return data;
    }
}


