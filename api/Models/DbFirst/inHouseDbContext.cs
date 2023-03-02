using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace systeminventory_sample.Models.DbFirst;

public partial class inHouseDbContext : DbContext
{
    public inHouseDbContext()
    {
    }

    public inHouseDbContext(DbContextOptions<inHouseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProcessControl> ProcessControls { get; set; }

    public virtual DbSet<inHouseSystem> Systems { get; set; }

    public virtual DbSet<SystemCategory> SystemCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=inhouse");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProcessControl>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ProcessControl");
        });

        modelBuilder.Entity<inHouseSystem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("system");

            entity.Property(e => e.ProcessControl).HasColumnType("INT");
        });

        modelBuilder.Entity<SystemCategory>(entity =>
        {
            entity.HasNoKey();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
