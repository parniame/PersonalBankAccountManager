
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
    public class TransactionConfig : BaseEntityConfig<Transaction>
    {
        public override void Configure(EntityTypeBuilder<Transaction> builder)
        {
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
            builder.HasOne<TransactionPlan>(x => x.TransactionPlan).WithOne().HasForeignKey<Transaction>(x => x.TransactionPlanId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.BankAccount).WithMany().HasForeignKey(x => x.BankAccountId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.SecondBankAccount).WithMany().HasForeignKey(x => x.SecondBankAccountId).OnDelete(DeleteBehavior.NoAction);
            builder.OwnsMany(
                transaction => transaction.TransActionDocuments,
                doc =>
                {
                    doc.Property(transActionDocuments => transActionDocuments.FileAddress).HasColumnName("File Address");
                    doc.WithOwner().HasForeignKey(transActionDocuments => transActionDocuments.TransactionId);
                    doc.Property(transActionDocuments => transActionDocuments.Id);
                    doc.HasKey(transActionDocuments => transActionDocuments.Id);
                    doc.ToTable(nameof(Document));
                    
                    doc.Property(x => x.Id).ValueGeneratedOnAdd();

                    doc.Property(x => x.FileAddress)
                        .HasColumnType(SqlDbType.VarChar.ToString())
                        .HasMaxLength(256)
                        .IsRequired();
                }
                );
            
                
        }
    }
}
