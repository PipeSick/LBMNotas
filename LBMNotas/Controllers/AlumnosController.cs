
using LBMNotas.Context;
using LBMNotas.Models;
using Microsoft.AspNetCore.Mvc;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Authorization;
using LBMNotas.Servicios;

namespace LBMNotas.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IConverter _converter;

        public AlumnosController(ApplicationDbContext context, IConverter converter)
        {
            this.context = context;
            _converter = converter;
        }
        [Authorize(Roles = Constantes.RolAdmin)]
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


            return View(modelo);
        }
        public IActionResult MostrarPDFenPagina(int IdAlumno)
        {


            string pagina_actual = HttpContext.Request.Path;
            string url_pagina = HttpContext.Request.GetEncodedUrl();
            url_pagina = url_pagina.Replace(pagina_actual, "");
            url_pagina = $"{url_pagina}/Alumnos/AlumnoResumenView/{IdAlumno}";


            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings(){
                        Page = url_pagina
                    }
                }

            };

            var archivoPDF = _converter.Convert(pdf);


            return File(archivoPDF, "application/pdf");
        }

        public IActionResult DescargarPDF(int IdAlumno)
        {
            string pagina_actual = HttpContext.Request.Path;
            string url_pagina = HttpContext.Request.GetEncodedUrl();
            url_pagina = url_pagina.Replace(pagina_actual, "");
            url_pagina = $"{url_pagina}/Alumnos/AlumnoResumenView";


            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings(){
                        Page = url_pagina
                    }
                }

            };

            var archivoPDF = _converter.Convert(pdf);
            string nombrePDF = "reporte_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            return File(archivoPDF, "application/pdf", nombrePDF);
        }


    }
}
