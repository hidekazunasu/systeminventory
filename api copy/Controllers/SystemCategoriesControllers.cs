using System.Net;
using inHouseSysmte.Models;
using inHouseSysmte.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace inHouseSysmte.Controllers;

[ApiController]
[Route("[Controller]")]

public class SystemCategoriesController : ControllerBase
{
    private readonly inHouseSystemContext _cotext;

    public SystemCategoriesController(inHouseSystemContext context)
    {
        _cotext = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SystemCategories>>> Get()
    {
        var data = await _cotext.SystemCategorie.ToListAsync();
        return data;
    }
}


