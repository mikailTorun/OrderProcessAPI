using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Config
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.CustomerEmail).HasMaxLength(50);
            builder.Property(x => x.CustomerGSM).HasMaxLength(20).IsRequired();
            builder.Property(x => x.CustomerName).HasMaxLength(50).IsRequired();
        }
    }
}
