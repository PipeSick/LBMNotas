using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LBMNotas.Models
{
    public class Profesores
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public List<ProfesorAsignatura> ProfesoresAsignaturas { get; set; }
    }
}
