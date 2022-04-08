using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentaConceptos.Models.Response
{
    public class VentaView
    {
        public string NombreCliente { get; set; }

        public List<ConceptoView> Conceptos { get; set; }
    }
}
