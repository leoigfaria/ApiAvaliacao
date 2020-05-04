using ApiAvaliacao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAvaliacao.Data.Mapping
{
    public class ClientSupplierMap : IEntityTypeConfiguration<ClientSupplier>
    {
        public void Configure(EntityTypeBuilder<ClientSupplier> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Client)
                .WithMany(t => t.Suppliers)
                .HasForeignKey(t => t.ClientId);

            builder.HasOne(t => t.Supplier)
                .WithMany(t => t.Clients)
                .HasForeignKey(t => t.SupplierId);

            builder.ToTable("ClientSupplier");
        }
    }
}
