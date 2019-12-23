using Microsoft.EntityFrameworkCore;
using Sistema.Datos.Maping;
using Sistema.Entidades.DataEntidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos
{
    public class DbContextAccesos : DbContext
    {
        public DbSet<CentroCosto> CentroCostos { get; set; }

        public DbContextAccesos(DbContextOptions<DbContextAccesos> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CentroCostoMap());
        }
    }
}
