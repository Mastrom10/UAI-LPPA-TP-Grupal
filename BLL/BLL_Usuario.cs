using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using SERVICIOS;
using static System.Collections.Specialized.BitVector32;

namespace BLL
{
    public class BLL_Usuario
    {
        DAL_Usuario _DAL_Usuario;
        //BLL_Permiso _BLL_Permiso;

        public BLL_Usuario()
        {
            _DAL_Usuario = new DAL_Usuario();
        }

        #region Métodos de logueo
        public LoginResult Login(BE_Usuario oUsuario)
        {

            if (Sesion.IsLogged())
            {
                GuardarBitacora(oUsuario.Email, DateTime.Now, "Error", "Sesion duplicada");
                throw new LoginException(LoginResult.DuplicatedSesion); //doble validación 
            }
            if (_DAL_Usuario.BuscarEmail(oUsuario.Email) == false)
            {
                GuardarBitacora(oUsuario.Email, DateTime.Now, "Error", "Usuario inexistente");
                throw new LoginException(LoginResult.InvalidPassword);
            }
            if (_DAL_Usuario.ComprobarPassword(oUsuario.Email, Encripcion.Hash(oUsuario.Contrasena)) == false)
            {
                GuardarBitacora(oUsuario.Email, DateTime.Now, "Error", "Password incorrecto");
                throw new LoginException(LoginResult.InvalidPassword);
            }
            else
            {
                Sesion.Login(_DAL_Usuario.CargarDatos(oUsuario));
                if (_DAL_Usuario.ComprobarDigito(oUsuario.Email, GestorDigitoVerificador.CalcularDigitoVerificadorHorizontal(Sesion._user)) == false)
                {
                    Sesion.Logout();
                    GuardarBitacora(oUsuario.Email, DateTime.Now, "Error", "Digito verificador de usuario fue incorrecto");
                    throw new LoginException(LoginResult.InvalidDV);
                }
                if (Sesion._user.Estado == false)
                {
                    Sesion.Logout();
                    GuardarBitacora(oUsuario.Email, DateTime.Now, "Error", "Usuario desactivado, acceso rechazado");
                    throw new LoginException(LoginResult.InvalidStatus);
                }
                GuardarBitacora(Sesion._user.Email, DateTime.Now, "Informacion", "Ingreso a sistema");
                return LoginResult.ValidUser;
            }
        }
        #endregion

        public void GuardarBitacora(string pEmail, DateTime pDateTime, string pTipo, string pDescripcion)
        {
            BE_Bitacora _BE_Bitacora = new BE_Bitacora();
            _BE_Bitacora.Email = pEmail;
            _BE_Bitacora.Fecha = pDateTime;
            _BE_Bitacora.Tipo = pTipo;
            _BE_Bitacora.Descripcion = pDescripcion;
            _BE_Bitacora.DvH = GestorDigitoVerificador.CalcularDigitoVerificadorHorizontal(_BE_Bitacora);
            _DAL_Usuario.GuardarBitacora(_BE_Bitacora);
        }
    }
}
