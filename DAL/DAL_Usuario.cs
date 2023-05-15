using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace DAL
{
    public class DAL_Usuario
    {
        Acceso oDatos;
        public bool BuscarEmail(string pEmail)
        {
            oDatos = new Acceso();
            Hashtable Hdatos = new Hashtable();
            string Consulta = "SP_Verificar_Email";

            Hdatos.Add("@email", pEmail);

            return oDatos.LeerScalar(Consulta, Hdatos);
        }

        public bool ComprobarPassword(string pEmail, string pPassword)
        {
            oDatos = new Acceso();
            Hashtable Hdatos = new Hashtable();
            string Consulta_SQL = "SP_Verificar_Password";

            Hdatos.Add("@Email", pEmail);
            Hdatos.Add("@Contrasena", pPassword);

            return oDatos.LeerScalar(Consulta_SQL, Hdatos) == true;
        }

        public BE_Usuario CargarDatos(BE_Usuario oUsuario)
        {
            oDatos = new Acceso();
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@email", oUsuario.Email);

            DataTable Dt = oDatos.Leer("SP_Listar_UsuarioxEmail", Hdatos);
            BE_Usuario _BE_Usuario = new BE_Usuario();
            if (Dt.Rows.Count > 0)
            {
                foreach (DataRow fila in Dt.Rows)
                {
                    _BE_Usuario.Email = fila["email"].ToString();
                    _BE_Usuario.Nombre = fila["nombre"].ToString();
                    _BE_Usuario.Apellido = fila["apellido"].ToString();
                    _BE_Usuario.FechaNacimiento = Convert.ToDateTime(fila["fecha_nacimiento"]);
                    _BE_Usuario.Provincia = Convert.ToInt32(fila["provincia"]);
                    _BE_Usuario.Estado = Convert.ToBoolean(fila["estado"]);
                    _BE_Usuario.Contrasena = fila["contrasena"].ToString();
                    _BE_Usuario.Telefono = fila["telefono"].ToString();
                    _BE_Usuario.Direccion = fila["direccion"].ToString();
                    _BE_Usuario.DvH = fila["dvh"].ToString();
                    //CargarIdioma(_BE_Usuario);

                }
                return _BE_Usuario;
            }
            else
            { return null; }
        }

        public List<BE_Provincia> ListarProvincia()
        {
            oDatos = new Acceso();
            Hashtable Hdatos = new Hashtable();
            string Consulta_SQL = "SP_Listar_Provincia";

            DataTable Dt = oDatos.Leer(Consulta_SQL, null);
            List<BE_Provincia> ListProvincias = new List<BE_Provincia>();

            if (Dt.Rows.Count > 0)
            {
                foreach (DataRow fila in Dt.Rows)
                {
                    BE_Provincia _BE_Provincia = new BE_Provincia();
                    _BE_Provincia.Id = Convert.ToInt32(fila["id"]);
                    _BE_Provincia.Nombre = fila["nombre"].ToString();
                    ListProvincias.Add(_BE_Provincia);
                }
                return ListProvincias;
            }
            else
            {
                return null;
            }
        }

        public bool ComprobarDigito(string pEmail, string pDVH)
        {
            oDatos = new Acceso();
            Hashtable Hdatos = new Hashtable();
            string Consulta_SQL = "SP_Verificar_DigitoHorizontal";

            Hdatos.Add("@email", pEmail);
            Hdatos.Add("@DVH", pDVH);

            return oDatos.LeerScalar(Consulta_SQL, Hdatos) == true;
        }

        public void GuardarBitacora(BE_Bitacora oBE_Bitacora)
        {
            oDatos = new Acceso();
            Hashtable Hdatos = new Hashtable();
            string Consulta = "SP_Guardar_Bitacora";

            Hdatos.Add("@email", oBE_Bitacora.Email);
            Hdatos.Add("@fecha", oBE_Bitacora.Fecha);
            Hdatos.Add("@tipo", oBE_Bitacora.Tipo);
            Hdatos.Add("@descripcion", oBE_Bitacora.Descripcion);
            Hdatos.Add("@dvh", oBE_Bitacora.DvH);


            oDatos.Escribir(Consulta, Hdatos);
        }

        public void GuardarBitacora(string pEmail, DateTime pFecha, string pTipo, string pDescripcion)
        {
            oDatos = new Acceso();
            Hashtable Hdatos = new Hashtable();
            string Consulta = "SP_Guardar_Bitacora";

            Hdatos.Add("@Email", pEmail);
            Hdatos.Add("@Fecha", pFecha.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Hdatos.Add("@Tipo", pTipo);
            Hdatos.Add("@Descripcion", pDescripcion);


            oDatos.Escribir(Consulta, Hdatos);
        }
    }
}
