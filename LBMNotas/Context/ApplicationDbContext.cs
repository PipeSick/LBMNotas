using LBMNotas.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace LBMNotas.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          /*  base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AlumnoAsignatura>()
            .HasKey(aa => new { aa.AsignaturasId, aa.AlumnosRut });

            modelBuilder.Entity<AlumnoAsignatura>()
                .HasOne(aa => aa.Asignaturas)
                .WithMany(a => a.AlumnosAsignaturas)
                .HasForeignKey(aa => aa.AsignaturasId);

            modelBuilder.Entity<AlumnoAsignatura>()
                .HasOne(aa => aa.Alumnos)
                .WithMany(a => a.AlumnosAsignaturas)
                .HasForeignKey(aa => aa.AlumnosRut);*/

            modelBuilder.Entity<ProfesorAsignatura>()
                .HasKey(ap => new { ap.AsignaturasId, ap.ProfesoresId });

            modelBuilder.Entity<ProfesorAsignatura>()
                .HasOne(ap => ap.Asignaturas)
                .WithMany(a => a.ProfesorAsignaturas)
                .HasForeignKey(ap => ap.AsignaturasId);

            modelBuilder.Entity<ProfesorAsignatura>()
                .HasOne(ap => ap.Profesores)
                .WithMany(p => p.ProfesoresAsignaturas)
                .HasForeignKey(ap => ap.ProfesoresId);

            modelBuilder.Entity<EtapaUnidad>()
                    .HasKey(te => new { te.UnidadesId, te.EtapasId });

            modelBuilder.Entity<EtapaUnidad>()
                .HasOne(te => te.Unidades)
                .WithMany(t => t.EtapasUnidad)
                .HasForeignKey(te => te.UnidadesId);

            modelBuilder.Entity<EtapaUnidad>()
                .HasOne(te => te.Etapas)
                .WithMany(e => e.EtapasUnidad)
                .HasForeignKey(te => te.EtapasId);

            modelBuilder.Entity<Unidades>()
                .HasOne(u => u.notaFinalUnidad)
                .WithOne(nf => nf.unidades)
                .HasForeignKey<NotaFinalUnidad>(nf => nf.IDUnidad);

            modelBuilder.Entity<Unidades>()
                .HasOne(u => u.Asignaturas)
                .WithMany(a => a.Unidades)
                .HasForeignKey(u => u.AsignaturasID);
            modelBuilder.Entity<CursoAsignatura>()
                 .HasKey(ca => new { ca.CursosId, ca.AsignaturasId });

            modelBuilder.Entity<CursoAsignatura>()
                .HasOne(ca => ca.Cursos)
                .WithMany(c => c.CursoAsignaturas)
                .HasForeignKey(ca => ca.CursosId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CursoAsignatura>()
                .HasOne(ca => ca.Asignaturas)
                .WithMany(a => a.CursoAsignaturas)
                .HasForeignKey(ca => ca.AsignaturasId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Alumnos>()
                .HasOne(a => a.Cursos)
                .WithMany(c => c.Alumnos)
                .HasForeignKey(a => a.CursosId);

        }
        public DbSet<Profesores> Profesores { get; set; }
        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Asignaturas> Asignaturas { get; set; }
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Unidades> Unidades { get; set; }
        public DbSet<NotaFinalUnidad> NotaFinalUnidad { get; set; }
        public DbSet<Etapas> Etapas { get; set; }
        public DbSet<EtapaUnidad> EtapaUnidad { get; set; }
        public DbSet<ProfesorAsignatura> ProfesorAsignatura { get; set; }
        public DbSet<CursoAsignatura> CursoAsignaturas { get; set; }

    }
}
