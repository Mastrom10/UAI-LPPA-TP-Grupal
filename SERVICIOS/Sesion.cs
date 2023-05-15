using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using BE;

namespace SERVICIOS
{
    public class Sesion
    {
        public static BE_Usuario _user;
        //public static IList<IIdiomaObserver> _observers = new List<IIdiomaObserver>();


        public static IUsuario Usuario
        {
            get
            {
                return _user;
            }
        }
        #region Singleton
        public static bool IsLogged()
        {
            return _user != null;
        }
        public static void Login(BE_Usuario oUsuario)
        {
            _user = oUsuario;
        }
        public static void Logout()
        {
            _user = null;
        }
        #endregion

        #region Composite
        private static bool IsInRoleRecursivo(IPermiso p, string tipoPermiso, bool valid)
        {

            foreach (var item in p.ObtenerHijos())
            {
                if (item.Nombre == tipoPermiso)
                {
                    valid = true;
                }
                else
                {
                    valid = IsInRoleRecursivo(item, tipoPermiso, valid);
                }
            }
            return valid;
        }


        public static bool IsInRole(string tipoPermiso)
        {
            if (_user == null) return false;

            bool valid = false;
            foreach (var p in _user.Permisos)
            {
                if (p.Nombre == tipoPermiso)
                {
                    valid = true;
                }
                else
                {
                    valid = IsInRoleRecursivo(p, tipoPermiso, valid);
                }
            }

            return valid;
        }
        #endregion

    }
}
