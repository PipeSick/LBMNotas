using LBMNotas.Context;
using LBMNotas.Models;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace LBMNotas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        //Constructor//
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }


        //Carga de datos para la vista.
        public IActionResult Index(int year = 2023)
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