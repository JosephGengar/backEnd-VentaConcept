using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentaConceptos.Models.Response
{
    public class ResponseView
    {
        public int Exito { get; set; }
        public object Data { get; set; }
        public string Mensajes { get; set; }
    }
}
