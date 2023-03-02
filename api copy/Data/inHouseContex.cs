using Microsoft.EntityFrameworkCore;
using inHouseSysmte.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace inHouseSysmte.Data;

public class inHouseSystemContext : DbContext
{
    public inHouseSystemContext()
    {
    }

    public inHouseSystemContext(DbContextOptions<inHouseSystemContext> options) : base(options) { }

    public DbSet<inHouseSysmteList>? Sysmtes { get; set; }
    public DbSet<ProcessControls>? ProcessControls { get; set; }

    public DbSet<SystemCategories>? SystemCategorie { get; set; }

}