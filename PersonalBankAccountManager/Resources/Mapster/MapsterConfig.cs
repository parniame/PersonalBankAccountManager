using DataTransferObject;
using Mapster;
using PersonalBankAccountManager.Models;


namespace PersonalBankAccountManager.Resources.Mapster
{
    public class PresentationMapsterConfig
    {

        public static void RegisterMapping()
        {
            
            TypeAdapterConfig<BankAccountCommand, BankAccountViewModel>.NewConfig()
                .Map(dest => dest.BankName,src => src.Bank.Name,srcCond => srcCond.Bank != null)
                .Map(dest => dest.URL, src => src.Bank.Picture.FileAddress, srcCond => srcCond.Bank.Picture != null);
            TypeAdapterConfig<BankCommand, BankViewModel>.NewConfig()
                .Map(dest => dest.URL, src => src.Picture.FileAddress,srcCond => srcCond.Picture != null);



        }
    }
}

