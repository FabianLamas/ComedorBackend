using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.DataEntidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Maping
{
    public class CentroCostoMap : IEntityTypeConfiguration<CentroCosto>
    {
        public void Configure(EntityTypeBuilder<CentroCosto> builder)
        {
            builder.ToTable("CentroDeCosto", "dbo").HasKey(c => c.Id);
        }
    }
}
