using System.Net;
using inHouseSysmte.Models;
using inHouseSysmte.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace inHouseSysmte.Controllers;

[ApiController]
[Route("[Controller]")]

public class ProcessController : ControllerBase
{
    private readonly inHouseSystemContext _cotext;

    public ProcessController(inHouseSystemContext context)
    {
        _cotext = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProcessControls>>> Get()
    {
        var data = await _cotext.ProcessControls.ToListAsync();
        return data;
    }
}


