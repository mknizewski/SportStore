using System.ComponentModel.DataAnnotations;

namespace SportStore.Web.Models.Employee
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa modelowa loginu pracownika
    /// Data:   20.11.15
    /// </summary>
    public class LoginModel
    {
        [Display(Name = "Email:")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Pole jest puste")]
        [RegularExpression(".+\\@sportstore.pl.+\\..+", ErrorMessage = "Adres email musi się kończyć znakami @sportstore.pl")]
        public string Login { get; set; }

        [Display(Name = "Hasło:")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Required(ErrorMessage = "Pole jest puste")]
        public string Password { get; set; }
    }
}