using System;
using System.Collections.Generic;

namespace VentaConceptos.Models
{
    public partial class TVenta
    {
        public TVenta()
        {
            TConceptos = new HashSet<TConceptos>();
        }

        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public virtual ICollection<TConceptos> TConceptos { get; set; }
    }
}
