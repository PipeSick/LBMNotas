using Microsoft.AspNetCore.Identity;
namespace LBMNotas.Models 

{
    public class ProfesorAsignatura
    {
        public int Id { get; set; }

        public int AsignaturasId { get; set; }
        public Asignaturas Asignaturas { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

    }
}
