using SportStore.Web.HtmlHelpers.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace SportStore.Web.Models.Employee
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "To pole jest wymagane!")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [DataType(DataType.Text)]
        [MinimumLength(8)]
        public string Login { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [MinimumLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [MinimumLength(8)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RepeatPassword { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public int RegisterKey { get; set; }
    }
}