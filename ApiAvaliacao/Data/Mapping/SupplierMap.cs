using ApiAvaliacao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAvaliacao.Data.Mapping
{
    public class SupplierMap : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(t => t.Cnpj)
                .HasMaxLength(14)
                .IsRequired(true)
                .IsUnicode(true);

            builder.Property(t => t.Cep)
                .HasMaxLength(8)
                .IsRequired(false);

            builder.Property(t => t.CreationDate)
                .IsRequired(true);

            builder.ToTable("Supplier");
        }
    }
}
