using ProyectoGruas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProyectoGruas.Controllers
{
    public class OperadorController : Controller
    {
        private GruasContext db = new GruasContext();
        // GET: Operador
        public ActionResult Index(int? id)
        {
            if (Session["cLogin"] == null)
            {
                return RedirectToAction("Login", "Users");

            }
            else
            {
                CurrentLogin cLogin = (CurrentLogin)Session["cLogin"];
                if (cLogin.idRole != 1 && cLogin.idRole != 2)
                {
                    return RedirectToAction("Index", "Bitacora");
                }
            }


            CurrentLogin cLogin2 = (CurrentLogin)Session["cLogin"];
            //cLogin.idUser = bitacora.idUser;

            User usuarioss = db.Users.Find(cLogin2.idUser);
            ViewBag.Nombre = usuarioss.Nombre + " " + usuarioss.Apellidos;
            if (usuarioss == null)
            {
                return HttpNotFound();
            }
            return View(usuarioss);

        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "idUser,UserName,Password,idRole,Role,Nombre,Apellidos,NumeroCelular,Estado")] User usuario)
        {

            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "<script>alert('Estado actualizado');</script>";
                return RedirectToAction("Index");
            }
            return View(usuario);

        }

        public ActionResult Edit(int? id)
        {
            if (Session["cLogin"] == null)
            {
                return RedirectToAction("Login", "Users");

            }
            else
            {
                CurrentLogin cLogin = (CurrentLogin)Session["cLogin"];
                if (cLogin.idRole == 2)
                {
                    return RedirectToAction("Index", "Operador");
                }

            }
            //Bitacora bitac = db.Bitacoras.Find(id);
            CurrentLogin cLogin2 = (CurrentLogin)Session["cLogin"];
            //cLogin.idUser = bitacora.idUser;

            User usuarioss = db.Users.Find(cLogin2.idUser);
            if (usuarioss == null)
            {
                return HttpNotFound();
            }
            return View(usuarioss);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUser,UserName,Password,idRole,Role,Nombre,Apellidos,NumeroCelular,Estado")] User usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public ActionResult Disponibilidad()
        {
            if (Session["cLogin"] == null)
            {
                return RedirectToAction("Login", "Users");

            }
            else
            {
                CurrentLogin cLogin = (CurrentLogin)Session["cLogin"];
                if (cLogin.idRole == 2)
                {
                    return RedirectToAction("Index", "Operador");
                }

            }
            List<User> ListUser = new List<User>();
            CurrentLogin cLogin2 = (CurrentLogin)Session["cLogin"];
            ListUser = db.Users.Where(x => x.idRole == 2).ToList();
            Response.AddHeader("Refresh", "15");//Refresh pagina cada 15seg.
            return View(ListUser);
        }
    }
}

