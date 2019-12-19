using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.DataEntidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Maping
{
    public class HistPerso1Map : IEntityTypeConfiguration<HistPerso1>
    {
        public void Configure(EntityTypeBuilder<HistPerso1> builder)
        {
            builder.ToTable("HistPerso1", "dbo").HasKey(h => h.ZAUSW);
        }
    }
}
