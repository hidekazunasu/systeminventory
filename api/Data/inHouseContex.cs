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

    public virtual DbSet<inHouseSysmteList>? Sysmtes { get; set; }
    public virtual DbSet<ProcessControls>? ProcessControls { get; set; }

    public virtual DbSet<SystemCategories>? SystemCategorie { get; set; }

}