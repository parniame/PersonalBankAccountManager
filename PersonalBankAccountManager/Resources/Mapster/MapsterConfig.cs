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
                .Map(dest => dest.Id, src => src.Id);
            TypeAdapterConfig<BankAccountResult, BankAccountDetailsViewModel>.NewConfig()
                .Map(dest => dest.BankName, src => src.BankName)
                .Map(dest => dest.URL, src => src.URL);
            TypeAdapterConfig<TransactionResult, TransactionWithoutDetails>.NewConfig()
                .Map(dest => dest.IsWithdrawl, src => GetWithdrawlString(src.IsWithdrawl));
            TypeAdapterConfig<TransactionResult, TransactionDetailsViewModel>.NewConfig()
                .Map(dest => dest.CategoryName, src => src.Category.Name, srcCond => srcCond.Category != null);
            TypeAdapterConfig<TransactionResult, UpdateTransactionViewModel>.NewConfig()
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

