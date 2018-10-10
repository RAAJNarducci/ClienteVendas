using ClienteVendas.Domain.Entities;
using ClienteVendas.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ClienteVendas.Infra.Data.Context
{
    public class MainContext : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cliente> Pessoas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new VendaMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Property("DataCadastro").IsModified = false;
                        break;
                }
            }

            return base.SaveChanges();
        }
    }
}
