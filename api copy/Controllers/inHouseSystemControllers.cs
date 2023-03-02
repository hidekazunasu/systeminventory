using inHouseSysmte.Models;
using inHouseSysmte.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace inHouseSysmte.Controllers;

[ApiController]
[Route("[Controller]")]

public class inHouseSysmteController : ControllerBase
{
    private readonly inHouseSystemContext _context;

    public inHouseSysmteController(inHouseSystemContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("api/inHouseSystem")]

    public async Task<ActionResult<IEnumerable<inHouseSysmteList>>> Get()
    {
        var data = await _context.Sysmtes.ToListAsync();
        return data;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<inHouseSysmteList>> GetSystem(string id)
    {
        var system = await _context.Sysmtes.FindAsync(id);
        if (system == null)
        {
            return NotFound();
        }
        return system;

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutSystem(string id, inHouseSysmteList system)
    {
        if (id != system.Id)
        {
            return BadRequest();
        }
        _context.Entry(system).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (id != system.Id)
            {
                return BadRequest();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<inHouseSysmteList>> PostSystem(inHouseSysmteList system)
    {
        _context.Sysmtes.Add(system);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = system.Id }, system);
    }


}