using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoGruas.Models
{
    public class User
    {
        [Key]
        [Required]
        public int idUser { get; set; }

        [Required(ErrorMessage = "Favor de ingresar el username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Favor de ingresar una contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Favor de seleccionar un rol")]
        public Nullable<int> idRole { get; set; }

        public virtual Role Role { get; set; }

        [Required(ErrorMessage = "Favor de ingresar el nombre")]
        [Display(Name = "Nombre")]
        [StringLength(maximumLength: 50, MinimumLength =1, ErrorMessage = "Nombre no puede ser mayor a 50 caracteres")]
        [RegularExpression("^[a-zA-ZÀ-ÿ\u00f1\u00d1 ]+([a - zA - ZÀ - ÿ\u00f1\u00d1 ]*)*", ErrorMessage ="Favor de ingresar solamente letras")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Favor de ingresar los apellidos")]
        [Display(Name = "Apellidos")]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "Los apellidos no pueden ser mayor a 100 caracteres")]
        [RegularExpression("^[a-zA-ZÀ-ÿ\u00f1\u00d1 ]+([a - zA - ZÀ - ÿ\u00f1\u00d1 ]*)*", ErrorMessage = "Favor de ingresar solamente letras")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Favor de ingresar un numero celular")]
        [Display(Name = "NumeroCelular")]
        [RegularExpression("^[0-9]{1,10}$", ErrorMessage = "Favor de ingresar solamente numeros o no mayor a 10 numeros")]
        public long NumeroCelular { get; set; }

        [Required(ErrorMessage = "Favor de seleccionar un estado")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}