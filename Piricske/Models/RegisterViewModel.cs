using System.ComponentModel.DataAnnotations;

namespace Piricske.Models
{
    public class RegisterViewModel
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "Az email megadása kötelező.")]
        [EmailAddress(ErrorMessage = "Érvénytelen email formátum.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A jelszó megadása kötelező.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "A jelszavak nem egyeznek.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        // További szükséges tulajdonságok és validációk
    }
}
