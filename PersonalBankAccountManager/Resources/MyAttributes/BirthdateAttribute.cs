using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace PersonalBankAccountManager.Resources.MyAttributes
{
    public class BirthdateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            if(value == null) return true;
            var birthDate = Convert.ToDateTime(value.ToString());
            var year = birthDate.Year;
            var yearNow = DateTime.Now.Year;
            return yearNow - year >= 18;

        }
    }
    

}
