using Abstraction.Service;
using DataTransferObject;
using Microsoft.AspNetCore.Http;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces
{
    public interface IBankService : IServiceBase<Bank>
    {
        Task<bool> CreateAsync(BankCommand bankDTO, IFormFile file);
        Task<bool> DeleteAsync(Guid Id);
    }
}
