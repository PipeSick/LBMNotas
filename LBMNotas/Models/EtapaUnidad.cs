namespace LBMNotas.Models
{
    public class EtapaUnidad
    {
        public int Id { get; set; }
        public int EtapasId { get; set; }
        public int UnidadesId { get; set; }
        public Etapas Etapas { get; set; }
        public Unidades Unidades { get; set; } 

    }
}
