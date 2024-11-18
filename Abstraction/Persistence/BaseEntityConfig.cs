
using Abstraction.Domain;
using Domain;
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
            Type type = typeof(T);
            Type[] types = type.GetInterfaces();
            builder.ToTable(typeof(T).ToString());
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            if ( types.Contains(typeof(ITimeTraceble)))
            {
                builder.Property(x => x.DateCreated)
                           .HasColumnType(SqlDbType.SmallDateTime.ToString()).HasDefaultValue(DateTime.Now)
                           .IsRequired();
                builder.Property(x => x.DateUpdated)
                        .HasColumnType(SqlDbType.SmallDateTime.ToString())
                        .HasColumnType(SqlDbType.SmallDateTime.ToString()).HasDefaultValue(DateTime.Now)
                        .IsRequired();

            }
            else
            {
                builder.Ignore(x => x.DateCreated);
                builder.Ignore(x => x.DateUpdated);
            }
            if(!types.Contains(typeof(ITraceble<>)))
            {
                builder.Ignore(x => x.CreatorID);
                builder.Ignore(x => x.UpdatorID);
            }
        }

    }
}

