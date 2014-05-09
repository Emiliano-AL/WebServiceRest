using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceRestAndroid.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public string TipoSangre { get; set; }
        public string Peso { get; set; }
        public string Altura { get; set; }
    }
}