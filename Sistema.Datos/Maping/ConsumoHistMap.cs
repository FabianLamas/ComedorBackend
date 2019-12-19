using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.DataEntidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Maping
{
    public class ConsumoHistMap : IEntityTypeConfiguration<ConsumoHist>
    {
        public void Configure(EntityTypeBuilder<ConsumoHist> builder)
        {
            builder.ToTable("ConsumosHist", "dbo").HasKey(c => c.Id);
        }
    }
}
