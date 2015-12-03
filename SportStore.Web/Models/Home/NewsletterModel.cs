using SportStore.Web.HtmlHelpers.ValidationAttributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SportStore.Web.Models.Home
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa modelowa do obsługi newslettera
    /// Data:   16.10.15
    /// </summary>
    public class NewsletterModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail:")]
        [Required(ErrorMessage = "Pole E-mail jest wymagane!")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Nieprawidłowy E-mail!")]
        [UniqueNewsletterEmailAdress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę określić dział")]
        public int selectedTypeOfNews { get; set; }

        [Display(Name = "Dział:")]
        public IEnumerable<SelectListItem> TypeOfNews { get; set; }
    }
}