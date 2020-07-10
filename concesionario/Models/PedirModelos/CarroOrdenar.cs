using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace concesionario.Models.PedirModelos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class CarroOrdenar
    {
        public string NombreAval { get; set; }
        public string ApPAval { get; set; }
        public string ApMAval { get; set; }
        public string TelefonoAval { get; set; }
        public int IdSucursal { get; set; }
        public string NombreEnTC { get; set; }
        public string NoTarjetaC { get; set; }
        public int IdMesExpiracion { get; set; }
        public int IdFechaExpiracion { get; set; }
        public string CVV { get; set; }
        public int CPFacturacion { get; set; }
        public int IdTiempoDePago { get; set; }
        //
        public int IdAuto { get; set; }
        public int IdColor { get; set; }
        public int IdPerformance { get; set; }
        public string Nombre { get; set; }
        public string ApP { get; set; }
        public string ApM { get; set; }
        public int Edad { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FechaDeNacimiento { get; set; }
        public int Sexo { get; set; }
        public string RFC { get; set; }
        public string Direccion { get; set; } 
        public int CP { get; set; }
        public string Telefono { get; set; }
        public string TelefonoCasa { get; set; }
        public string Correo { get; set; }
        //
      

    }
}