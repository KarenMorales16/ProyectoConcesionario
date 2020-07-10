using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace concesionario.Models
{
    public class Traspaso
    {
        public int? IdModelo { get; set; }
        public int? IdAnio { get; set; }
        public int? Cantidad { get; set; }
        public int? IdSucursal { get; set; }
        public int? IdSucursalD { get; set; }
    }
}