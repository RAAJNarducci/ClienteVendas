using ClienteVendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("varchar(11)");

            builder.Property(x => x.DataCadastro)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.DataNascimento)
                .HasColumnType("datetime");

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Celular)
                .HasMaxLength(11)
                .HasColumnType("varchar(11)");

            builder.HasOne(c => c.Endereco)
                .WithOne(e => e.Cliente)
                .HasForeignKey<Cliente>(e => e.EnderecoId)
                .IsRequired();

            builder.Ignore(c => c.ValidationResult);
            builder.Ignore(c => c.CascadeMode);

            builder.ToTable("Cliente");
        }
    }
}
