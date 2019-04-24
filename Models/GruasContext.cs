using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace ProyectoGruas.Models
{
    public class GruasContext : DbContext
    {
        public GruasContext()
            : base("name=BitacoraContext")
        {
        }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }*/

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Bitacora> Bitacoras { get; set; }
    }
}