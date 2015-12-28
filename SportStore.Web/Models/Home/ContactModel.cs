using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportStore.Web.Models.Home
{
    public class ContactModel
    {
        public int Id_Client { get; set; }
        [Required(ErrorMessage = "Pole Email jest wymagane!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Pole Temat jest wymagane!")]
        public string Thread { get; set; }
        [Required(ErrorMessage = "Te pole jest wymagane!")]
        public string Content { get; set; }
    }
}