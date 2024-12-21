
using Abstraction.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

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
                       .HasColumnType("datetime");
            //.HasDefaultValue(new DateTime(2024, 11, 25, 21, 29, 52, 990, DateTimeKind.Local).AddTicks(6358));

            builder.Property(x => x.DateUpdated)
                    .HasColumnType("datetime");
            //.HasDefaultValue(new DateTime(2024, 11, 25, 21, 29, 52, 990, DateTimeKind.Local).AddTicks(6358));



        }

    }
}

