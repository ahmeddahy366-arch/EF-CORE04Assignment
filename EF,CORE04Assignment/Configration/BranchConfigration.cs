using EF_CORE04Assignment.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE04Assignment.Configration
{
    internal class BranchConfigration:IEntityTypeConfiguration<Model.Branch>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Model.Branch> builder)
        {
            builder.HasKey(b => b.code);
            builder.Property(b => b.name).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(b => b.address).IsRequired().HasColumnType("nvarchar(200)");
            builder.Property(b => b.phoneNumber).IsRequired().HasColumnType("nvarchar(15)");
            builder.HasOne(b => b.manager).WithOne(m => m.branch).HasForeignKey<Branch>(b=>b.managerid);
            builder.HasData( new Branch
            {
                code = 1,
                name = "Main Branch",
                address = "123 Main St, City",
                phoneNumber = "123-456-7890",
                managerid = 1



            },
            new Branch
            {
                code = 2,
                name = "Branch 2",
                address = "456 Elm St, City",
                phoneNumber = "987-654-3210",
                managerid = 2
            },new Branch{
                code = 3,
                name = "Branch 3",
                address = "789 Oak St, City",
                phoneNumber = "555-123-4567",
                managerid = 3
            }
            
             );
        }
    
    }
}
