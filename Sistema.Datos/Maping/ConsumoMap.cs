using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.DataEntidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Maping
{
    public class ConsumoMap : IEntityTypeConfiguration<Consumo>
    {
        public void Configure(EntityTypeBuilder<Consumo> builder)
        {
            builder.ToTable("Consumos", "dbo").HasKey(c => c.Fecha_Consumo);
        }
    }
}
