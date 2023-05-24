using System.ComponentModel;

namespace LBMNotas.Models
{
    public class AsignaturaCreateViewModel
    {
        [DisplayName("Nombre de la Asignatura")]
        public string nombreasignatura { get; set; }
        public List<Unidades> Unidades { get; set; }
        public int CursoId { get; set; }
    }
}
