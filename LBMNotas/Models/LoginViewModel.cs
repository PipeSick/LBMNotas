using System.ComponentModel.DataAnnotations;

namespace LBMNotas.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El Correo es Requerido")]
        [EmailAddress(ErrorMessage = "El Campo debe ser un correo válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La Contraseña es requerida")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Recuérdame")]
        public bool RememberMe { get; set;}
    }
}
