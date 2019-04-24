using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoGruas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["cLogin"] == null)
            {
                //return RedirectToAction("Login", "Users");
                return RedirectToAction("Login", "Users");

            }
            else
            {
                CurrentLogin cLogin = (CurrentLogin)Session["cLogin"];
                if (cLogin.idRole != 1 && cLogin.idRole != 2)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}