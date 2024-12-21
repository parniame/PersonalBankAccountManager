
using Abstraction.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;
using System.Data;


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
            
            builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<TransactionCategory>(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<TransactionPlan>(x => x.TransactionPlan).WithOne(x=> x.Transaction).HasForeignKey<Transaction>(x => x.TransactionPlanId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.BankAccount).WithMany().HasForeignKey(x => x.BankAccountId).OnDelete(DeleteBehavior.NoAction);
            //builder.HasOne(x => x.SecondBankAccount).WithMany().HasForeignKey(x => x.SecondBankAccountId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.TransActionDocument).WithOne().HasForeignKey<Transaction>(x => x.PictureId).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
