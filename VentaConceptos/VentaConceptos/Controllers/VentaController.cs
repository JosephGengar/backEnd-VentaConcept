using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VentaConceptos.Models.Response;
using VentaConceptos.Models;

namespace VentaConceptos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {   
        [HttpPost]
        public IActionResult Agregar(VentaView model)
        {
            ResponseView oResp = new ResponseView();
            try
            {
                using (SimpleVentaContext db = new SimpleVentaContext())
                {
                    using (var transicion = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var oVenta = new TVenta();
                            oVenta.NombreCliente = model.NombreCliente;
                            oVenta.Fecha = DateTime.Now;
                            oVenta.Total = model.Conceptos.Sum(d => d.Cantidad * d.PrecioUnitario);
                            db.TVenta.Add(oVenta);
                            db.SaveChanges();

                            foreach (var item in model.Conceptos)
                            {
                                var oConcept = new TConceptos();
                                oConcept.Cantidad = item.Cantidad;
                                oConcept.PrecioUnitario = item.PrecioUnitario;
                                oConcept.Importe = item.Cantidad * item.PrecioUnitario;
                                oConcept.IdVenta = oVenta.Id;
                                db.TConceptos.Add(oConcept);
                                db.SaveChanges();
                            }

                            transicion.Commit();
                            oResp.Exito = 1;
                            oResp.Mensajes = "Exito";
                        }
                        catch (Exception ex)
                        {
                            transicion.Rollback();
                            oResp.Mensajes = ex.Message;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oResp.Mensajes = ex.Message;
                oResp.Exito = 0;
            }          
            return Ok(oResp);
        }
    }
}
