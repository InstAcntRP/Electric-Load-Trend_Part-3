using System;
using System.Collections.Generic;
using ElectricLoadTrend.Model;
using Microsoft.EntityFrameworkCore;

namespace ElectricLoadTrend.Data;

public partial class GenerationDataContext : DbContext
{
    public GenerationDataContext()
    {
    }

    public GenerationDataContext(DbContextOptions<GenerationDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GenerationData> GenerationData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PR\\SQLEXPRESS;Database=Staging;Trusted_Connection=True;Encrypt=No");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GenerationData>(entity =>
        {
            entity.HasKey(e => e.DataId);

            entity.Property(e => e.Dt)
                .HasColumnType("datetime")
                .HasColumnName("DT");
            entity.Property(e => e.GeneratedMw).HasColumnName("GeneratedMW");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
