using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceRestAndroid.Models
{
    public class PresionArterial
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public string Sistolica { get; set; }
        public string Diastolica { get; set; }
        public string Brazo { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
    }
}