﻿using DataTransferObject;
using Mapster;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

            TypeAdapterConfig<User, UserResult>.NewConfig()
                .Map(dest => dest.Id,src => src.Id)
                .Map(dest => dest.DateOfBirth, src => DateOnly.FromDateTime(src.DateOfBirth.Value),srcCond => srcCond.DateOfBirth.HasValue)
                .Map(dest => dest.DateCreated,src => src.DateCreated)
                .Map(dest => dest .DateUpdated,src => src.DateUpdated)
                .Map(dest => dest.CreatorName, src => src.Creator.FirstName+"  " + src.Creator.LastName,srcCond => srcCond.Creator != null)
                .Map(dest => dest.UpdatorName, src => src.Updator.FirstName+ "  "+ src.Updator.LastName, srcCond => srcCond.Updator != null)
            ;
            TypeAdapterConfig<RegisterCommand, User>.NewConfig();

            TypeAdapterConfig<TransactionPlanCommand, TransactionPlan>.NewConfig()
                .Map(dest => dest.Name, src => src.UniqueName);
            TypeAdapterConfig<TransactionCommand, Transaction>.NewConfig()
                .Map(dest => dest.TransActionDocument, src => src.Picture);
            TypeAdapterConfig<Bank, BankCommand>.NewConfig()
                .Map(dest => dest.Picture, src => src.Picture);
            TypeAdapterConfig<BankAccount, BankAccountResult>.NewConfig()
                .Map(dest => dest.Bank, src => src.Bank);
            TypeAdapterConfig<TransactionPlan, TransactionPlanCommand>.NewConfig()
                .Map(dest => dest.UniqueName, src => src.Name);

            TypeAdapterConfig<TransactionPlan, TransactionPlanArgs>.NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.IsPaid, src => src.IsPaid);
            
            TypeAdapterConfig<TransactionPlan, TransactionPlanResult>.NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest .Transaction, src => src.Transaction)
                .Map(dest => dest.IsPaid, src => src.IsPaid)
                .Map(dest => dest.Transaction.Category,src => src.Transaction.Category);
                
            TypeAdapterConfig<Bank, BankArgs>.NewConfig()
                .Map(dest => dest.Picture, src => src.Picture)
                .Map(dest => dest.URL, src => src.Picture.FileAddress);
            TypeAdapterConfig<Bank, BankResult>.NewConfig()
                .Map(dest => dest.URL, src => src.Picture.FileAddress)
                .Map(dest => dest.CreatorName, src => src.Creator.FirstName + "  " + src.Creator.LastName, srcCond => srcCond.Creator != null)
                .Map(dest => dest.UpdatorName, src => src.Updator.FirstName + "  " + src.Updator.LastName, srcCond => srcCond.Updator != null);
            TypeAdapterConfig<TransactionCategory, CategoryResult>.NewConfig()
                .Map(dest => dest.IsWithdrawl, src => src.IsWithdrawl)
                .Map(dest => dest.CreatorName, src => src.Creator.FirstName + "  " + src.Creator.LastName, srcCond => srcCond.Creator != null)
                .Map(dest => dest.UpdatorName, src => src.Updator.FirstName + "  " + src.Updator.LastName, srcCond => srcCond.Updator != null);
            TypeAdapterConfig<BankAccount, BankAccountArgs>.NewConfig()
                 .Map(dest => dest.URL, src => src.Bank.Picture.FileAddress);
            TypeAdapterConfig<BankAccount, BankAccountResult>.NewConfig()
                .Map(dest => dest.Bank, src => src.Bank)
                 .Map(dest => dest.BankName, src => src.Bank.Name)
                .Map(dest => dest.URL, src => src.Bank.Picture.FileAddress);
            TypeAdapterConfig<Transaction, TransactionArgs>.NewConfig()
                .Map(dest => dest.Category, src => src.Category)
                .Map(dest => dest.TransactionPlan, src => src.TransactionPlan)
                .Map(dest => dest.BankAccount, src => src.BankAccount)
                .Map(dest => dest.Picture, src => src.TransActionDocument);
                
            TypeAdapterConfig<TransactionArgs, Transaction>.NewConfig()
                 .Map(dest => dest.Title, src => src.Title)
                 .Map(dest => dest.Description, src => src.Description)
                 .Map(dest => dest.CategoryId, src => src.CategoryId)
                 .Map(dest => dest.Id,src => src.Id)
                 .Ignore(dest => dest.Category)
                 .Ignore(dest => dest.TransactionPlan)
                 .Ignore(dest => dest.BankAccount)
                 .Ignore(dest => dest.UserId)
                 .Ignore(dest => dest.DateCreated)
                 .Ignore(dest => dest.DateUpdated)
                 .Ignore(dest => dest.Amount)
                 .Ignore(dest => dest.IsWithdrawl);

        }
        
    }
}

