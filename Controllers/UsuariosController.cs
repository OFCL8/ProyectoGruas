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
    public class UsuariosController : Controller
    {
        private GruasContext db = new GruasContext();
        // GET: Usuarios
        public ActionResult Index()
        {
            if (Session["cLogin"] == null)
            {
                return RedirectToAction("Login", "Users");

            }
            else
            {
                CurrentLogin cLogin = (CurrentLogin)Session["cLogin"];
                if (cLogin.idRole != 1)
                {
                    return RedirectToAction("Index", "Operador");
                }

            }
            return View(db.Users.ToList());
        }


        public ActionResult Create2()
        {
            if (Session["cLogin"] == null)
            {
                return RedirectToAction("Login", "Users");

            }
            else
            {
                CurrentLogin cLogin = (CurrentLogin)Session["cLogin"];
                if (cLogin.idRole != 1)
                {
                    return RedirectToAction("Index", "Operador");
                }

            }
            //ViewBag.idRole = new SelectList(db.Roles, "idRole", "Description");
            return View();
            //return RedirectToAction("Index2");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2([Bind(Include = "idUser,UserName,Password,idRole,Role,Nombre,Apellidos,NumeroCelular,Estado")] User usuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(usuario);
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                }
                //ViewBag.idRole = new SelectList(db.Roles, "idRole", "Description", user.idRole);
                //return View(usuario);
                return RedirectToAction("Index");
            }
            catch
            {
                //return RedirectToAction("ErrorUserName");
                TempData["msg"] = "<script>alert('El username ingresado ya existe actualmente');</script>";
                return RedirectToAction("Create2");
            }
            
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
                if (cLogin.idRole != 1)
                {
                    return RedirectToAction("Index", "Operador");
                }

            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUser,UserName,Password,idRole,Role,Nombre,Apellidos,NumeroCelular,Estado")] User usuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch
            {
                //return RedirectToAction("ErrorUserName");
                TempData["msg"] = "<script>alert('El username ingresado ya existe actualmente');</script>";
                return RedirectToAction("Index");
            }
           
        }
        //Eliminar
        public ActionResult Delete(int? id)
        {
            if (Session["cLogin"] == null)
            {
                return RedirectToAction("Login", "Users");

            }
            else
            {
                CurrentLogin cLogin = (CurrentLogin)Session["cLogin"];
                if (cLogin.idRole != 1)
                {
                    return RedirectToAction("Index", "Operador");
                }

            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User usuario = db.Users.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            User usuario = db.Users.Find(id);
            db.Users.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}