using Ninject;
using SportStore.Domain.Abstract;
using SportStore.Web.Models.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportStore.Web.HtmlHelpers.ValidationAttributes
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa sprawdza czy podany email nie występuje już w bazie newsletterów
    /// Data:   03.11.15
    /// </summary>
    public class UniqueNewsletterEmailAdress : ValidationAttribute
    {
        private INewsletterRepository _newsletterRepository;

        [Inject]
        public INewsletterRepository NewsletterRepository
        {
            get { return _newsletterRepository; }
            set { _newsletterRepository = value; }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = ((NewsletterModel)validationContext.ObjectInstance).Email;
            var isExists = _newsletterRepository.Newsletters.Select(x => x.email).Where(x => x.Equals(model)).FirstOrDefault();

            if (isExists != null)
                return new ValidationResult("Dany adres istnieje w bazie!");

            return ValidationResult.Success;
        }
    }
}