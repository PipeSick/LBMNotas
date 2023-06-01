using Azure;
using LBMNotas.Context;
using LBMNotas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;

namespace LBMNotas.Controllers
{
    public class AsignaturasController : Controller
    {
        private readonly ApplicationDbContext context;
        public AsignaturasController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public IActionResult AsignaturasIndex(int IdAsignatura, int IdCurso, int IdUnidad)
        {

            var modelo = new AsignaturaDetallesViewModel();

            var ListaAlumnos = context.Alumnos
        .Where(a => a.alumnoCursos.Any(ac => ac.CursosId == IdCurso))
        .ToList();

            var AsignaturaDatos = context.Asignaturas.Where(a => a.Id == IdAsignatura).FirstOrDefault();
            var ListaUnidades = context.Unidades.Where(u => u.AsignaturasID == IdAsignatura).ToList();
            var ListaCompletaEtapas = new List<Etapas>();
            if (ListaUnidades is null)
            {
                return NotFound();
            }

            foreach (var unidad in ListaUnidades)
            {
                var ListaEtapasUnidad = context.Etapas.Where(e => e.UnidadesId == unidad.Id).ToList();
                ListaCompletaEtapas.AddRange(ListaEtapasUnidad);
            }
            if (AsignaturaDatos == null) 
            {
                return NotFound();
            }

            modelo.IdCurso = IdCurso;
            modelo.Alumnos = ListaAlumnos;
            modelo.Asignaturas = AsignaturaDatos;
            modelo.Unidades = ListaUnidades;
            modelo.Etapas = ListaCompletaEtapas;


            return View(modelo);
        }

        public IActionResult CrearAsignaturas(int IdCurso)
        {
            var modelo = new AsignaturaCreateViewModel();
            modelo.CursoId = IdCurso;
            return View(modelo);
        }

        [HttpPost]
        public IActionResult CrearAsignaturas(AsignaturaCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var nuevaAsignatura = new Asignaturas
                {
                    Nombre = model.nombreasignatura,
                    CursosId = model.CursoId
                };

                context.Asignaturas.Add(nuevaAsignatura);
                context.SaveChanges();

                foreach (var unidadViewModel in model.Unidades)
                {
                    var nuevaUnidad = new Unidades
                    {
                        Nombre = unidadViewModel.Nombre,
                        AsignaturasID = nuevaAsignatura.Id,
                        Etapas = new List<Etapas>()
                    };

                    context.Unidades.Add(nuevaUnidad);
                    context.SaveChanges();

                    foreach (var etapaViewModel in unidadViewModel.Etapas)
                    {
                        var nuevaEtapa = new Etapas
                        {
                            Nombre = etapaViewModel.Nombre,
                            UnidadesId = nuevaUnidad.Id,
                            Porcentaje = etapaViewModel.Porcentaje
                        };

                        context.Etapas.Add(nuevaEtapa);
                    }
                }

                context.SaveChanges();

                return RedirectToAction("Index","Home");
            }

            return View(model);
        }

        public IActionResult Filtrar(int IdUnidad, int IdCurso, int IdAsignatura)
        {
            var AsignaturaDatos = context.Asignaturas.Where(a => a.Id == IdAsignatura).FirstOrDefault();
            var modelo = new AsignaturaDetallesViewModel();
            var ListaAlumnos = context.Alumnos
                .Where(a => a.alumnoCursos.Any(ac => ac.CursosId == IdCurso))
                .ToList();
            var Unidad = context.Unidades.Where(u => u.Id == IdUnidad).FirstOrDefault();
            var ListaUnidades = context.Unidades.Where(u => u.AsignaturasID == IdAsignatura).ToList();
            var ListaEtapasUnidad = context.Etapas.Where(e => e.UnidadesId == IdUnidad).ToList();

            modelo.Asignaturas = AsignaturaDatos;
            modelo.IdCurso = IdCurso;
            modelo.Alumnos = ListaAlumnos;
            modelo.Unidad = Unidad;
            modelo.Etapas = ListaEtapasUnidad;
            modelo.Unidades = ListaUnidades;
            return View("AsignaturasIndex", modelo);
        }
    }
}
