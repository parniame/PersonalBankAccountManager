using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.TableConfigs
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));

            builder.Property(x => x.Name).HasColumnType(SqlDbType.VarChar.ToString()).IsRequired();
            builder.Property(x => x.Description)
                .HasColumnType(SqlDbType.NVarChar.ToString())
                .HasMaxLength(250).IsRequired(false);
            builder.Property(x => x.PersianName)
               .HasColumnType(SqlDbType.NVarChar.ToString())
               .HasMaxLength(50)
               .IsRequired();
           

            
        }
    }
}
