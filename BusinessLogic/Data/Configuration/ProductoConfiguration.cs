using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Stock).IsRequired();
            builder.Property(p => p.Precio).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.Imagen).HasMaxLength(1000);
            builder.HasOne(m => m.Marca).WithMany().HasForeignKey(p => p.MarcaId);
            builder.HasOne(m => m.Categoria).WithMany().HasForeignKey(p => p.CategoriaId);
        }
    }
}
