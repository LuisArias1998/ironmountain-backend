using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ironmountain_backend.Models;

public partial class IronmountainContext : DbContext
{
    public IronmountainContext()
    {
    }

    public IronmountainContext(DbContextOptions<IronmountainContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Registro> Registros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Registro>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("curp");
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsFixedLength()
                .HasColumnName("direccion");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("date")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
