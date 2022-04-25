using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SegWallApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SegWallApi.DAL.Context
{
    public class SegWallContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("Default");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apolice>()
                .HasOne(b => b.Usuario)
                .WithMany(ba => ba.Apolices)
                .HasForeignKey(bi => bi.IdUsuario);

            modelBuilder.Entity<Apolice>()
               .HasOne(b => b.Seguro)
               .WithMany(ba => ba.Apolices)
               .HasForeignKey(bi => bi.IdSeguro);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Seguro> Seguro { get; set; }
        public DbSet<Apolice> Apolice { get; set; }
    }
}
