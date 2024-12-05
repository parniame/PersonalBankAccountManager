
using Abstraction.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;
//using Persistence.Abstraction;
using System.Data;

namespace Persistence.TableConfigs
{
    public class CategoryConfig: BaseEntityConfig<TransactionCategory>
    {
        public override void Configure(EntityTypeBuilder<TransactionCategory> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(TransactionCategory));
            builder.HasOne(x => x.Updator).WithMany().HasForeignKey(x => x.UpdatorID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Creator).WithMany().HasForeignKey(x => x.CreatorID).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
