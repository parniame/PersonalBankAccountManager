
using Abstraction.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Persistence
{
    public class BaseEntityConfig<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {

            builder.ToTable(typeof(T).ToString());
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();


            builder.Property(x => x.DateCreated)
                       .HasColumnType(SqlDbType.DateTime.ToString()).HasDefaultValue(DateTime.Now);

            builder.Property(x => x.DateUpdated)
                    .HasColumnType(SqlDbType.DateTime.ToString()).HasDefaultValue(DateTime.Now);
                    


        }

    }
}

