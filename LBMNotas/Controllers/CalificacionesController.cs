using LBMNotas.Context;
using LBMNotas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Util;

namespace LBMNotas.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly ApplicationDbContext context;

        public CalificacionesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(int alumnoId, int etapaId, float nota)
        {
            try
            {
                // Buscar el registro de calificación existente o crear uno nuevo
                var calificacion = context.calificacionAlumnos.FirstOrDefault(c => c.AlumnoId == alumnoId && c.EtapaId == etapaId);
                if (calificacion == null)
                {
                    calificacion = new CalificacionAlumno
                    {
                        AlumnoId = alumnoId,
                        EtapaId = etapaId,
                        Nota = nota
                        
                    };
                    context.calificacionAlumnos.Add(calificacion);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    // Actualizar la nota
                    calificacion.Nota = nota;

                    context.SaveChanges();
                    return Ok();
                }                
            }
            catch (Exception ex)
            {
                // Manejar el error de alguna manera apropiada
                string errorMessage = ex.InnerException?.Message ?? ex.Message;
                return BadRequest(errorMessage);
            }
        }

        [HttpPost]
        public IActionResult GuardarPromedio(int unidadId, List<AlumnosPromedioUnidad> alumnos)
        {
            try
            {
                foreach (var alumno in alumnos)
                {
                    var verificarpromedio = context.NotaFinalUnidad.FirstOrDefault(nf => nf.UnidadId == unidadId && nf.AlumnoId == alumno.AlumnoId);
                    if (verificarpromedio == null)
                    {
                        var nuevopromedio = new NotaFinalUnidad
                        {
                            AlumnoId = alumno.AlumnoId,
                            UnidadId = unidadId,
                            NotaFinal = alumno.Promedio
                        };
                        context.NotaFinalUnidad.Add(nuevopromedio);

                    }
                    else
                    {
                        // Se actualiza el promedio
                        verificarpromedio.NotaFinal = alumno.Promedio;
                        context.NotaFinalUnidad.Update(verificarpromedio);
                    }
                    context.SaveChanges();
                }


                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Manejar la excepción y proporcionar una respuesta adecuada
                return StatusCode(500, "Ocurrió un error al guardar los promedios. Detalles: " + ex.Message);
            }
        }

    }

}

