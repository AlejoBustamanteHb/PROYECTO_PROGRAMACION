//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaVentas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

     [Table("ingreso")]
    public partial class ingreso
    {
        public ingreso()
        {
            this.detalle_ingreso = new HashSet<detalle_ingreso>();
        }
    
         [Key]
        public int idingreso { get; set; }
        public int idproveedor { get; set; }
        public string tipo_comprobante { get; set; }
        public string serie_comprobante { get; set; }
        public string num_comprobante { get; set; }
        public System.DateTime fecha_hora { get; set; }
        public decimal impuesto { get; set; }
        public string estado { get; set; }
    
        public virtual ICollection<detalle_ingreso> detalle_ingreso { get; set; }
        public virtual persona persona { get; set; }
    }
}
