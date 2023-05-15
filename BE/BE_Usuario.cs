using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;

namespace BE
{
    public class BE_Usuario : IUsuario
    {
        [PropiedadVerificable]
        public string Email { get; set; }
        [PropiedadVerificable]
        public string Nombre { get; set; }
        [PropiedadVerificable]
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Provincia { get; set; }
        public bool Estado { get; set; }
        public string Contrasena { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string DvH { get; set; }
        public IList<IPermiso> _permisos;
        public BE_Usuario()
        {
            _permisos = new List<IPermiso>();
        }
        public IList<IPermiso> Permisos
        {
            get
            {
                return _permisos;
            }

        }
    }
}
