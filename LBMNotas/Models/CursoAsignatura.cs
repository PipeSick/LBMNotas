using System.Security.Cryptography.Xml;

namespace LBMNotas.Models
{
    public class CursoAsignatura
    {
        public int CursosId { get; set; }
        public Cursos Cursos { get; set; }
        public int AsignaturasId { get; set; }
        public Asignaturas Asignaturas { get; set; }
    }
}
