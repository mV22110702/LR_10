using LR_10.Pages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LR_10.Models
{
    public class RegistrationForm: IValidatableObject
    {
        [Required]
        [Display(Name = "First name")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Consultation date")]
        [DataType(DataType.DateTime)]
        public DateTime ConsultationDate { get; set; }

        [Required]
        public ProductEnum Product { get; set; } = ProductEnum.None;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if (
                DateTime.Now >= ConsultationDate
                )
            {
                errors.Add(
                    new ValidationResult(
                        $"Consultation date cannot be earlier then {DateTime.Now}",
                        new List<string> { nameof(ConsultationDate) }
                    )
                );
            }
            if (
                ConsultationDate.DayOfWeek == DayOfWeek.Saturday ||
                ConsultationDate.DayOfWeek == DayOfWeek.Sunday
                )
            {
                errors.Add(
                    new ValidationResult(
                        $"Consultation date cannot be a weekend",
                        new List<string> { nameof(ConsultationDate) }
                    )
                );
            }
            if (
                ConsultationDate.DayOfWeek == DayOfWeek.Monday &&
                Product == ProductEnum.Basics
                )
            {
                var logger = validationContext.GetService<ILogger<RegistrationForm>>();
                logger.LogCritical("MONDAY & BASICS");
                errors.Add(
                   new ValidationResult(
                       $"Basics cannot be consulted on mondays",
                       new List<string> { nameof(Product) }
                   )
               );
            }
            if (
                Product == ProductEnum.None
                )
            {
                errors.Add(
                   new ValidationResult(
                       $"Product is required",
                       new List<string> { nameof(Product) }
                   )
               );
            }

            return errors;
        }
    }
}
