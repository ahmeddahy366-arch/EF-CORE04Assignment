using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE04Assignment.Configration
{
    internal class TransactionConfigration:IEntityTypeConfiguration<Model.transaction>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Model.transaction> builder)
        {
            builder.HasKey(t => t.transactionNumber);
            builder.Property(t => t.transactionDate).IsRequired().HasColumnType("datetime");
            builder.Property(t => t.amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(t => t.transactionType).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(t => t.notes).HasColumnType("nvarchar(200)");
            builder.HasOne(t => t.account).WithMany(a => a.transaction).HasForeignKey(t => t.accountId);
        }
   
    }
}
