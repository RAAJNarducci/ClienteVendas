using ClienteVendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Ignore(c => c.ValidationResult);
            builder.Ignore(c => c.CascadeMode);

            builder.ToTable("Produto");
        }
    }
}
