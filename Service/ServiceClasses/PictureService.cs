using Abstraction.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Service.ServiceInterfaces;
using Models.Entities;
using Abstraction.Domain;


namespace Service.ServiceClasses
{
    public class PictureService : ServiceBase<Picture>,IPictureService
    {
        private readonly IBaseRepository<Picture> _baseRepository;

        public PictureService(IBaseRepository<Picture> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<string> AddFileAsync(IFormFile file)
        {
            var root = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images");
            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);
            var fileAddress = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var fullAddress = Path.Combine(root, fileAddress);

            if (fullAddress != null)
            {
                using (var stream = new FileStream(fullAddress, FileMode.Create))
                {
                    stream.Position = 0;
                    stream.Flush();
                    await file.CopyToAsync(stream);
                    return fullAddress;
                }
            }
            throw new CodeErrorException();

        }
        public  async Task<bool> DeleteAsync(Guid Id,string fileAddress)
        {
            var check = await _baseRepository.GetByIdAsync(Id);
            if (check == null)
            {
                throw new ItemNotFoundException("آیدی");
            }
            //delete object
            var result = await _baseRepository.DeleteAsync(Id);
            if (!result)
            {
                throw new CodeErrorException();
            }
            File.Delete(fileAddress);
            return result;
        }
    }
}
