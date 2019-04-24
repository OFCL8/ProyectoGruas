using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoGruas.Models
{
    public class Bitacora
    {
        [Key]
        [Required]
        public int Id_Bitacora { get; set; }
        //[Required]
        public int idUser { get; set; }

        [Required(ErrorMessage = "Favor de ingresar una fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Favor de seleccionar una compañia")]
        public string Compañia { get; set; }

        [Required(ErrorMessage = "Favor de ingresar la marca del vehiculo")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Favor de ingresar el tipo de vehiculo")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Favor de ingresar el año del vehiculo")]
        [Range(1935, 2020, ErrorMessage = "Ingrese un año valido")]
        public int Año { get; set; }

        [Required(ErrorMessage = "Favor de ingresar las placas del vehiculo")]
        [StringLength(7, ErrorMessage = "Ingrese una placa valida")]
        public string Placas { get; set; }

        [Required(ErrorMessage = "Favor de ingresar el color del vehiculo")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Favor de ingresar un numero de serie")]
        //[Range(5,5, ErrorMessage = "Numero de serie de tamaño invalido")]
        [RegularExpression(@"[0-9A-Z]{17}", ErrorMessage = "Numero de serie invalido")]
        public string Serie { get; set; }

        

        public string Testigo { get; set; }
        public Nullable<DateTime> FechaContacto { get; set; }
    }
}