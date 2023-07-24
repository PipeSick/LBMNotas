namespace LBMNotas.Models
{
    public class AgregarUnidadViewModel
    {
        public Unidades Unidades { get; set; }
        public List<Etapas> Etapas { get; set; }
        public List<string> EtapasPredefinidas { get; set; }
        public int IdAsignatura { get; set; }
        public AgregarUnidadViewModel()
        {
            EtapasPredefinidas = new List<string> { "Punto de partida y Punto de llegada", "Investigación", "Desarrollo del Pensamiento Complejo", "Relación", "Sustentación", "Otro" };
        }
    }
}
