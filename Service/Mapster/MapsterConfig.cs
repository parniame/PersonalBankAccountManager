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
    public class MapsterConfig
    {
        
            public static void RegisterMapping()
            {
            //TypeAdapterConfig<Role, RoleDTO>.NewConfig()
            //    .Map(x => x.Description, x => x.RoleDescription)
            //    .Map(x => x.EnglishName, x => x.RoleName)
            //    .Map(x => x.PersianName, x => x.RolePersianName);

            TypeAdapterConfig<User, RegisterCommand>.NewConfig();


            TypeAdapterConfig<RegisterCommand, User>.NewConfig();
                   

                //TypeAdapterConfig<Category, CategoryDTO>.NewConfig()
                //    .Map(dest => dest.Name, src => src.CategoryName)
                //    .Map(dest => dest.Message, src => src.Description);

                //TypeAdapterConfig<CategoryDTO, Category>.NewConfig()
                //.Map(dest => dest.CategoryName, src => src.Name)
                //    .Map(dest => dest.Description, src => src.Message);

                

            }
        }
    }

