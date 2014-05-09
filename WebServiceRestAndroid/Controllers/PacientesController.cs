using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServiceRestAndroid.Models;

namespace WebServiceRestAndroid.Controllers
{
    public class PacientesController : Controller
    {
        private PacientesManager pacientesManager;

        public PacientesController()
        {
            pacientesManager = new PacientesManager();
        }

        // POST    /Pacientes/Paciente    { objeto }
        public JsonResult Add(Paciente item)
        {
            if (Request.HttpMethod == "POST")
                return Json(pacientesManager.InsertPaciente(item));
            else
                return Json(new { Error = true, Message = "Operación HTTP invalida" });
        }

    }
}
