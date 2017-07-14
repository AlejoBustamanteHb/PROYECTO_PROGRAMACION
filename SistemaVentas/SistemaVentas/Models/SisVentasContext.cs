using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models
{
    public class SisVentasContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SisVentasContext() : base("name=SisVentasContext")
        {
        }

        public System.Data.Entity.DbSet<SistemaVentas.Models.categoria> categorias { get; set; }

        public System.Data.Entity.DbSet<SistemaVentas.Models.articulo> articuloes { get; set; }

        public System.Data.Entity.DbSet<SistemaVentas.Models.detalle_ingreso> detalle_ingreso { get; set; }

        public System.Data.Entity.DbSet<SistemaVentas.Models.ingreso> ingresoes { get; set; }

        public System.Data.Entity.DbSet<SistemaVentas.Models.detalle_venta> detalle_venta { get; set; }

        public System.Data.Entity.DbSet<SistemaVentas.Models.venta> ventas { get; set; }

        public System.Data.Entity.DbSet<SistemaVentas.Models.persona> personas { get; set; }
    
    }
}
