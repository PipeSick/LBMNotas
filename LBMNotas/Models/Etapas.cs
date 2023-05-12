namespace LBMNotas.Models
{
    public class Etapas
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Porcentaje { get; set; }
        public float Nota { get; set; }

        public List<EtapaUnidad>? EtapasUnidad { get; set; }
    }
}
