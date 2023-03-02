using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using systeminventory_sample.Models.DbFirst;

namespace inHouseSysmte.Controllers;

[ApiController]
[Route("[Controller]")]

public class ProcessController : ControllerBase
{
    private readonly inHouseDbContext _cotext;

    public ProcessController(inHouseDbContext context)
    {
        _cotext = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProcessControl>>> Get()
    {
        var data = await _cotext.ProcessControls.ToListAsync();
        return data;
    }
}


