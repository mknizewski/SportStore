using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportStore.Web.Models.Home
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa modelowa do obsługi newslettera
    /// Data:   16.10.15
    /// </summary>
    public class Newsletter
    {
        [Display(Name = "E-mail:")]
        [Required(ErrorMessage = "Pole E-mail jest wymagane!")]
        public string Email { get; set; }

        [Display(Name = "Jaki dział chcesz subskrybować:")]
        [Required(ErrorMessage = "Proszę określić dział")]
        public int TypeOfNews { get; set; }

        [Display(Name =  "Częstotliwość wiadomości:")]
        [Required(ErrorMessage = "Proszę określić częstotliwość")]
        public int Frequency { get; set; }
    }
}