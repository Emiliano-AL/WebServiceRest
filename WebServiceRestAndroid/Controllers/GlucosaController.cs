using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServiceRestAndroid.Models;

namespace WebServiceRestAndroid.Controllers
{
    public class GlucosaController : Controller
    {
        private GlucosaManager glucosaManager;

        public GlucosaController()
        {
            glucosaManager = new GlucosaManager();
        }

        // POST    /Glucosa/Paciente    { objeto }
        public JsonResult Add(Glucosa item)
        {
            if (Request.HttpMethod == "POST")
                return Json(glucosaManager.InsertGlucosa(item));
            else
                return Json(new { Error = true, Message = "Operación HTTP invalida" });
        }

    }
}
