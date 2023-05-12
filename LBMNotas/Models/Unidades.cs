namespace LBMNotas.Models
{
    public class Unidades
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public int AsignaturasID { get; set; }
        public List<EtapaUnidad> EtapasUnidad { get; set; }
        public Asignaturas Asignaturas { get; set; }
        public NotaFinalUnidad notaFinalUnidad { get; set; }

    }
}
