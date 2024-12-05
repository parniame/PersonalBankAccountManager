
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
    public class BankAccountConfig : BaseEntityConfig<BankAccount>
    {
        public override void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(BankAccount));
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Description)
                .HasColumnType(SqlDbType.NVarChar.ToString())
                .HasMaxLength(250);

            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Bank).WithMany().HasForeignKey(x => x.BankId).OnDelete(DeleteBehavior.NoAction);
            //builder.OwnsOne(
            //     banckAccount => banckAccount.Bank,

            //     bank =>
            //     {
            //         bank.Property(banckAccount => banckAccount.Name);
                     
            //         bank.WithOwner().HasForeignKey(banckAccount => banckAccount.BankAccountId);
            //         bank.Property(banckAccount => banckAccount.Id);
            //         bank.HasKey(banckAccount => banckAccount.Id);

            //         bank.ToTable(nameof(Bank));

            //         bank.Property(x => x.Id).ValueGeneratedOnAdd();

            //         bank.Property(x => x.Name).HasColumnType(SqlDbType.VarChar.ToString()).IsRequired();
            //     }
            //     );


        }
    }
}
