using SportStore.Web.HtmlHelpers.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SportStore.Web.Models.Client
{
    /// <summary>
    /// Autor:          Jarosław Chełmiński
    /// Opis:           Klasa modelowa do obsługi Rejestracji Użytkownika
    /// Data:           17.10.15
    /// Modyfikacja:    Mateusz Kniżewski
    /// Opis:           Usunięcie pól stringowych i dodanie pola DateTime
    /// Data:           17.10.15
    /// Modyfikacja:    Jarosław Chełmiński
    /// Opis:           Dodanie nowych stringow / modyfikacja istniejących.
    /// Data:           24.10.15
    /// Modyfikacja:    Mateusz Kniżewski
    /// Opis:           Dodanie własnego atrybytu walidacyjnego MinimumLength, uzupełnienie formularza
    /// Data:           03.11.15
    /// </summary>
    public class RegisterModel
    {
        //Krok 1 - uzupełnienie danych osobowych

        [Display(Name = "Imię:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Pole ''Imię'', jest puste!")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko:")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Pole ''Nazwisko'', jest puste!")]
        public string LastName { get; set; }

        [Display(Name = "E-mail:")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "pole ''E-mail'', jest puste")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Nieprawidłowy E-mail!")]
        public string Email { get; set; }

        [Display(Name = "Hasło:")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "pole ''Hasło'', jest puste!")]
        [MinimumLength(8)]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło:")]
        [Required(ErrorMessage = "pole ''Powtórz hasło'', jest puste!")]
        [MinimumLength(8)]
        public string RepeatPassword { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Urodzenia:")]
        [Required(ErrorMessage = "pole ''Data Urodzenia'', jest puste!")]
        public DateTime DateOfBrith { get; set; }

        //Krok 2 - uzupełnienie danych o zamieszkaniu

        [Required(ErrorMessage = "Proszę zaznaczyć miasto")]
        public int selectedCity { get; set; }

        [Display(Name = "Miasto:")]
        public IEnumerable<SelectListItem> Cities { get; set; }

        [Display(Name = "Ulica:")]
        [Required(ErrorMessage = "Pole Ulica jest puste!")]
        [DataType(DataType.Text)]
        public string Street { get; set; }

        [Display(Name = "Kod pocztowy")]
        [Required(ErrorMessage = "Pole Kod Pocztowy jest puste!")]
        [DataType(DataType.PostalCode)]
        [PolandPostalCode]
        public string PostalCode { get; set; }
    }
}

// hehe komentarz