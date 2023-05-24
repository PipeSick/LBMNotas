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
        public IActionResult AsignaturasIndex()
        {
            return View();
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

                return RedirectToAction("Index");
            }

            return View(model);
        }


    }
}
