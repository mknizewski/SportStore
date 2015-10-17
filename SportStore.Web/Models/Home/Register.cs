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
    /// </summary>
    public class Register
    {
        //[Display(Name = "E-mail:")]
        //[Required(ErrorMessage = "To pole jest wymagane!")]
        public string Email { get; set; }

        //[Display(Name = "Password:")]
        //[Required(ErrorMessage = "To pole jest wymagane!")]
        public string Password { get; set; }

        //[Display(Name = "RepeatPassword")]
        //[Required(ErrorMessage = "To pole jest wymagane!")]
        public string RepeatPassword { get; set; }

        //[Display(Name = "Year")]
        //[Required(ErrorMessage = "To pole jest wymagane!")]
        public string Year { get; set; }

        //[Display(Name = "Month")]
        //[Required(ErrorMessage = "To pole jest wymagane!")]
        public string Month { get; set; }

        //[Display(Name = "Day")]
        //[Required(ErrorMessage = "To pole jest wymagane!")]
        public string Day { get; set; }
    }
}
