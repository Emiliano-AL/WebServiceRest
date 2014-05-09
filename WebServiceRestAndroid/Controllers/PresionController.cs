using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServiceRestAndroid.Models;

namespace WebServiceRestAndroid.Controllers
{
    public class PresionController : Controller
    {
        private PresionArterialManager presionArterialManager;

       public PresionController()
        {
            presionArterialManager = new PresionArterialManager();
        }

       // POST    /Presion/Add    { objeto }
       public JsonResult Add(PresionArterial item)
       {
           if (Request.HttpMethod == "POST")
               return Json(presionArterialManager.InsertPresion(item));
           else
               return Json(new { Error = true, Message = "Operación HTTP invalida" });
       }

       public JsonResult Get(int? id)
       {
           if (Request.HttpMethod == "GET")
               return Json(presionArterialManager.GetHistorial(id.GetValueOrDefault()), JsonRequestBehavior.AllowGet);
           else
               return Json(new { Error = true, Message = "Operación HTTP invalida" });
       }

    }
}
