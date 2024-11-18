
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Models.Entities;
//using System.Data;


//namespace Persistence.TableConfigs
//{
//    public class DocumentConfig : IEntityTypeConfiguration<Document>
//    {
//        public void Configure(EntityTypeBuilder<Document> builder)
//        {
//            builder.ToTable(nameof(Document));
//            builder.HasKey(x => x.Id);
//            builder.Property(x => x.Id).ValueGeneratedOnAdd();

//            builder.Property(x => x.FileAddress)
//                .HasColumnType(SqlDbType.VarChar.ToString())
//                .HasMaxLength(256)
//                .IsRequired();
//        }
//    }
//}
