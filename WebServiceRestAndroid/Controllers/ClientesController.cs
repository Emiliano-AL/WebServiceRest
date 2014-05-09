using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServiceRestAndroid.Models;

namespace WebServiceRestAndroid.Controllers
{
    public class ClientesController : Controller
    {
        private ClienteManager clientesManager;
        private PacientesManager pacientesManager;

        public ClientesController()
        {
            clientesManager = new ClienteManager();
            pacientesManager = new PacientesManager();
        }

        // GET /Clientes
        [HttpGet]
        public JsonResult Clientes()
        {
            return Json(clientesManager.RetrieveAllClientes(),
                        JsonRequestBehavior.AllowGet);
        }

        // POST    /Clientes/Cliente    { Nombre:"nombre", Telefono:123456789 }
        // PUT     /Clientes/Cliente/3  { Id:3, Nombre:"nombre", Telefono:123456789 }
        // GET     /Clientes/Cliente/3
        // DELETE  /Clientes/Cliente/3
        public JsonResult Cliente(int? id, Cliente item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(clientesManager.InsertCliente(item));
                case "PUT":
                    return Json(clientesManager.UpdateCliente(item));
                case "GET":
                    return Json(clientesManager.GetCliente(id.GetValueOrDefault()),
                                JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(clientesManager.DeleteCliente(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }

        public JsonResult Paciente(int? id, Paciente item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(pacientesManager.InsertPaciente(item));
                case "PUT":
                    return Json(new { Error = false, Message = "Hay que implementar" });
                case "GET":
                    return Json(new { Error = false, Message = "Hay que implementar" });
                case "DELETE":
                    return Json(new { Error = false, Message = "Hay que implementar" });
            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }

    }
}
