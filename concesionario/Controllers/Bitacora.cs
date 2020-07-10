using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace concesionario.Controllers
{
    public class Bitacora
    {
       public int id_Bitacora { get; set; }
        public DateTime?  FechaDePago { get; set; }
        public decimal? Abono { get; set; }
        public decimal? PagoMinimo { get; set; }
        public int? IdVentaAuto { get; set; }
        public decimal?  Restante { get; set; }
        public int IdCliente { get; set; }
        public string  Nombre { get; set; }
    }
}