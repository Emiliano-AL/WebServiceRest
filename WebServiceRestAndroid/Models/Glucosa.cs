using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceRestAndroid.Models
{
    public class Glucosa
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public string CantGlucosa { get; set; }
        public string Tiempo { get; set; }
    }
}