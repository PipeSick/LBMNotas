using Azure;
using LBMNotas.Context;
using LBMNotas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats;

namespace LBMNotas.Controllers
{
    public class AsignaturasController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        public AsignaturasController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        //Carga de la página index de asignaturas, se le pasa el id de la asignatura, y el id del curso al cual pertenece.
        [HttpGet]
        public IActionResult AsignaturasIndex(int IdAsignatura, int IdCurso)
        {            
            var modelo = new AsignaturaDetallesViewModel();
            //se obtienen los alumnos.
            var ListaAlumnos = context.Alumnos
        .Where(a => a.alumnoCursos.Any(ac => ac.CursosId == IdCurso))
        .ToList();
            //se obtienen los datos de la asignatura.
            var AsignaturaDatos = context.Asignaturas.Where(a => a.Id == IdAsignatura).FirstOrDefault();
            //se obtienen la lista de unidades que posee la asignatura
            var ListaUnidades = context.Unidades.Where(u => u.AsignaturasID == IdAsignatura).ToList();
            //se crea una nueva lista de etapas.
            var ListaCompletaEtapas = new List<Etapas>();
            var listacomentarios = new List<NotaFinalUnidad>();
            if (ListaUnidades is null)
            {
                return NotFound();
            }

            foreach (var unidad in ListaUnidades)
            {
                var ListaEtapasUnidad = context.Etapas.Where(e => e.UnidadesId == unidad.Id).ToList();
                foreach (var alumno in ListaAlumnos)
                {
                    var comentarios = context.NotaFinalUnidad.Where(nf => nf.AlumnoId == alumno.Id && nf.UnidadId == unidad.Id).ToList();
                    listacomentarios.AddRange(comentarios);
                }
                ListaCompletaEtapas.AddRange(ListaEtapasUnidad);
            }
            if (AsignaturaDatos == null) 
            {
                return NotFound();
            }


            var calificaciones = context.calificacionAlumnos.ToList();

            modelo.calificacions = calificaciones;
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
            var listaprofes = userManager.GetUsersInRoleAsync("profesor");
            modelo.CursoId = IdCurso;
            modelo.ListaProfes = listaprofes.Result.Select(u => u).ToList();
            return View(modelo);
        }

        [HttpPost]
        public IActionResult CrearAsignaturas(AsignaturaCreateViewModel model, string listaProfesores)
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

                var profeasignatura = new ProfesorAsignatura
                {
                    AsignaturasId = nuevaAsignatura.Id,
                    UserId = listaProfesores
                };

                context.ProfesorAsignatura.Add(profeasignatura);
                context.SaveChanges();
                foreach (var unidadViewModel in model.Unidades)
                {
                    var nuevaUnidad = new Unidades
                    {
                        Nombre = unidadViewModel.Nombre,
                        Descripcion = unidadViewModel.Descripcion,
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
            var listacomentarios = context.NotaFinalUnidad.Where(nf => nf.UnidadId == IdUnidad).ToList();
            var calificaciones = context.calificacionAlumnos.ToList();

            modelo.NotaFinalUnidads = listacomentarios;
            modelo.calificacions = calificaciones;
            modelo.Asignaturas = AsignaturaDatos;
            modelo.IdCurso = IdCurso;
            modelo.Alumnos = ListaAlumnos;
            modelo.Unidad = Unidad;
            modelo.Etapas = ListaEtapasUnidad;
            modelo.Unidades = ListaUnidades;
            return View("AsignaturasIndex", modelo);
        }

        public   IActionResult VistaNotasFinalesUnidad(int IdAsignatura)
        {
            var notasFinales = context.NotaFinalUnidad
    .Include(nf => nf.Alumno)
    .Include(nf => nf.Unidad.Asignaturas)
    .Where(nf => nf.Unidad.Asignaturas.Id == IdAsignatura)
    .ToList();

            return View(notasFinales);
        }

        public IActionResult EditarAsignatura (int IdAsignatura)
        {
            var modelo = new AsignaturasEditViewModel();
            //se obtienen los datos de la asignatura.
            var AsignaturaDatos = context.Asignaturas.Where(a => a.Id == IdAsignatura).FirstOrDefault();
            var idprofe = context.ProfesorAsignatura.Where(p => p.AsignaturasId ==  IdAsignatura).FirstOrDefault();
            var datosprofe = context.Users.Where(pa => pa.Id == idprofe.UserId).FirstOrDefault();

            //se obtienen la lista de unidades que posee la asignatura
            var ListaUnidades = context.Unidades.Where(u => u.AsignaturasID == IdAsignatura).ToList();
            //se crea una nueva lista de etapas.
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
            ViewBag.NombreProfe = datosprofe.UserName;
            var listaprofes = userManager.GetUsersInRoleAsync("profesor");
            modelo.ListaProfes = listaprofes.Result.Select(u => u).ToList();
            modelo.Asignaturas = AsignaturaDatos;
            modelo.Unidades = ListaUnidades;
            modelo.Etapas = ListaCompletaEtapas;
            return View(modelo);
        }

       public IActionResult GuardarAsignatura(AsignaturasEditViewModel asignaturaeditada)
        {
            var idasignatura = asignaturaeditada.Asignaturas.Id;
            if (ModelState.IsValid)
            {
                // Actualizar los datos de la asignatura en la base de datos
                var asignaturaAEditar = context.Asignaturas.Find(asignaturaeditada.Asignaturas.Id);
                asignaturaAEditar.Nombre = asignaturaeditada.Asignaturas.Nombre;
                context.Asignaturas.Update(asignaturaAEditar);

                // Actualizar los datos del profesor en la tabla intermedia (ProfesorAsignatura)
                var profeAEditar = context.ProfesorAsignatura
                    .Where(pa => pa.AsignaturasId == asignaturaeditada.Asignaturas.Id)
                    .FirstOrDefault();

                if (profeAEditar != null)
                {
                    context.ProfesorAsignatura.Remove(profeAEditar);
                }

                var nuevoProfe = new ProfesorAsignatura
                {
                    AsignaturasId = asignaturaeditada.Asignaturas.Id,
                    UserId = asignaturaeditada.ListaProfes[0].Id
                };

                context.ProfesorAsignatura.Add(nuevoProfe);

                context.SaveChanges();

                return RedirectToAction("EditarAsignatura", new { IdAsignatura = idasignatura });
            }

            // Si el modelo no es válido, regresar a la vista de edición con el modelo para mostrar los errores
            return View("Editar", asignaturaeditada);
        
    }

        public IActionResult AgregarUnidad(int IdAsignatura)
        {
            ViewBag.IdAsignatura = IdAsignatura;
            var modelo = new AgregarUnidadViewModel();
            return View(modelo);
        }
        [HttpPost]
        public IActionResult AgregarUnidad(AgregarUnidadViewModel nuevaunidad)
        {
            var idasignatura = nuevaunidad.IdAsignatura;
            if (ModelState.IsValid)
            {
                
                    var UnidadAgregar = new Unidades
                    {
                        Nombre = nuevaunidad.Unidades.Nombre,
                        Descripcion = nuevaunidad.Unidades.Descripcion,
                        AsignaturasID = nuevaunidad.IdAsignatura,
                        Etapas = new List<Etapas>(),
                    };

                    context.Unidades.Add(UnidadAgregar);
                    context.SaveChanges();

                    foreach (var etapa in nuevaunidad.Etapas)
                    {
                        var EtapasAgregar = new Etapas
                        {
                            Nombre = etapa.Nombre,
                            Porcentaje = etapa.Porcentaje,
                            UnidadesId = UnidadAgregar.Id
                        };
                        context.Etapas.Add(EtapasAgregar);
                    }
                    context.SaveChanges();       
              

            }

            return RedirectToAction("EditarAsignatura", new { IdAsignatura = idasignatura });
            
        }

        public IActionResult EliminarUnidad(int IdUnidad, int IdAsignatura)
        {
            var UnidadAEliminar = context.Unidades.Find(IdUnidad);
            if (UnidadAEliminar != null)
            {
                context.Unidades.Remove(UnidadAEliminar);
                context.SaveChanges();
                TempData["Mensaje"] = "La unidad ha sido eliminada exitosamente.";
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> EliminarAsignatura(int Id)
        {
            var asignaturaeliminar = context.Asignaturas.Find(Id);
            context.Asignaturas.Remove(asignaturaeliminar);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult EditarUnidadAsignatura(int IdUnidad)
        {
            var modelo = new AgregarUnidadViewModel();
            var datosunidad = context.Unidades.Find(IdUnidad);
            var listaidsetapas = context.Etapas.Where(u => u.UnidadesId == IdUnidad).ToList();
            modelo.Etapas = listaidsetapas;
            modelo.Unidades = datosunidad;
            return View(modelo);
        }

        [HttpPost]
        public IActionResult GuardarUnidadEditada(AgregarUnidadViewModel modelo)
        {
            var idAsignatura = modelo.Unidades.AsignaturasID;
            bool cambiosGuardados = false;
            var unidadeditada = context.Unidades.Find(modelo.Unidades.Id);
            unidadeditada.Nombre = modelo.Unidades.Nombre;
            unidadeditada.Descripcion = modelo.Unidades.Descripcion;
            context.Unidades.Update(unidadeditada);
            foreach (var etapa in modelo.Etapas)
                {
                    if (etapa.Id != 0)
                    {
                        // Es una etapa existente que se está editando
                        // Aquí puedes actualizar los campos de la etapa en la base de datos
                        // utilizando su Id y los nuevos valores de Nombre y Porcentaje.
                        var etapaeditada = context.Etapas.Find(etapa.Id);
                        etapaeditada.Nombre = etapa.Nombre;
                        etapaeditada.Porcentaje = etapa.Porcentaje;
                        etapaeditada.UnidadesId = modelo.Unidades.Id;
                        context.Etapas.Update(etapaeditada);
                    cambiosGuardados = true;
                }
                    else
                    {
                        // Es una nueva etapa que se está agregando
                        // Aquí puedes crear una nueva entidad de etapa y guardarla en la base de datos
                        // utilizando los valores de Nombre, Porcentaje y el Id de la Unidad asociada.
                        var nuevaetapa = new Etapas
                        {
                            Nombre = etapa.Nombre,
                            Porcentaje = etapa.Porcentaje,
                            UnidadesId = modelo.Unidades.Id

                        };

                        context.Etapas.Add(nuevaetapa);
                    cambiosGuardados = true;



                }
                context.SaveChanges();

                
            }
            if (cambiosGuardados)
            {
                return RedirectToAction("EditarAsignatura", new { IdAsignatura = idAsignatura });
            }
            else
            {
                return Json(new { success = false, errorMessage = "Ocurrió un error al guardar los cambios." });
            }
        }

        [HttpPost]
        public IActionResult EliminarEtapa(int id)
        {
            var etapaaeliminar = context.Etapas.Find(id);
            context.Etapas.Remove(etapaaeliminar);
            context.SaveChanges();
            return Ok();
            // Aquí debes implementar la lógica para eliminar la etapa de la base de datos utilizando el ID proporcionado.
            // Después de eliminar la etapa, puedes redirigir a la vista actual o devolver un resultado JSON indicando el éxito o el fallo de la operación.
        }

    }
}
