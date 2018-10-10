using ClienteVendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Infra.Data.Mappings
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasKey(x => new { x.ClienteId, x.ProdutoId });

            builder.Property(x => x.ClienteId)
                .IsRequired();

            builder.Property(x => x.ProdutoId)
                .IsRequired();

            builder.Property(x => x.DataVenda)
                .HasColumnType("datetime");

            builder.Property(x => x.Quantidade)
                .IsRequired();

            builder.Ignore(c => c.ValidationResult);
            builder.Ignore(c => c.CascadeMode);

            builder.ToTable("Venda");
        }
    }
}
