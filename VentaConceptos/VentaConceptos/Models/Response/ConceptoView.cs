using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentaConceptos.Models.Response
{
    public class ConceptoView
    {
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public int Cantidad { get; set; }
    }
}
