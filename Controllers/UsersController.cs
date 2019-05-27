using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoGruas.Models;

namespace ProyectoGruas.Controllers
{
    public class UsersController : Controller
    {
        private GruasContext db = new GruasContext();
        // GET: User
        public ActionResult Index()
        {
            //return View();
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
            return View();
        }

        public ActionResult SearchUser(string username, string password)
        {
            var user = db.Users.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
            if (user != null)
            {
                CurrentLogin cLogin = new CurrentLogin();
                cLogin.idUser = user.idUser;
                cLogin.UserName = user.UserName;
                cLogin.idRole = user.idRole.GetValueOrDefault();

                System.Web.HttpContext.Current.Session["cLogin"] = cLogin;
                CurrentLogin cLg = (CurrentLogin)Session["cLogin"];
                return RedirectToAction("Disponibilidad", "Operador");
            }
            else
            {
                TempData["msg"] = "<script>alert('Nombre de usuario y/o contraseña incorrectos');</script>";
                return RedirectToAction("Login", "Users");
            }

        }
        public ActionResult Login()
        {
            return View(db.Users.ToList());
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Users");
        }
        
    }
}