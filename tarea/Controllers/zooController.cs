using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using tarea.Models;
using tarea.Models.viewModels;

namespace tarea.Controllers
{
    public class zooController : Controller
    {
        List<listZooView> listZoo;

        // GET: zoo
        public ActionResult Index()
        {
        
            using (bdZooEntities db = new bdZooEntities())
            {
                listZoo = (from d in db.zologico
                           select new listZooView
                           {
                               id = d.id,
                               pais = d.pais,
                               nombre = d.nombre,
                               telefono = (int)d.telefono,
                               sitioWeb = d.sitioWeb
                           }).ToList();
            }

            return View("ZooView", listZoo);
        }

        public ActionResult crearNuevo()
        {
            return View("crearNuevo");
        }



        [HttpPost]
        public ActionResult AgregarNuevo(zologico model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (bdZooEntities db = new bdZooEntities())      //tabla de BD
                    {
                        var otable = new zologico();            //Tipo clase

                        otable.id = (int)model.id;
                        otable.pais = model.pais;
                        otable.nombre = model.nombre;
                        otable.telefono = model.telefono;
                        otable.sitioWeb = model.sitioWeb;

                        db.zologico.Add(otable);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View("ZooView", listZoo);
        }
    }
}
