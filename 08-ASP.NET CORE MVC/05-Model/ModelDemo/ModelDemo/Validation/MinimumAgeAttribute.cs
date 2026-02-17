using System.ComponentModel.DataAnnotations;

namespace ModelDemo.Validation
{
    // Attribut pour vérifier un $age minimum
    public class MinimumAgeAttribute : ValidationAttribute
    {
        //propriété pour stocker l'age minimum requis
        private readonly int _minimumAge;

        //Contructeur avec l'âge minimum en paramètre
        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
            ErrorMessage = $"Vous devez avoir au moins {minimumAge} ans";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateNaissance)
            {
                // Calcul de l'âge
                var age = DateTime.Now.Year - dateNaissance.Year;

                if (dateNaissance > DateTime.Now.AddYears(-age))
                {
                    age--;
                }

                if (age >= _minimumAge)
                {
                    return ValidationResult.Success;
                }

                
            }
            return new ValidationResult(ErrorMessage);
        }
    }
}
