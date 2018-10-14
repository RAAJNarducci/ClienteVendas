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
            SeedProducts(modelBuilder);
            SeedAdress(modelBuilder);
            SeedClients(modelBuilder);
            SeedSales(modelBuilder);
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

        private void SeedProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 1,
                Descricao = "Celular Motorola G6",
                Valor = Convert.ToDecimal("1100,00"),
                DataCadastro = DateTime.Now
            });
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 2,
                Descricao = "Celular LG Q6",
                Valor = Convert.ToDecimal("1200,00"),
                DataCadastro = DateTime.Now
            });
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = 3,
                Descricao = "Celular Samsung J7",
                Valor = Convert.ToDecimal("1300,00"),
                DataCadastro = DateTime.Now
            });
        }

        private void SeedAdress(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>().HasData(new Endereco
            {
                Id = 1,
                Bairro = "Centro",
                CEP = "14801790",
                Cidade = "Araraquara",
                Complemento = "Casa",
                Estado = "SP",
                Logradouro = "Av. 13 de maio",
                Numero = "999",
            });
            modelBuilder.Entity<Endereco>().HasData(new Endereco
            {
                Id = 2,
                Bairro = "Jardim Paulista",
                CEP = "15900000",
                Cidade = "Taquaritinga",
                Complemento = "Casa",
                Estado = "SP",
                Logradouro = "Rua 22",
                Numero = "111",
            });
        }

        private void SeedClients(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(new Cliente
            {
                Id = 1,
                Ativo = true,
                Celular = "16991388733",
                Cpf = "41282809322",
                DataNascimento = Convert.ToDateTime("13/05/1994"),
                Email = "cliente01@gmail.com",
                EnderecoId = 1,
                Nome = "Cliente 01",
                DataCadastro = Convert.ToDateTime("14/10/2018")
            });
            modelBuilder.Entity<Cliente>().HasData(new Cliente
            {
                Id = 2,
                Ativo = true,
                Celular = "16981722833",
                Cpf = "39902938222",
                DataNascimento = Convert.ToDateTime("10/10/1989"),
                Email = "cliente02@gmail.com",
                EnderecoId = 2,
                Nome = "Cliente 02",
                DataCadastro = Convert.ToDateTime("14/10/2018")
            });
        }

        private void SeedSales(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Venda>().HasData(new Venda
            {
                Id = 1,
                ProdutoId = 1,
                Quantidade = 1,
                ClienteId = 1,
                DataVenda = Convert.ToDateTime("02/09/2018")
            });
            modelBuilder.Entity<Venda>().HasData(new Venda
            {
                Id = 2,
                ProdutoId = 1,
                Quantidade = 1,
                ClienteId = 2,
                DataVenda = Convert.ToDateTime("03/09/2018")
            });
            modelBuilder.Entity<Venda>().HasData(new Venda
            {
                Id = 3,
                ProdutoId = 2,
                Quantidade = 2,
                ClienteId = 1,
                DataVenda = Convert.ToDateTime("15/09/2018")
            });
            modelBuilder.Entity<Venda>().HasData(new Venda
            {
                Id = 4,
                ProdutoId = 3,
                Quantidade = 1,
                ClienteId = 2,
                DataVenda = Convert.ToDateTime("10/10/2018")
            });
            modelBuilder.Entity<Venda>().HasData(new Venda
            {
                Id = 5,
                ProdutoId = 3,
                Quantidade = 2,
                ClienteId = 1,
                DataVenda = Convert.ToDateTime("10/10/2018")
            });
        }
    }
}
