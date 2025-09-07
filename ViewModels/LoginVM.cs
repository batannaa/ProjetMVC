using System.ComponentModel.DataAnnotations;

public class LoginVM
{
    [Required(ErrorMessage = "Le champ {0} est requis.")]
    [EmailAddress(ErrorMessage = "Le champ {0} n'est pas une adresse email valide.")]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Le champ {0} est requis.")]
    [DataType(DataType.Password)]
    [Display(Name = "Mot de passe")]
    public string Password { get; set; }

    [Display(Name = "Se souvenir de moi")]
    public bool RememberMe { get; set; }
}
