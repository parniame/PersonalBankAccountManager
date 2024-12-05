using Abstraction.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.TableConfigs
{
    public class PictureConfig : BaseEntityConfig<Picture>
    {
        public override void Configure(EntityTypeBuilder<Picture> builder)
        {
            base.Configure(builder);

            builder.Property(transActionDocuments => transActionDocuments.FileAddress).HasColumnName("File Address");
            builder.ToTable(nameof(Picture));
            builder.Property(x => x.FileAddress)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(256)
                .IsRequired();
            builder.Ignore(x => x.DateCreated);
            builder.Ignore(x => x.DateUpdated);

        }
    }
}
