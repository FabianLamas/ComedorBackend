using Microsoft.EntityFrameworkCore;
using Sistema.Datos.Maping;
using Sistema.Entidades.DataEntidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos
{
    public class DbContextSistema : DbContext
    {
        public DbSet<Consumo> Consumos { get; set; }
        public DbSet<ConsumoHist> ConsumosHists { get; set; }
        public DbSet<HistPerso1> HistPerso1s { get; set; }

        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ConsumoHistMap());
            modelBuilder.ApplyConfiguration(new ConsumoMap());
            modelBuilder.ApplyConfiguration(new HistPerso1Map());
        }
    }
}
