
using LBMNotas.Context;
using LBMNotas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Authorization;
using LBMNotas.Servicios;
using Rotativa.AspNetCore;

namespace LBMNotas.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly ApplicationDbContext context;

        public AlumnosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult AlumnoResumenView(int IdAlumno)
        {
            var modelo = new AlumnoResumenViewModel();
            modelo.Unidades = new List<Unidades>();
            modelo.Etapas = new List<Etapas>();
            var datosalumno = context.Alumnos.Where(aa => aa.Id == IdAlumno).FirstOrDefault();
            modelo.Alumnos = datosalumno;
            var todasnotas = context.calificacionAlumnos.Where(al => al.AlumnoId == IdAlumno).ToList();
            var cursoalumno = context.alumnoCursos.Where(a => a.AlumnosId == IdAlumno).FirstOrDefault();
            var detallescurso = context.Cursos.Where(c => c.Id == cursoalumno.CursosId).FirstOrDefault();
            modelo.Cursos = detallescurso;
            modelo.calificacionAlumnos = todasnotas;
            var asignaturascurso = context.Asignaturas.Where(s => s.CursosId == cursoalumno.CursosId).ToList();
            modelo.Asignaturas = asignaturascurso;
            foreach (var asignaturas in asignaturascurso)
            {
                var listaunidades = context.Unidades.Where(u => u.AsignaturasID == asignaturas.Id).ToList();
                modelo.Unidades.AddRange(listaunidades);
            }

            foreach (var unidades in modelo.Unidades)
            {
                var listaetapas = context.Etapas.Where(e => e.UnidadesId == unidades.Id).ToList();
                modelo.Etapas.AddRange(listaetapas);
            }

            var notasfinalesalumno = context.NotaFinalUnidad.Where(n => n.AlumnoId == IdAlumno).ToList();

            modelo.NotaFinalUnidad = notasfinalesalumno;


            return new ViewAsPdf("AlumnoResumenView", modelo)
                {

                FileName= $"ResumenAlumno.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A4

            };
        }

    }
}
