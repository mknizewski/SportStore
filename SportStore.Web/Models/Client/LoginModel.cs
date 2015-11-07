using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        [Display(Name = "Login:")]
        [Required(ErrorMessage = "pole ''Login'', jest puste")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Login to twój email")] 
        public string Login { get; set; }

        [Display(Name = "Hasło:")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "pole ''Hasło'', jest puste")]
        public string Password { get; set; }
    }
}