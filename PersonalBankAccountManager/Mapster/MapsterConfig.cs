using DataTransferObject;
using Mapster;
using Models.Entities;
using PersonalBankAccountManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapster
{
    public class PresentationMapsterConfig
    {

        public static void RegisterMapping()
        {
            TypeAdapterConfig<BankAccountCommand, BankAccountViewModel>.NewConfig()
                .Map(dest => dest.URL, src => src.Bank.Picture.FileAddress);
            TypeAdapterConfig<BankCommand,BankViewModel>.NewConfig()
                .Map(dest => dest.URL,src => src.Picture.FileAddress);



        }
    }
}

