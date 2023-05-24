using System.ComponentModel.DataAnnotations;

namespace LBMNotas.Models
{
    public class Alumnos
    {
        [Key]
        public int Id { get; set; }
        public int NumeroLista { get; set; }
        public string Rut { get; set; }
        [Required]
        public string NombreCompleto { get; set; }


        public List<AlumnoCurso> alumnoCursos { get; set; }

    }
}
