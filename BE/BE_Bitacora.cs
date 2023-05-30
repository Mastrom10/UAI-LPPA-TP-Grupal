using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Bitacora
    {
        [PropiedadVerificable]
        public string Email { get; set; }
        
        public DateTime Fecha { get; set; }
        [PropiedadVerificable]
        public string Tipo { get; set; }
        [PropiedadVerificable]
        public string Descripcion { get; set; }
        
        public string DvH { get; set; }
    }
}
