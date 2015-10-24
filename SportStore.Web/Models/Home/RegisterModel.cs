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
    /// </summary>
    public class RegisterModel
    {
        [Display(Name = "E-mail: ")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string Email { get; set; }

        [Display(Name = "Hasło: ")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string Password { get; set; }

        [Display(Name = "Powtórz hasło: ")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string RepeatPassword { get; set; }

        [Display(Name = "Data Urodzenia: ")]
        [Required(ErrorMessage = "To pole jest wymagan!")]
        public DateTime DateOfBrith { get; set; }
    }
}
