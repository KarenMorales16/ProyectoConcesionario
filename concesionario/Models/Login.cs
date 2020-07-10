using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace concesionario.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Ingresa Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Ingresa Contraseña")]
        [DataType(DataType.Password)]
        public string Contra { get; set; }
    }
}