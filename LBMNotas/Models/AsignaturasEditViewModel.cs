using Microsoft.AspNetCore.Identity;

namespace LBMNotas.Models
{
    public class AsignaturasEditViewModel
    {
        public List<Etapas> Etapas { get; set; }
        public List<string> EtapasPredefinidas { get; set; }
        public List<Unidades> Unidades { get; set; }
        public Asignaturas Asignaturas { get; set; }
        public Unidades Unidad { get; set; }
        public List<IdentityUser> ListaProfes { get; set; }
        public AsignaturasEditViewModel()
        {
            EtapasPredefinidas = new List<string> { "Punto de partida y Punto de llegada", "Investigación", "Desarrollo del Pensamiento Complejo", "Relación", "Sustentación","Otro" };
        }
    }
}
