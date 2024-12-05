using System.ComponentModel.DataAnnotations;
namespace PersonalBankAccountManager.Resources.MyAttributes
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            var selectedDateTime = Convert.ToDateTime(value);
            var selectedOnlyDate = DateOnly.FromDateTime(selectedDateTime);
            var nowDate = DateOnly.FromDateTime(DateTime.Now);
            return selectedOnlyDate > nowDate;

        }
    }
}
