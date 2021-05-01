using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLogic.Data.Conexion
{
    public class ZafamiDbContextData
    {
        public static async Task LoadDataAsync(ZafamiDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Marca.Any())
                {
                    var marcaData = File.ReadAllText("../BusinessLogic/LoadData/marca.json");
                    var marcas = JsonSerializer.Deserialize<List<Marca>>(marcaData);

                    foreach(var marca in marcas)
                    {
                        context.Marca.Add(marca);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Categoria.Any())
                {
                    var categoriaData = File.ReadAllText("../BusinessLogic/LoadData/categoria.json");
                    var categorias = JsonSerializer.Deserialize<List<Categoria>>(categoriaData);

                    foreach (var categoria in categorias)
                    {
                        context.Categoria.Add(categoria);
                    }

                    await context.SaveChangesAsync();
                }


                if (!context.Producto.Any())
                {
                    var productoData = File.ReadAllText("../BusinessLogic/LoadData/producto.json");
                    var productos = JsonSerializer.Deserialize<List<Producto>>(productoData);

                    foreach (var producto in productos)
                    {
                        context.Producto.Add(producto);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch(Exception e)
            {
                var logger = loggerFactory.CreateLogger<ZafamiDbContextData>();
                logger.LogError(e.Message);
            }
        }
    }
}
