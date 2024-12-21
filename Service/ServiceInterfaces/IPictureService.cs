using Abstraction.Service;
using Microsoft.AspNetCore.Http;
using Models.Entities;

namespace Service.ServiceInterfaces
{
    public interface IPictureService: IServiceBase<Picture>
    {
        Task<string> AddFileAsync(IFormFile file);
        Task<bool> DeleteAsync(Guid Id, string fileAddress);
    }
}
