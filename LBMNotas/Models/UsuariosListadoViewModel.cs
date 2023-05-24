
namespace LBMNotas.Models
{
    public class UsuariosListadoViewModel : PaginacionModel
    {
        public List<UsuariosViewModel> Usuarios { get; set; }
        public string Mensaje { get; set; }
    }
}
