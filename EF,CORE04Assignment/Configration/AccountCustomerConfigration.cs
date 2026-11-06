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
    public class AccountCustomerConfigration : IEntityTypeConfiguration<AccountCustomer>
    {
        public void Configure(EntityTypeBuilder<AccountCustomer> builder)
        {
            builder.HasKey(ac => new { ac.accountsId, ac.customersId });
            builder.Property(ac=>ac.ownerShipType).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(ac => ac.ownerShipStartDate).IsRequired().HasColumnType("date");
            builder.Property(ac => ac.AccountStuats).IsRequired().HasColumnType("nvarchar(50)");
            builder.HasOne(ac => ac.customers).WithMany(c => c.accountCustomer).HasForeignKey(ac => ac.customersId);
            builder.HasOne(ac => ac.accounts).WithMany(a => a.accountCustomer).HasForeignKey(ac => ac.accountsId);

        }
    }
}
