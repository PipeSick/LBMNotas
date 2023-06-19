namespace LBMNotas.Models
{
    public class UsuariosViewModel
    {
        public string IdUsuario { get; set; }
        public string Email { get; set; }
        
        public string Contraseña { get; set; }
        public string NombreUsuario { get; set; }
        public bool Estado { get; set; }
        public List<string> Roles { get; set; }
    }
}
