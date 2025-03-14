using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProgettoPoliziaMunicipale.Models;

namespace ProgettoPoliziaMunicipale.Data;

public partial class PoliziaMunicipaleDbContext : DbContext
{
    public PoliziaMunicipaleDbContext()
    {
    }

    public PoliziaMunicipaleDbContext(DbContextOptions<PoliziaMunicipaleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anagrafica> Anagraficas { get; set; }

    public virtual DbSet<TipoViolazione> TipoViolaziones { get; set; }

    public virtual DbSet<Verbale> Verbales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-4VUL8MIO\\SQLEXPRESS;Database=ProgettoSettimale3BackEnd;User Id=sa;Password=sa;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anagrafica>(entity =>
        {
            entity.HasKey(e => e.IdAnagrafica).HasName("PK__Anagrafi__11B12B19B1B5F4CD");
        });

        modelBuilder.Entity<TipoViolazione>(entity =>
        {
            entity.HasKey(e => e.IdViolazione).HasName("PK__Tipo_Vio__30BEFB3B5FD052D2");
        });

        modelBuilder.Entity<Verbale>(entity =>
        {
            entity.HasKey(e => e.IdVerbale).HasName("PK__Verbale__471AC560E5FC83AA");

            entity.HasOne(d => d.IdAnagraficaNavigation).WithMany(p => p.Verbales)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Verbale_Anagrafica");

            entity.HasMany(d => d.IdViolaziones).WithMany(p => p.IdVerbales)
                .UsingEntity<Dictionary<string, object>>(
                    "VerbaleViolazione",
                    r => r.HasOne<TipoViolazione>().WithMany()
                        .HasForeignKey("IdViolazione")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_VerbaleViolazione_Violazione"),
                    l => l.HasOne<Verbale>().WithMany()
                        .HasForeignKey("IdVerbale")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_VerbaleViolazione_Verbale"),
                    j =>
                    {
                        j.HasKey("IdVerbale", "IdViolazione").HasName("PR_Verbale_Violazione");
                        j.ToTable("Verbale_Violazione");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
