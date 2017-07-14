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

     [Table("persona")]
    public partial class persona
    {
        public persona()
        {
            this.ingreso = new HashSet<ingreso>();
            this.venta = new HashSet<venta>();
        }
        [Key]
        public int idpersona { get; set; }
        public string tipo_persona { get; set; }
        public string nombre { get; set; }
        public string tipo_documento { get; set; }
        public string num_documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
    
        public virtual ICollection<ingreso> ingreso { get; set; }
        public virtual ICollection<venta> venta { get; set; }
    }
}
