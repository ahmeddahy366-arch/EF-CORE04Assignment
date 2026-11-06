using EF_CORE04Assignment.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE04Assignment.Configration
{
    internal class managerConfigration:IEntityTypeConfiguration<Model.manager>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Model.manager> builder)
        {
            builder.HasKey(m => m.id);
            builder.Property(m => m.FullName).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(m => m.Email).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(m => m.PhoneNumber).IsRequired().HasColumnType("nvarchar(15)");
            builder.Property(m => m.Hirdate).IsRequired().HasColumnType("datetime");
            builder.HasData(new manager[]
            {
                new manager
                {
                    id = 1,
                    FullName = "John Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "123-456-7890",
                    Hirdate = new DateTime(2020, 1, 1)
                },new manager
                {
                    id = 2,
                    FullName = "Jane Smith",
                     Email = "jane.doe@example.com",
                    PhoneNumber = "133-336-7890",
                    Hirdate = new DateTime(2020, 3, 1)
                },new manager
                {
                    id = 3,
                    FullName = "Bob Johnson",
                     Email = "bob.johnson@example.com",
                    PhoneNumber = "144-447-8901",
                    Hirdate = new DateTime(2020, 5, 1)
                }

            });
        }
    
    }
}
