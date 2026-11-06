using EF_CORE04Assignment.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE04Assignment.Configration
{
    public class AccountConfigration : IEntityTypeConfiguration<account>
    {
        public void Configure(EntityTypeBuilder<account> builder)
        {
            builder.Property(p => p.accountNumber).ValueGeneratedNever();

            builder.Property(a => a.accountType).IsRequired().HasMaxLength(50).HasColumnType("nvarchar(50)");
            builder.Property(a => a.CurrentBalance).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(a => a.openingDate).IsRequired().HasColumnType("date");
            builder.HasOne(a => a.branch).WithMany(b => b.accounts).HasForeignKey(a => a.branchId);

        }
    }
}
