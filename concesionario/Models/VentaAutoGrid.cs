using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace concesionario.Models
{
    public class VentaAutoGrid
    {
        
       public int IdVentaAuto { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string TelefonoCasa { get; set; }
        public string Correo { get; set; }
        public string Carro { get; set; }
        public int? Anio { get; set; }
    }
}