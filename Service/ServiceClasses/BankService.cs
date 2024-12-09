using Abstraction.Domain;
using Abstraction.Service.Exceptions;
using DataTransferObject;
using Microsoft.AspNetCore.Http;
using Models.Entities;
using Persistence.Repositories;
using Service.Exceptions;
using Service.FileValidate;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceClasses
{
    public class BankService : ServiceBase<Bank>, IBankService
    {
        private readonly IBaseRepository<Bank> _baseRepository;
        public BankService(IBaseRepository<Bank> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<bool> CreateBankWithFileAsync(BankCommand bankDTO, IFormFile file)

        {

            if (!file.IsImage())
            {
                throw new InvalidImage();
            }


            var root = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images");
            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);
            var fileAddress = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var fullAddress = Path.Combine(root, fileAddress);
            //Create Picture Object
            bankDTO.Picture = new PictureArgs { FileAddress = fullAddress };

            var entity = MapToEntity(bankDTO);
            entity.DateCreated = DateTime.Now;
            entity.DateUpdated = DateTime.Now;


            bool isUnique = await IsUniqueAsync(entity, "Name");
            if (!isUnique)
            {
                throw new DuplicateUniquePropertyException( "بانک ");
            }

            var result = await _baseRepository.CreateAsync(entity);
            if (fullAddress != null)
            {
                using(var stream = new FileStream(fullAddress, FileMode.Create))
                {
                    stream.Position = 0;
                    stream.Flush();
                    await file.CopyToAsync(stream);
                }
            }
                //file.CopyTo(new FileStream(fullAddress, FileMode.Create));
            else
                throw new CodeErrorException();


            return result;
        }
        public override async Task<bool> CreateAsync<DTO>(DTO dto)
        {
            return await CreateUniqueAsync(dto, "Name", "بانک");
        }
    }
    
}
