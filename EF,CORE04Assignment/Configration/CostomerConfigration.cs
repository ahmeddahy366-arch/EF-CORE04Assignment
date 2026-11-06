using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE04Assignment.Configration
{
    internal class CostomerConfigration:IEntityTypeConfiguration<Model.customer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Model.customer> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.FullName).IsRequired().HasMaxLength(100).HasColumnType("nvarchar(100)");
            builder.Property(c => c.email).IsRequired().HasMaxLength(100).HasColumnType("nvarchar(100)");
            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(15).HasColumnType("nvarchar(15)");
            builder.Property(c => c.address).IsRequired().HasMaxLength(200).HasColumnType("nvarchar(200)");
            builder.Property(c => c.customerType).IsRequired().HasMaxLength(50).HasColumnType("nvarchar(50)");
            builder.Property(c => c.nationalld).IsRequired().HasMaxLength(20).HasColumnType("nvarchar(20)");

        }
    
    }
}
