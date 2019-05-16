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
        /*
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
*/
        public ActionResult Index(Bitacora bitacora, [Bind(Include = "Estado")] User usuario, string searching,string opcion)
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
            
            // Despliga todo los datos de la bitacora al admin
            if (cLogin2.idRole == 1)
            {
                if (opcion == "ID Bitacora")
                {
                    try
                    {
                        int Id = Convert.ToInt32(searching);
                        return View(db.Bitacoras.Where(x => x.Id_Bitacora == Id || searching == null).ToList());
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.ToList());
                    }
                }
                else if (opcion == "ID Usuario")
                {
                    try
                    {
                        int Id = Convert.ToInt32(searching);
                        return View(db.Bitacoras.Where(x => x.idUser == Id || searching == null).ToList());
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.ToList());
                    }
                }
                else if (opcion == "Compañia")
                {
                    try
                    {
                        if (String.IsNullOrEmpty((searching)))
                        {
                            return View(db.Bitacoras.ToList());
                        }
                        else
                        {
                            return View(db.Bitacoras.Where(x => x.Compañia==searching).ToList());
                        }
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.ToList());
                    }
                }
                else if (opcion == "Marca")
                {
                    try
                    {
                        if (String.IsNullOrEmpty((searching)))
                        {
                            return View(db.Bitacoras.ToList());
                        }
                        else
                        {
                            //return View(db.Bitacoras.Where(x => x.Compañia == searching).ToList());
                            return View(db.Bitacoras.Where(x => x.Marca== searching ).ToList());
                        }
                        
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.ToList());
                    }
                }
                else if (opcion == "Tipo")
                {
                    try
                    {
                        if (String.IsNullOrEmpty((searching)))
                        {
                            return View(db.Bitacoras.ToList());
                        }
                        else
                        {
                            //return View(db.Bitacoras.Where(x => x.Compañia == searching).ToList());
                            return View(db.Bitacoras.Where(x => x.Tipo== searching ).ToList());
                        }
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.ToList());
                    }
                }
                else if (opcion == "Año")
                {
                    try
                    {
                        int Id = Convert.ToInt32(searching);
                        if (String.IsNullOrEmpty((searching)))
                        {
                            return View(db.Bitacoras.ToList());
                        }
                        else
                        {
                            return View(db.Bitacoras.Where(x => x.Año== Id ).ToList());
                        }
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.ToList());
                    }
                }
                else if (opcion == "Placas")
                {
                    try
                    {
                        if (String.IsNullOrEmpty((searching)))
                        {
                            return View(db.Bitacoras.ToList());
                        }
                        else
                        {
                            return View(db.Bitacoras.Where(x => x.Placas== searching ).ToList());
                        }
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.ToList());
                    }
                }
                else if (opcion == "Color")
                {
                    try
                    {
                        if (String.IsNullOrEmpty((searching)))
                        {
                            return View(db.Bitacoras.ToList());
                        }
                        else
                        {
                            return View(db.Bitacoras.Where(x => x.Color== searching ).ToList());
                        }
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.ToList());
                    }
                }
                else if (opcion == "Serie")
                {
                    try
                    {
                        if (String.IsNullOrEmpty((searching)))
                        {
                            return View(db.Bitacoras.ToList());
                        }
                        else
                        {
                            return View(db.Bitacoras.Where(x => x.Serie== searching ).ToList());
                        }
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.ToList());
                    }
                }
                else if (opcion == "Testigo")
                {
                    try
                    {
                        if (String.IsNullOrEmpty((searching)))
                        {
                            return View(db.Bitacoras.ToList());
                        }
                        else
                        {
                            return View(db.Bitacoras.Where(x => x.Testigo== searching ).ToList());
                        }
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.ToList());
                    }
                }
                else
                {
                    return View(db.Bitacoras.ToList());
                }
            }
            // Despliega los datos de los operadores
            else
            {
                if (opcion == "ID Bitacora")
                {
                    try
                    {
                        int Id = Convert.ToInt32(searching);
                        return View(db.Bitacoras.Where(x => x.Id_Bitacora == Id && x.idUser==cLogin2.idUser || searching == null).ToList());
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                    }
                }
                else if (opcion == "ID Usuario")
                {
                    try
                    {
                        int Id = Convert.ToInt32(searching);
                        return View(db.Bitacoras.Where(x => x.idUser == Id && x.idUser==cLogin2.idUser || searching == null).ToList());
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                    }
                }
                else if (opcion == "Compañia")
                {
                    try
                    {
                        if (String.IsNullOrEmpty((searching)))
                        {
                            return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                        }
                        else
                        {
                            return View(db.Bitacoras.Where(x => x.Compañia==searching && x.idUser==cLogin2.idUser ).ToList());
                        }
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                    }
                }
                else if (opcion == "Marca")
                {
                    try
                    {
                        if (String.IsNullOrEmpty((searching)))
                        {
                            return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                        }
                        else
                        {
                            return View(db.Bitacoras.Where(x => x.Marca== searching && x.idUser==cLogin2.idUser ).ToList());
                        }
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                    }
                }
                else if (opcion == "Tipo")
                {
                    try
                    {
                        if (String.IsNullOrEmpty((searching)))
                        {
                            return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                        }
                        else
                        {
                            //return View(db.Bitacoras.Where(x => x.Compañia == searching).ToList());
                            return View(db.Bitacoras.Where(x => x.Tipo== searching && x.idUser==cLogin2.idUser ).ToList());
                        }
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                    }
                }
                else if (opcion == "Año")
                {
                    try
                    {
                        int Id = Convert.ToInt32(searching);
                        if (String.IsNullOrEmpty((searching)))
                        {
                            return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                        }
                        else
                        {
                            return View(db.Bitacoras.Where(x => x.Año== Id && x.idUser==cLogin2.idUser ).ToList());
                        }
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                    }
                }
                else if (opcion == "Placas")
                {
                    try
                    {
                        if (String.IsNullOrEmpty((searching)))
                        {
                            return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                        }
                        else
                        {
                            return View(db.Bitacoras.Where(x => x.Placas== searching && x.idUser==cLogin2.idUser ).ToList());
                        }
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                    }
                }
                else if (opcion == "Color")
                {
                    try
                    {
                        if (String.IsNullOrEmpty((searching)))
                        {
                            return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                        }
                        else
                        {
                            return View(db.Bitacoras.Where(x => x.Color== searching && x.idUser==cLogin2.idUser ).ToList());
                        }
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                    }
                }
                else if (opcion == "Serie")
                {
                    try
                    {
                        if (String.IsNullOrEmpty((searching)))
                        {
                            return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                        }
                        else
                        {
                            return View(db.Bitacoras.Where(x => x.Serie== searching && x.idUser==cLogin2.idUser ).ToList());
                        }
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                    }
                }
                else if (opcion == "Testigo")
                {
                    try
                    {
                        if (String.IsNullOrEmpty((searching)))
                        {
                            return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                        }
                        else
                        {
                            return View(db.Bitacoras.Where(x => x.Testigo== searching && x.idUser==cLogin2.idUser ).ToList());
                        }
                    }
                    catch (FormatException)
                    {
                        return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                    }
                }
                else
                {
                    //return View(db.Bitacoras.Where(x => x.Compañia.StartsWith(searching) || searching == null).ToList());
                    return View(db.Bitacoras.Where(x => x.idUser == cLogin2.idUser).ToList());
                }
            }
            
            /*
            if (opcion == "ID Bitacora")
            {
                try
                {
                    int Id = Convert.ToInt32(searching);
                    return View(db.Bitacoras.Where(x => x.Id_Bitacora == Id || searching == null).ToList());
                }
                catch (FormatException)
                {
                    return View(db.Bitacoras.ToList());
                }
            }
            else if (opcion == "ID Usuario")
            {
                try
                {
                    int Id = Convert.ToInt32(searching);
                    return View(db.Bitacoras.Where(x => x.idUser == Id || searching == null).ToList());
                }
                catch (FormatException)
                {
                    return View(db.Bitacoras.ToList());
                }
            }
            else if (opcion == "Compañia")
            {
                try
                {
                    if (String.IsNullOrEmpty((searching)))
                    {
                        return View(db.Bitacoras.ToList());
                    }
                    else
                    {
                        return View(db.Bitacoras.Where(x => x.Compañia==searching && x.idUser==cLogin2.idUser ).ToList());
                    }
                }
                catch (FormatException)
                {
                    return View(db.Bitacoras.ToList());
                }
                
                //return View(db.Bitacoras.Where(x => x.Compañia.StartsWith(searching) || searching == null).ToList());
            }
            else if (opcion == "Marca")
            {
                //return View(db.Bitacoras.Where(x => x.Marca.StartsWith(searching) || searching == null).ToList());
                try
                {
                    if (String.IsNullOrEmpty((searching)))
                    {
                        return View(db.Bitacoras.ToList());
                    }
                    else
                    {
                        //return View(db.Bitacoras.Where(x => x.Compañia == searching).ToList());
                        return View(db.Bitacoras.Where(x => x.Marca== searching ).ToList());
                    }
                    //return View(db.Bitacoras.Where(x => x.Compañia.StartsWith(searching) || searching == null).ToList());
                    //return View(db.Bitacoras.Where(x => x.Compañia == searching).ToList());
                }
                catch (FormatException)
                {
                    return View(db.Bitacoras.ToList());
                }
            }
            else if (opcion == "Tipo")
            {
                //return View(db.Bitacoras.Where(x => x.Marca.StartsWith(searching) || searching == null).ToList());
                try
                {
                    if (String.IsNullOrEmpty((searching)))
                    {
                        return View(db.Bitacoras.ToList());
                    }
                    else
                    {
                        //return View(db.Bitacoras.Where(x => x.Compañia == searching).ToList());
                        return View(db.Bitacoras.Where(x => x.Tipo== searching ).ToList());
                    }
                    //return View(db.Bitacoras.Where(x => x.Compañia.StartsWith(searching) || searching == null).ToList());
                    //return View(db.Bitacoras.Where(x => x.Compañia == searching).ToList());
                }
                catch (FormatException)
                {
                    return View(db.Bitacoras.ToList());
                }
            }
            else if (opcion == "Año")
            {
                try
                {
                    int Id = Convert.ToInt32(searching);
                    if (String.IsNullOrEmpty((searching)))
                    {
                        return View(db.Bitacoras.ToList());
                    }
                    else
                    {
                        return View(db.Bitacoras.Where(x => x.Año== Id ).ToList());
                    }
                }
                catch (FormatException)
                {
                    return View(db.Bitacoras.ToList());
                }
            }
            else if (opcion == "Placas")
            {
                try
                {
                    if (String.IsNullOrEmpty((searching)))
                    {
                        return View(db.Bitacoras.ToList());
                    }
                    else
                    {
                        return View(db.Bitacoras.Where(x => x.Placas== searching ).ToList());
                    }
                }
                catch (FormatException)
                {
                    return View(db.Bitacoras.ToList());
                }
            }
            else if (opcion == "Color")
            {
                try
                {
                    if (String.IsNullOrEmpty((searching)))
                    {
                        return View(db.Bitacoras.ToList());
                    }
                    else
                    {
                        return View(db.Bitacoras.Where(x => x.Color== searching ).ToList());
                    }
                }
                catch (FormatException)
                {
                    return View(db.Bitacoras.ToList());
                }
            }
            else if (opcion == "Serie")
            {
                try
                {
                    if (String.IsNullOrEmpty((searching)))
                    {
                        return View(db.Bitacoras.ToList());
                    }
                    else
                    {
                        return View(db.Bitacoras.Where(x => x.Serie== searching ).ToList());
                    }
                }
                catch (FormatException)
                {
                    return View(db.Bitacoras.ToList());
                }
            }
            else if (opcion == "Testigo")
            {
                try
                {
                    if (String.IsNullOrEmpty((searching)))
                    {
                        return View(db.Bitacoras.ToList());
                    }
                    else
                    {
                        return View(db.Bitacoras.Where(x => x.Testigo== searching ).ToList());
                    }
                }
                catch (FormatException)
                {
                    return View(db.Bitacoras.ToList());
                }
            }
            else
            {
                //return View(db.Bitacoras.Where(x => x.Compañia.StartsWith(searching) || searching == null).ToList());
                return View(db.Bitacoras.ToList());
            }*/

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
                db.Bitacoras.Add(bitacora);
                db.SaveChanges();
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