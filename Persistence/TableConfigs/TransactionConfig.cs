
using Abstraction.Persistence;
using Domain.Entities;
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
    public class TransactionConfig : BaseEntityConfig<Transaction>
    {
        public override void Configure(EntityTypeBuilder<Transaction> builder)
        {
            base.Configure(builder);
            
            builder.ToTable(nameof(Transaction));
            builder.Property(x => x.Amount)
                .IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.IsWithdrawl).IsRequired();
            builder.Property(x => x.Description)
                .HasColumnType(SqlDbType.NVarChar.ToString())
                .HasMaxLength(250);
            
            builder.HasOne<User>(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<TransactionCategory>(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<TransactionPlan>(x => x.TransactionPlan).WithOne(x=> x.Transaction).HasForeignKey<Transaction>(x => x.TransactionPlanId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.BankAccount).WithMany().HasForeignKey(x => x.BankAccountId).OnDelete(DeleteBehavior.NoAction);
            //builder.HasOne(x => x.SecondBankAccount).WithMany().HasForeignKey(x => x.SecondBankAccountId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.TransActionDocuments).WithMany().UsingEntity<PictureTransaction>(
                    builder => builder.HasOne<Picture>().WithMany().HasForeignKey( x => x.PictureId).OnDelete(DeleteBehavior.NoAction),
                    builder => builder.HasOne<Transaction>().WithMany().HasForeignKey(x => x.TransactionId).OnDelete(DeleteBehavior.NoAction)
                    );
            
            
                
        }
    }
}
