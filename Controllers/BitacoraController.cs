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
    public class BitacoraController : Controller
    {
        private GruasContext db = new GruasContext();

        // GET: Bitacora
        public ActionResult Index(Bitacora bitacora, [Bind(Include = "Estado")] User usuario)
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
            User usuarioss = db.Users.Find(cLogin2.idUser);
            if (usuarioss == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Entry(usuarioss).State = EntityState.Modified;
                usuarioss.Estado = "Disponible";
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            
            //Despliga todo los datos de la bitacora al admin
            if (cLogin2.idRole == 1)
            {
                return View(db.Bitacoras.ToList());
            }
            else
            {
                //Despliega todos los datos del usuario correspondiente
                List<Bitacora> StuList = new List<Bitacora>();
                StuList = db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList();
                return View(StuList);
            }

            //return View();

        }
        public ActionResult Create([Bind(Include = "Estado")] User usuario)
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
            User usuarioss = db.Users.Find(cLogin2.idUser);
            if (usuarioss == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Entry(usuarioss).State = EntityState.Modified;
                usuarioss.Estado = "En Servicio";
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Bitacora,idUser,Fecha,Compañia,Marca,Tipo,Año,Placas,Color,Serie,FechaContacto,Testigo")] Bitacora bitacora)
        {
            if (ModelState.IsValid)
            {
                CurrentLogin cLogin = (CurrentLogin)Session["cLogin"];
                //cLogin.idUser = bitacora.idUser;
                bitacora.Fecha = DateTime.Now;
                bitacora.idUser = cLogin.idUser;

                /*db.Entry(usuario).State = EntityState.Modified;
                usuario.isActive = false;*/
                
                db.Bitacoras.Add(bitacora);
                db.SaveChanges();
                /*
                User usuarioss = db.Users.Find(cLogin.idUser);
                if (usuarioss == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    db.Entry(usuarioss).State = EntityState.Modified;
                    usuarioss.isActive = false;
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                }*/

                return RedirectToAction("Index");
            }

            return View(bitacora);
        }

        //Filtro en la tabla
        public JsonResult GetSearchingData(string SearchBy, string SearchValue)
        {
            List<Bitacora> ListBtac = new List<Bitacora>();
            if (SearchBy == "ID Bitacora")
            {
                try
                {
                    int Id = Convert.ToInt32(SearchValue);
                    ListBtac = db.Bitacoras.Where(x => x.Id_Bitacora == Id || SearchValue == null).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} No se encontro el ID ", SearchValue);
                }
                return Json(ListBtac, JsonRequestBehavior.AllowGet);
            }
            else if (SearchBy == "ID Usuario")
            {
                try
                {
                    int Id = Convert.ToInt32(SearchValue);
                    ListBtac = db.Bitacoras.Where(x => x.idUser == Id || SearchValue == null).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} No se encontro ID ", SearchValue);
                }
                return Json(ListBtac, JsonRequestBehavior.AllowGet);
            }
            else if (SearchBy == "Compañia")
            {
                ListBtac = db.Bitacoras.Where(x => x.Compañia.StartsWith(SearchValue) || SearchValue == null).ToList();
                return Json(ListBtac, JsonRequestBehavior.AllowGet);
            }
            else if (SearchBy == "Marca")
            {
                ListBtac = db.Bitacoras.Where(x => x.Marca.StartsWith(SearchValue) || SearchValue == null).ToList();
                return Json(ListBtac, JsonRequestBehavior.AllowGet);
            }
            else if (SearchBy == "Tipo")
            {
                ListBtac = db.Bitacoras.Where(x => x.Tipo.StartsWith(SearchValue) || SearchValue == null).ToList();
                return Json(ListBtac, JsonRequestBehavior.AllowGet);
            }
            else if (SearchBy == "Año")
            {
                try
                {
                    int year = Convert.ToInt32(SearchValue);
                    ListBtac = db.Bitacoras.Where(x => x.Año == year || SearchValue == null).ToList();
                    return Json(ListBtac, JsonRequestBehavior.AllowGet);
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} No se el año ", SearchValue);
                }
                return Json(ListBtac, JsonRequestBehavior.AllowGet);
            }
            else if (SearchBy == "Placas")
            {
                ListBtac = db.Bitacoras.Where(x => x.Placas.StartsWith(SearchValue) || SearchValue == null).ToList();
                return Json(ListBtac, JsonRequestBehavior.AllowGet);
            }
            else if (SearchBy == "Color")
            {
                ListBtac = db.Bitacoras.Where(x => x.Color.StartsWith(SearchValue) || SearchValue == null).ToList();
                return Json(ListBtac, JsonRequestBehavior.AllowGet);
            }
            else if (SearchBy == "Serie")
            {
                ListBtac = db.Bitacoras.Where(x => x.Serie.StartsWith(SearchValue) || SearchValue == null).ToList();
                return Json(ListBtac, JsonRequestBehavior.AllowGet);
            }
            else if (SearchBy == "Testigo")
            {
                ListBtac = db.Bitacoras.Where(x => x.Testigo.StartsWith(SearchValue) || SearchValue == null).ToList();
                return Json(ListBtac, JsonRequestBehavior.AllowGet);
            }
            else if (SearchBy == "Todos")
            {
                ListBtac = db.Bitacoras.ToList();
                return Json(ListBtac, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ListBtac = db.Bitacoras.ToList();
                return Json(ListBtac, JsonRequestBehavior.AllowGet);
            }
        }

        //Editar
        public ActionResult Edit(int? id)
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

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitacora bitac = db.Bitacoras.Find(id);
            if (bitac == null)
            {
                return HttpNotFound();
            }
            return View(bitac);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Bitacora,idUser,Fecha,Compañia,Marca,Tipo,Año,Placas,Color,Serie,FechaContacto,Testigo")] Bitacora bitacora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bitacora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bitacora);
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
                if (cLogin.idRole != 1 && cLogin.idRole != 2)
                {
                    return RedirectToAction("Index", "Bitacora");
                }

            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitacora bitac = db.Bitacoras.Find(id);
            if (bitac == null)
            {
                return HttpNotFound();
            }
            return View(bitac);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Bitacora bitacora = db.Bitacoras.Find(id);
            db.Bitacoras.Remove(bitacora);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //PDF

    }
}