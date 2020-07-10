using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace concesionario.Models
{
    public class AutosConsecionario
    {
        public int IdAuto { get; set; }
        public string Marca { get; set; }
        public int? IdColor { get; set; }
        public int? IdModelo { get; set; }
        public int? IdAnio { get; set; }
        public decimal? Precio { get; set; }
        public string Modelo { get; set; }
        public int? Anio { get; set; }
    }
}