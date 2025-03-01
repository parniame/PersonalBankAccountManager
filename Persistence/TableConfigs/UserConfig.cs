﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));


            builder.Property(x => x.UserName)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasColumnType(SqlDbType.NVarChar.ToString())
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasColumnType(SqlDbType.NVarChar.ToString())
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.DateOfBirth)
                           .HasColumnType("datetime");
                           //.HasDefaultValue(new DateTime(2024, 11, 25, 21, 29, 52, 990, DateTimeKind.Local).AddTicks(6358));
            //          .HasConversion(
            //d => d.ToString(),
            //d => Convert.ToDateTime(d)
            //);
            builder.Property(x => x.Email)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(320);
            builder.Property(x => x.PhoneNumber)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(12);
            builder.Property(x => x.DateCreated)
                           .HasColumnType("datetime");
                           //.HasDefaultValue(new DateTime(2024, 11, 25, 21, 29, 52, 990, DateTimeKind.Local).AddTicks(6358));

            builder.Property(x => x.DateUpdated)
                    .HasColumnType("datetime");
                    //.HasDefaultValue(new DateTime(2024, 11, 25, 21, 29, 52, 990, DateTimeKind.Local).AddTicks(6358));
            //                  .HasConversion(
            //d => d.ToString(),
            //d => Convert.ToDateTime(d)
            //);


            builder.HasOne(x => x.Updator).WithMany().HasForeignKey(x => x.UpdatorID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Creator).WithMany().HasForeignKey(x => x.CreatorID).OnDelete(DeleteBehavior.NoAction);
            builder.HasIndex(x => x.UserName).IsUnique();

        }
    }
}
