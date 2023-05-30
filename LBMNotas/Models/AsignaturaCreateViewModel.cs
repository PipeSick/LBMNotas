using System.ComponentModel;

namespace LBMNotas.Models
{
    public class AsignaturaCreateViewModel
    {
        [DisplayName("Nombre de la Asignatura")]
        public string nombreasignatura { get; set; }
        public List<Unidades> Unidades { get; set; }
        public int CursoId { get; set; }
        public List<string> EtapasPredefinidas { get; set; }
        public int TotalPorcentaje { get; set; }

        public AsignaturaCreateViewModel()
        {
            EtapasPredefinidas = new List<string> { "Punto de partida y Punto de llegada", "Investigación", "Desarrollo del Pensamiento Complejo", "Relación", "Sustentación" };
        }

    }
}
