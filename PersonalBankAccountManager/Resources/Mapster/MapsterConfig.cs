using DataTransferObject;
using Mapster;
using MD.PersianDateTime.Standard;
using PersonalBankAccountManager.Models;
using System.Globalization;


namespace PersonalBankAccountManager.Resources.Mapster
{
    public class PresentationMapsterConfig
    {

        public static void RegisterMapping()
        {

            TypeAdapterConfig<BankAccountArgs, BankAccountViewModel>.NewConfig()
                .Map(dest => dest.URL, src => src.URL, srcCond => srcCond.URL != null);
            TypeAdapterConfig<BankArgs, BankViewModel>.NewConfig()
                .Map(dest => dest.URL, src => src.URL, srcCond => srcCond.URL != null);
            TypeAdapterConfig<BankResult, BankWithDetailsViewModel>.NewConfig()
                .Map(dest => dest.URL, src => src.URL, srcCond => srcCond.URL != null)
                .Map(dest => dest.DateCreatedFarsi, src => toSolarCalender(src.DateCreated))
                .Map(dest => dest.DateUpdatedFarsi, src => toSolarCalender(src.DateUpdated));
            TypeAdapterConfig<CategoryResult, CategoryWithDetailsViewModel>.NewConfig()
                 .Map(dest => dest.IsWithdrawl, src => GetWithdrawlString(src.IsWithdrawl))
                .Map(dest => dest.DateCreatedFarsi, src => toSolarCalender(src.DateCreated))
                .Map(dest => dest.DateUpdatedFarsi, src => toSolarCalender(src.DateUpdated));
            TypeAdapterConfig<UserResult, UserWithDetailsViewModel>.NewConfig()
                .Map(dest => dest.DateOfBirth,src => toSolarCalenderDateOnly(src.DateOfBirth))
                .Map(dest => dest.DateCreatedFarsi, src => toSolarCalender(src.DateCreated))
                .Map(dest => dest.DateUpdatedFarsi, src => toSolarCalender(src.DateUpdated));
            TypeAdapterConfig<TransactionPlanArgs, TransactionPlanViewModel>.NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Amount, src => src.Amount)
                .Map(dest => dest.IsWithdrawl, src => src.IsWithdrawl)
                .Map(dest => dest.TillThisDate, src => src.TillThisDate)
                .Map(dest => dest.IsPaid,src => src.IsPaid);
            TypeAdapterConfig<TransactionPlanResult, TransactionPlanWithoutDetails>.NewConfig()
                .Map(dest => dest.IsWithdrawl, src => GetWithdrawlString(src.IsWithdrawl))
                .Map(dest => dest.IsPaid, src => src.IsPaid)
                .Map(dest => dest.IsOverdue, src => IsOverdue(src.TillThisDate))
                .Map(dest => dest.DateCreatedFarsi, src => toSolarCalender(src.DateCreated))
                .Map(dest => dest.DateUpdatedFarsi, src => toSolarCalender(src.DateUpdated))
                .Map(dest => dest.TillThisDateFarsi,src => toSolarCalender(src.TillThisDate)); 
            TypeAdapterConfig<TransactionPlanResult, UpdateTransactionPlanViewModel>.NewConfig()
                .Map(dest => dest.IsPaid, src => src.IsPaid)
                .Map(dest => dest.TillThisDateFarsi,src => toSolarCalender(src.TillThisDate))
                .Map(dest => dest.UniqueName,src => src.Name);
            TypeAdapterConfig<TransactionPlanResult, TransactionPlanDtailsViewModel>.NewConfig()
                .Map(dest => dest.TransactionDateCreatedFarsi, src => toSolarCalender(src.Transaction.DateCreated), srcCond => srcCond.Transaction != null)
                .Map(dest => dest.BankAccount, src => src.Transaction.BankAccount, srcCond => srcCond.Transaction != null)
                .Map(dest => dest.DateUpdatedFarsi, src => toSolarCalender(src.Transaction.DateUpdated), srcCond => srcCond.Transaction != null)
                .Map(dest => dest.TransactionDescription, src => src.Transaction.Description, srcCond => srcCond.Transaction != null)
                .Map(dest => dest.Title, src => src.Transaction.Title, srcCond => srcCond.Transaction != null)
                .Map(dest => dest.CategoryName, src => src.Transaction.Category.Name, srcCond => srcCond.Transaction != null && srcCond.Transaction.Category != null);///
            TypeAdapterConfig<BankAccountResult, BankAccountDetailsViewModel>.NewConfig()
                .Map(dest => dest.BankName, src => src.BankName)
                .Map(dest => dest.URL, src => src.URL);
            TypeAdapterConfig<BankAccountResult, BankAccountWithoutDetailsViewModel>.NewConfig()
                .Map(dest => dest.DateCreatedFarsi, src => toSolarCalender(src.DateCreated))
                .Map(dest => dest.DateUpdatedFarsi, src => toSolarCalender(src.DateUpdated));
            TypeAdapterConfig<TransactionArgs, TransactionWithoutDetails>.NewConfig()
                .Map(dest => dest.IsWithdrawl, src => GetWithdrawlString(src.IsWithdrawl))
                .Map(dest => dest.DateCreatedFarsi, src => toSolarCalender(src.DateCreated))
                .Map(dest => dest.DateUpdatedFarsi, src => toSolarCalender(src.DateUpdated)); ;

            TypeAdapterConfig<TransactionArgs, TransactionDetailsViewModel>.NewConfig()
                .Map(dest => dest.CategoryName, src => src.Category.Name, srcCond => srcCond.Category != null)
                .Map(dest => dest.URL,src => src.Picture.FileAddress,srcCond => srcCond.Picture != null );
            TypeAdapterConfig<TransactionArgs, UpdateTransactionViewModel>.NewConfig()
              .Map(dest => dest.TransactionPlanViewModel, src => src.TransactionPlan)
              .Map(dest => dest.CategoryId, src => src.Category.Id, srcCond => srcCond.Category != null)
              .Map(dest => dest.BankAccountViewModel, src => src.BankAccount)
              .Map(dest=> dest.FileArgs,src => src.Picture);
            TypeAdapterConfig<UpdateTransactionViewModel, TransactionArgs>.NewConfig()
                .Map(dest => dest.Picture, src => src.FileArgs);
            TypeAdapterConfig<BankAccountResult, UpdateBankAccountViewModel>.NewConfig()
                .Map(dest => dest.BankId, src => src.Bank.Id,srcCond => srcCond.Bank != null);


        }
        //public static bool Check(BankArgs src)
        //{
        //    if (src != null)
        //    {
        //        return src.Id != null;
        //    }
        //    return false;

        //}

        private static string GetWithdrawlString(bool isWithdrawl)
        {
            if (isWithdrawl)
                return "واریز";
            return "برداشت";
        }
        private static bool IsOverdue(DateTime dateTime)
        {
            var now = DateTime.Now;
            return dateTime <= now;
        }
        public static string toSolarCalender(DateTime? date)
        {
            if (!date.HasValue)
                return "";
            DateTime date2 = date.Value;
            PersianCalendar pc = new PersianCalendar();
            string PersianDate = string.Format("{0}/{1}/{2} {3}:{4}", pc.GetYear(date2), pc.GetMonth(date2), pc.GetDayOfMonth(date2), pc.GetHour(date2), pc.GetMinute(date2));


            return PersianDate;
        }
        public static string toSolarCalenderDateOnly(DateOnly? date)
        {
            if (!date.HasValue)
                return "";
            DateTime date2 = new DateTime(date.Value,new TimeOnly());
            PersianCalendar pc = new PersianCalendar();
            string PersianDate = string.Format("{0}/{1}/{2} ", pc.GetYear(date2), pc.GetMonth(date2), pc.GetDayOfMonth(date2));


            return PersianDate;
        }


    }
}

