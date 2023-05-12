namespace LBMNotas.Models
{
    public class NotaFinalUnidad
    {
        public int Id { get; set; }
        public int IDUnidad { get; set; }
        public float NotaFinal { get; set; }
        public Unidades unidades { get; set; }
    }
}
