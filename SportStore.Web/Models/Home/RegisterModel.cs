using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportStore.Web.Models.Home
{
    /// <summary>
    /// Autor: Jarosław Chełmiński
    /// Opis: Klasa modelowa do obsługi Rejestracji Użytkownika
    /// Data: 17.10.15
    /// Modyfikacja: Mateusz Kniżewski
    /// Opis: Usunięcie pól stringowych i dodanie pola DateTime
    /// Data: 17.10.15
    /// Modyfikacja: Jarosław Chełmiński
    /// Opis: Dodanie nowych stringow / modyfikacja istniejących.
    /// Data: 24.10.15
    /// </summary>
    public class RegisterModel
    {
        [Display(Name = "Imię: ")]
        [Required(ErrorMessage = "Pole ''Imię'', jest puste!")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko: ")]
        [Required(ErrorMessage = "Pole ''Nazwisko'', jest puste!")]
        public string LastName { get; set; }

        [Display(Name = "E-mail: ")]
        [Required(ErrorMessage = "pole ''E-mail'', jest puste")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Nieprawidłowy E-mail!")]
        public string Email { get; set; }

        [Display(Name = "Hasło: ")]
        [Required(ErrorMessage = "pole ''Hasło'', jest puste!")]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name = "Powtórz hasło: ")]
        [Required(ErrorMessage = "pole ''Powtórz hasło'', jest puste!")]
        public string RepeatPassword { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Urodzenia:")]
        [Required(ErrorMessage = "pole ''Data Urodzenia'', jest puste!")]
        public DateTime DateOfBrith { get; set; }
    }
}
