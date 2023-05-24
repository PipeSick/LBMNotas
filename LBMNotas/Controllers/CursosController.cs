using LBMNotas.Context;
using LBMNotas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace LBMNotas.Controllers
{
    public class CursosController : Controller
    {
        private readonly ApplicationDbContext context;

        public CursosController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View("CrearCursoView");
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            Stream stream = ArchivoExcel.OpenReadStream();

            IWorkbook MiExcel = null;

            if (Path.GetExtension(ArchivoExcel.FileName) == ".xlsx")
            {
                MiExcel = new XSSFWorkbook(stream);
            }
            else
            {
                MiExcel = new HSSFWorkbook(stream);
            }

            ISheet HojaExcel = MiExcel.GetSheetAt(0);

            int cantidadFilas = HojaExcel.LastRowNum;

            List<Alumnos> lista = new List<Alumnos>();

            for (int i = 1; i <= cantidadFilas; i++)
            {

                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new Alumnos
                {
                    NumeroLista = int.Parse(fila.GetCell(0).ToString()),
                    Rut = fila.GetCell(1).ToString(),
                    NombreCompleto = fila.GetCell(2).ToString(),
                });
            }

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        public IActionResult GuardarCurso(IFormFile ArchivoExcel, Cursos curso)
        {
            if (ModelState.IsValid)
            {
                // Guardar el curso en la tabla "curso"
                var Cuso = new Cursos
                {
                    Nombre = curso.Nombre,
                    Año = curso.Año
                };
                context.Cursos.Add(Cuso);
                context.SaveChanges();
                int cursoId = Cuso.Id;

                Stream stream = ArchivoExcel.OpenReadStream();



                IWorkbook MiExcel = null;

                if (Path.GetExtension(ArchivoExcel.FileName) == ".xlsx")
                {
                    MiExcel = new XSSFWorkbook(stream);
                }
                else
                {
                    MiExcel = new HSSFWorkbook(stream);
                }

                ISheet HojaExcel = MiExcel.GetSheetAt(0);

                int cantidadFilas = HojaExcel.LastRowNum;

                List<Alumnos> lista = new List<Alumnos>();

                for (int i = 1; i <= cantidadFilas; i++)
                {

                    IRow fila = HojaExcel.GetRow(i);
                    var estudiante = new Alumnos
                    {
                        NumeroLista = int.Parse(fila.GetCell(0).ToString()),
                        Rut = fila.GetCell(1).ToString(),
                        NombreCompleto = fila.GetCell(2).ToString(),
                    };
                    context.Alumnos.Add(estudiante);
                    context.SaveChanges();
                    int IdEstudiante = estudiante.Id;



                    var alumnoCurso = new AlumnoCurso
                    {
                        AlumnosId = IdEstudiante,
                        CursosId = cursoId
                    };
                    context.alumnoCursos.Add(alumnoCurso);
                    context.SaveChanges();
                }

                
            }
            return RedirectToAction("Index", "Home");
        }






    }
}
