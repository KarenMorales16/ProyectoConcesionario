using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace concesionario.Models
{
    public class AltaAuto
    {
        public string Marca { get; set; }
        public int IdColor { get; set; }
        public string Modelo { get; set; }
        public int IdAnio { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int IdSucursal { get; set; }
    }
}