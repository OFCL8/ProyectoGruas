using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoGruas.Models;

namespace ProyectoGruas.ViewModels
{
    public class IndexViewModel
    {
        public List<User> Use { get; set; }
        public List<Bitacora> Bitacor { get; set; }
    }
}