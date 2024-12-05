
using Abstraction.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;
//using Persistence.Abstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.TableConfigs
{
    public class BankConfig : BaseEntityConfig<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Bank));
            builder.Property(x => x.Name).HasColumnType(SqlDbType.VarChar.ToString()).IsRequired();
            
            builder.HasOne(x => x.Picture).WithOne().HasForeignKey<Bank>(x => x.PictureId ).OnDelete(DeleteBehavior.NoAction);



        }
    }
}
