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

        public ClientesController()
        {
            clientesManager = new ClienteManager();
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

    }
}
