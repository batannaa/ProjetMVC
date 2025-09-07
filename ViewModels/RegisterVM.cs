using System.ComponentModel.DataAnnotations;

public class RegisterVM
{
    [Required(ErrorMessage = "Le champ {0} est requis.")]
    [Display(Name = "Nom")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Le champ {0} est requis.")]
    [Display(Name = "Prénom")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Le champ {0} est requis.")]
    [EmailAddress(ErrorMessage = "Le champ {0} n'est pas une adresse email valide.")]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Le champ {0} est requis.")]
    [StringLength(100, ErrorMessage = "Le {0} doit avoir au moins {2} et au maximum {1} caractères de long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Mot de passe")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirmer le mot de passe")]
    [Compare("Password", ErrorMessage = "Le mot de passe et la confirmation ne correspondent pas.")]
    public string ConfirmPassword { get; set; }
}