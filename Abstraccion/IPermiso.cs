using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface IPermiso : IEntity
    {
        new int Id { get; set; }
        string Nombre { get; set; }
        IList<IPermiso> Hijos { get; }
        void AgregarHijo(IPermiso c);
        void VaciarHijos();
        IList<IPermiso> ObtenerHijos();
        void AgregarPermiso(IPermiso p);
        void QuitarPermiso(IPermiso p);
        bool Permiso { get; set; }
    }
}
