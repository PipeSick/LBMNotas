using LBMNotas.Context;
using LBMNotas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace LBMNotas.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        //Constructor//
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            this.context = context;
            this.userManager = userManager;
        }


        //Carga de datos para la vista.
        public async Task<IActionResult> Index(int year = 2023)
        {
            var usuario = await userManager.GetUserAsync(User);
            if (userManager.IsInRoleAsync(usuario, "admin").Result)
            {
                var listacursos = context.Cursos.Where(c => c.Año == year).ToList();

                var modelo = new CursosListadoViewModel();

                foreach (var curso in listacursos)
                {
                    var listadeidsdeasignaturas = context.Asignaturas.Where(c => c.CursosId == curso.Id).ToList();
                    var listadeidsdealumnos = context.alumnoCursos.Where(c => c.CursosId == curso.Id).ToList();
                    foreach (var alumno in listadeidsdealumnos)
                    {
                        var listaalumnos = context.Alumnos.Where(al => al.Id == alumno.AlumnosId).ToList();
                        modelo.alumnosListados = listaalumnos;
                    }
                    foreach (var asignatura in listadeidsdeasignaturas)
                    {
                        var listaasignaturas = context.Asignaturas.Where(a => a.Id == asignatura.Id).ToList();
                        modelo.AsignaturasListadas = listaasignaturas;
                    }
                }

                modelo.CursosListado = listacursos;
                modelo.añoseleccionado = year;

                return View("Index", modelo);
            }
            var modelo2 = new CursosListadoViewModel();
            var listacursoprofesor = context.ProfesorAsignatura.Where(pa => pa.UserId == usuario.Id).ToList();
                foreach (var IdAsignatura in listacursoprofesor)
                {
                    var listaasignaturas = context.Asignaturas.Where(a => a.Id == IdAsignatura.AsignaturasId).ToList();
                    modelo2.AsignaturasListadas = listaasignaturas;
                }
            if (modelo2.AsignaturasListadas is null)
            {
                List<Cursos> listadocursosvacio = new List<Cursos> { };
                modelo2.CursosListado = listadocursosvacio;
                return View(modelo2);
            }

            foreach (var asignaturas in modelo2.AsignaturasListadas)
            {
                var cursos = context.Cursos.Where(c => c.Id == asignaturas.CursosId && c.Año == year).ToList();
                modelo2.CursosListado = cursos;
            }

            foreach (var cursos in modelo2.CursosListado)
            {
                var listadeidsdealumnos = context.alumnoCursos.Where(c => c.CursosId == cursos.Id).ToList();
                foreach (var alumno in listadeidsdealumnos)
                {
                    var listaalumnos = context.Alumnos.Where(al => al.Id == alumno.AlumnosId).ToList();
                    modelo2.alumnosListados = listaalumnos;
                }
            }

            modelo2.añoseleccionado = year;
            return View("Index", modelo2);         
            

        }       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}