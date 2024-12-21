using System.ComponentModel.DataAnnotations;
namespace PersonalBankAccountManager.Resources.MyAttributes
{
    public class FutureDateAttribute : ValidationAttribute
    {
        
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            var selectedDateTime = Convert.ToDateTime(value);

            var selectedOnlyDate = new DateTime(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day, selectedDateTime.Hour, selectedDateTime.Minute,0);
            var nowDate = DateTime.Now;
            var nowDateOnlyDate = new DateTime(nowDate.Year,nowDate.Month, nowDate.Day, nowDate.Hour, nowDate.Minute, 0);
            return selectedOnlyDate > nowDateOnlyDate;

        }
    }
    public class UpdateFutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            var selectedDateTime = Convert.ToDateTime(value);

            var selectedOnlyDate = new DateTime(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day, selectedDateTime.Hour, selectedDateTime.Minute, 0);
            var nowDate = DateTime.Now;
            var nowDateOnlyDate = new DateTime(nowDate.Year, nowDate.Month, nowDate.Day, nowDate.Hour, nowDate.Minute, 0);
            return selectedOnlyDate > nowDateOnlyDate;

        }
    }
}
