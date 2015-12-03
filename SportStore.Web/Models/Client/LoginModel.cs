using System.ComponentModel.DataAnnotations;

namespace SportStore.Web.Models.Client
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa modelowa logowania klienta do serwisu SportStore
    /// Data:   07.11.15
    /// </summary>
    public class LoginModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email:")]
        [Required(ErrorMessage = "pole jest puste")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Niepoprawny adres email")]
        public string Login { get; set; }

        [Display(Name = "Hasło:")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "pole jest puste")]
        public string Password { get; set; }
    }
}