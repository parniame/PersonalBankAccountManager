using DataTransferObject;
using Mapster;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapster
{
    public class ServiceMapsterConfig
    {
        
            public static void RegisterMapping()
            {
            //TypeAdapterConfig<Role, RoleDTO>.NewConfig()
            //    .Map(x => x.Description, x => x.RoleDescription)
            //    .Map(x => x.EnglishName, x => x.RoleName)
            //    .Map(x => x.PersianName, x => x.RolePersianName);

            TypeAdapterConfig<User, RegisterCommand>.NewConfig();


            TypeAdapterConfig<RegisterCommand, User>.NewConfig();

            TypeAdapterConfig<TransactionPlanCommand, TransactionPlan>.NewConfig()
                .Map(dest => dest.Name, src => src.UniqueName);
            TypeAdapterConfig<Bank, BankCommand>.NewConfig()
                .Map(dest => dest.Picture, src => src.Picture);
            TypeAdapterConfig<BankAccount, BankAccountCommand>.NewConfig()
                .Map(dest => dest.Bank, src => src.Bank);
            TypeAdapterConfig<TransactionPlan, TransactionPlanCommand>.NewConfig()
                .Map(dest => dest.UniqueName, src => src.Name);
                

            }
        }
    }

