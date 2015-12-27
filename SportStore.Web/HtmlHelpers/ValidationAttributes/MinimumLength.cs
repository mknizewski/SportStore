using System.ComponentModel.DataAnnotations;

namespace SportStore.Web.HtmlHelpers.ValidationAttributes
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa sprawdza czy została spełniona minimalna określona długość ciągu znakowego
    /// Data:   03.11.15
    /// </summary>
    public class MinimumLength : ValidationAttribute
    {
        public MinimumLength(int length)
            : base("{0} musi zawierać " + length + " lub więcej znaków!")
        {
            _length = length;
        }

        private int _length { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var box = value.ToString();
                var boxLen = box.Length;

                if (boxLen < _length)
                {
                    var messageError = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(messageError);
                }
            }

            return ValidationResult.Success;
        }
    }
}