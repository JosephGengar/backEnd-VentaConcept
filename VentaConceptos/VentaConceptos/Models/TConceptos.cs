using System;
using System.Collections.Generic;

namespace VentaConceptos.Models
{
    public partial class TConceptos
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }

        public virtual TVenta IdVentaNavigation { get; set; }
    }
}
