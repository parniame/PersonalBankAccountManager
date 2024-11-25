using System.ComponentModel.DataAnnotations;

namespace Shared
{
    public class BirthdateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
           var birthDate = Convert.ToDateTime(value);
            var year = birthDate.Year;
            var yearNow = DateTime.Now.Year;
            return yearNow - year >= 18; 

        }
    }
}
