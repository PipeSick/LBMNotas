using System.ComponentModel.DataAnnotations;
using System.Timers;

namespace LBMNotas.Models
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "El Nombre es Requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Correo es Requerido")]
        [EmailAddress(ErrorMessage ="El Campo debe ser un correo válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La Contraseña es requerida")]
        [DataType(DataType.Password)]
        public string Password   { get; set; }
        public string Rol { get; set; }
    }
}
