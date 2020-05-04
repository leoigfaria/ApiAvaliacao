using ApiAvaliacao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAvaliacao.Data.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(t => t.Cpf)
                .HasMaxLength(11)
                .IsRequired(true)
                .IsUnicode(true);

            builder.Property(t => t.Cep)
                .HasMaxLength(8)
                .IsRequired(false);

            builder.Property(t => t.CreationDate)
                .IsRequired(true);

            builder.ToTable("Client");
        }
    }
}
