using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL
{
    public partial class NCastilloAlfaSolucionesContext : DbContext
    {
        public NCastilloAlfaSolucionesContext()
        {
        }

        public NCastilloAlfaSolucionesContext(DbContextOptions<NCastilloAlfaSolucionesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; } = null!;
        public virtual DbSet<BecaCultural> BecaCulturals { get; set; } = null!;
        public virtual DbSet<BecaDeportiva> BecaDeportivas { get; set; } = null!;
        public virtual DbSet<BecaEducativa> BecaEducativas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-15TRT047; Database= NCastilloAlfaSoluciones; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.IdAlumno)
                    .HasName("PK__Alumno__460B4740C20AA749");

                entity.ToTable("Alumno");

                entity.Property(e => e.Genero)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBecaCulturalNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdBecaCultural)
                    .HasConstraintName("FK__Alumno__IdBecaCu__164452B1");

                entity.HasOne(d => d.IdBecaDeportivaNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdBecaDeportiva)
                    .HasConstraintName("FK__Alumno__IdBecaDe__173876EA");

                entity.HasOne(d => d.IdBecaEducativaNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdBecaEducativa)
                    .HasConstraintName("FK__Alumno__IdBecaEd__182C9B23");
            });

            modelBuilder.Entity<BecaCultural>(entity =>
            {
                entity.HasKey(e => e.IdBecaCultural)
                    .HasName("PK__BecaCult__96FA0DEC9D20D680");

                entity.ToTable("BecaCultural");

                entity.Property(e => e.NombreCultural)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BecaDeportiva>(entity =>
            {
                entity.HasKey(e => e.IdBecaDeportiva)
                    .HasName("PK__BecaDepo__5744ACCF37D4704A");

                entity.ToTable("BecaDeportiva");

                entity.Property(e => e.NombreDeportiva)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BecaEducativa>(entity =>
            {
                entity.HasKey(e => e.IdBecaEducativa)
                    .HasName("PK__BecaEduc__8C71BEBB38D7F69B");

                entity.ToTable("BecaEducativa");

                entity.Property(e => e.NombreEducativa)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
