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
        //Creación de la lista
        List<listZooView> listZoo;

        // GET: zoo


        // El metodo Index, muestra la información almacenada en la base de datos
        // devuelve una vista con lista con todos los datos de tipo zologico 

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


        // Método que nuestra una nueva vista
        public ActionResult crearNuevo()
        {
            return View("crearNuevo");
        }


        // Método que agrega los datos del zoologico a la base de datos, recibe
        // por parámetro modelo de tipo zoologico, y devuelve un direccionamiento 
       
        [HttpPost]
        public ActionResult AgregarNuevo(zologico model)
        {
            try
            {
                if (ModelState.IsValid)         //Valida si el modelo 
                {
                    using (bdZooEntities db = new bdZooEntities())      //Conexión con la BD
                    {
                        var otable = new zologico();                    //Tipo clase

                        otable.id = (int)model.id;
                        otable.pais = model.pais;
                        otable.nombre = model.nombre;
                        otable.telefono = model.telefono;
                        otable.sitioWeb = model.sitioWeb;

                        db.zologico.Add(otable);
                        db.SaveChanges();                               //Agrega los datos a la BD
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
