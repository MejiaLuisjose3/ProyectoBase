using Entity.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySql.Controllers.Factura
{
    public class FacturaController : Controller
    {
        public ActionResult Factura()
        {
            ViewBag.titulo = "Bien";
            return View();
        }

        public JsonResult Agregar(TFacturaDetalle facturaDetalle)
        {

            return Json("hola");
        }

        public JsonResult EmployeeData()
        {
            var emp = "";
            return Json(emp, JsonRequestBehavior.AllowGet);
        }
    }
}