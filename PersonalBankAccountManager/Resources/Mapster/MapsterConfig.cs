using DataTransferObject;
using Mapster;
using PersonalBankAccountManager.Models;


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
            TypeAdapterConfig<TransactionPlanArgs, TransactionPlanViewModel>.NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest  => dest .Amount,src => src.Amount)
                .Map(dest => dest.IsWithdrawl,src => src.IsWithdrawl);
            TypeAdapterConfig<TransactionPlanResult, TransactionPlanWithoutDetails>.NewConfig()
                .Map(dest => dest.IsWithdrawl, src => GetWithdrawlString(src.IsWithdrawl))
                .Map(dest => dest.TransactionDateCreated,src => src.Transaction.DateCreated,srcCond => srcCond.Transaction != null);
            TypeAdapterConfig<TransactionPlanResult, TransactionPlanDtailsViewModel>.NewConfig()
                .Map(dest => dest.BankAccount, src => src.Transaction.BankAccount, srcCond => srcCond.Transaction != null)
                .Map(dest => dest.DateUpdated, src => src.Transaction.DateUpdated, srcCond => srcCond.Transaction != null)
                .Map(dest => dest.TransactionDescription, src => src.Transaction.Description, srcCond => srcCond.Transaction != null)
                .Map(dest => dest.Title, src => src.Transaction.Title, srcCond => srcCond.Transaction != null);
                //.Map(dest => dest.CategoryName,src=> src.Transaction.ca)
            TypeAdapterConfig<BankAccountResult, BankAccountDetailsViewModel>.NewConfig()
                .Map(dest => dest.BankName, src => src.BankName)
                .Map(dest => dest.URL, src => src.URL);
            TypeAdapterConfig<TransactionArgs, TransactionWithoutDetails>.NewConfig()
                .Map(dest => dest.IsWithdrawl, src => GetWithdrawlString(src.IsWithdrawl));
           
            TypeAdapterConfig<TransactionArgs, TransactionDetailsViewModel>.NewConfig()
                .Map(dest => dest.CategoryName, src => src.Category.Name, srcCond => srcCond.Category != null);
            TypeAdapterConfig<TransactionArgs, UpdateTransactionViewModel>.NewConfig()
              .Map(dest => dest.TransactionPlanViewModel, src => src.TransactionPlan)
              .Map(dest => dest.CategoryId,src => src.Category.Id,srcCond => srcCond.Category != null)
              .Map(dest => dest.BankAccountViewModel,src => src.BankAccount);
            //TypeAdapterConfig<BankAccountResult, UpdateBankAccountViewModel>.NewConfig()
            //    .Map(dest => dest.Bank, src => src.Bank);


        }
        private static string GetWithdrawlString(bool isWithdrawl)
        {
            if (isWithdrawl)
                return "واریز";
            return "برداشت";
        }


    }
}

