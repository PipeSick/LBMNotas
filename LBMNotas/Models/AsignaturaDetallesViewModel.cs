﻿namespace LBMNotas.Models
{
    public class AsignaturaDetallesViewModel
    {
        public List<Etapas> Etapas { get; set; }
        public List<Unidades> Unidades { get; set; }
        public List<Alumnos> Alumnos { get; set; }
        public Asignaturas Asignaturas { get; set; }
        public Unidades Unidad { get; set; }
        public int IdCurso { get; set; }
    }
}
