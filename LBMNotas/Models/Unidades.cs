namespace LBMNotas.Models
{
    public class Unidades
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Etapas> Etapas { get; set; }
        public int AsignaturasID { get; set; }

        public Asignaturas Asignaturas { get; set; }
        public NotaFinalUnidad notaFinalUnidad { get; set; }

    }
}
