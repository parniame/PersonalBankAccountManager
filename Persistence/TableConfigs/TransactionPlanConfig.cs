
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
    public class TransactionPlanConfig : BaseEntityConfig<TransactionPlan>
    {
        public override void Configure(EntityTypeBuilder<TransactionPlan> builder)
        {
            base.Configure(builder);
            
            builder.ToTable(nameof(TransactionPlan));
            builder.Property(x => x.TillThisDate).HasColumnType(SqlDbType.SmallDateTime.ToString()).IsRequired();
            builder.Property(x => x.Name).HasColumnName("Transaction Plan Name").IsRequired();
            builder.Property(x => x.Amount).IsRequired();

           
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.IsWithdrawl).IsRequired();
            builder.Property(x => x.Description)
                .HasColumnType(SqlDbType.NVarChar.ToString())
                .HasMaxLength(250);
           
        }
        }
}
