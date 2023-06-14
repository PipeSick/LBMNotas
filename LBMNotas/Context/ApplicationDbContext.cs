using LBMNotas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace LBMNotas.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

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








            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(l => new { l.LoginProvider, l.ProviderKey });

            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.RoleId });
            });


        }
        public DbSet<Profesores> Profesores { get; set; }
        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Asignaturas> Asignaturas { get; set; }
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Unidades> Unidades { get; set; }
        public DbSet<NotaFinalUnidad> NotaFinalUnidad { get; set; }
        public DbSet<Etapas> Etapas { get; set; }
        public DbSet<ProfesorAsignatura> ProfesorAsignatura { get; set; }
        public DbSet<AlumnoCurso> alumnoCursos { get; set; }
        public DbSet<CalificacionAlumno> calificacionAlumnos { get; set; }

    }
}
