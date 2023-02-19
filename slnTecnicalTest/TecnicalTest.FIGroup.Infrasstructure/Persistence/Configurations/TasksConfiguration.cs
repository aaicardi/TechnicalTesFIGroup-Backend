using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TecnicalTest.FIGroup.Domain.Entities;

namespace TecnicalTest.FIGroup.Infrastructure.Persistence.Configurations;

internal sealed class TasksConfiguration : IEntityTypeConfiguration<Tasks>
{
    public void Configure(EntityTypeBuilder<Tasks> builder)
    {
        builder.ToTable("FM_PARAMETROS", "dbo");
        builder.Property(v => v.Id).HasColumnName("PK_CodigoParametro");
        //    builder.Property(v => v.UniqueName).HasColumnName("NombreUnico");
        //    builder.Property(v => v.Description).HasColumnName("Descripcion");
        //    builder.Property(v => v.Value).HasColumnName("Valor");
        //    builder.Property(v => v.GroupParameter).HasColumnName("GrupoParametro");
        //    builder.HasKey(v => v.Id);
        //}

    }
}

