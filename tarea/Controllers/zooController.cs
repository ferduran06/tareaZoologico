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
        // GET: zoo
        public ActionResult Index()
        {
            List<listZooView> listZoo;

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
        public ActionResult AgregarNuevo(tableZoo model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (bdZooEntities db = new bdZooEntities())      //tabla de BD
                    {
                        tableZoo otable = new tableZoo();            //Tipo clase

                        otable.pais = model.pais;
                        otable.nombre = model.nombre;
                        otable.telefono = model.telefono;
                        otable.sitioWeb = model.sitioWeb;

                        db.zologico.Add(otable);
                        db.SaveChanges();
                    }

                    return RedirectToAction("ZooView");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
