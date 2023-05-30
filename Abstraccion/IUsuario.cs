using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface IUsuario
    {
        string Email { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        DateTime FechaNacimiento { get; set; }
        int Provincia { get; set; }
        bool Estado { get; set; }
        string Contrasena { get; set; }
        string Telefono { get; set; }
        string Direccion { get; set; }
        string DvH { get; set; }
        IList<IPermiso> Permisos { get; }
    }
}
