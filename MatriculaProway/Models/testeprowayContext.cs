using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MatriculaProway.Models
{
    public partial class testeprowayContext : DbContext
    {
        public testeprowayContext()
        {
        }

        public testeprowayContext(DbContextOptions<testeprowayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Lanchonete> Lanchonetes { get; set; }
        public virtual DbSet<Matricula> Matriculas { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=testeproway;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.ToTable("Aluno");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sobrenome)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lanchonete>(entity =>
            {
                entity.ToTable("Lanchonete");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.ToTable("Matricula");

                entity.Property(e => e.Turno1Lanchonete).HasColumnName("Turno1_Lanchonete");

                entity.Property(e => e.Turno2Lanchonete).HasColumnName("Turno2_Lanchonete");

                entity.HasOne(d => d.Aluno)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.AlunoId)
                    .HasConstraintName("fk_aluno");

                entity.HasOne(d => d.Etapa1Navigation)
                    .WithMany(p => p.MatriculaEtapa1Navigations)
                    .HasForeignKey(d => d.Etapa1)
                    .HasConstraintName("fk_sala_etapa");

                entity.HasOne(d => d.Etapa2Navigation)
                    .WithMany(p => p.MatriculaEtapa2Navigations)
                    .HasForeignKey(d => d.Etapa2)
                    .HasConstraintName("FK__Matricula__Etapa__52593CB8");

                entity.HasOne(d => d.Turno1LanchoneteNavigation)
                    .WithMany(p => p.MatriculaTurno1LanchoneteNavigations)
                    .HasForeignKey(d => d.Turno1Lanchonete)
                    .HasConstraintName("fk_lanchonete_turno");

                entity.HasOne(d => d.Turno2LanchoneteNavigation)
                    .WithMany(p => p.MatriculaTurno2LanchoneteNavigations)
                    .HasForeignKey(d => d.Turno2Lanchonete)
                    .HasConstraintName("FK__Matricula__Turno__5441852A");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.ToTable("Sala");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
