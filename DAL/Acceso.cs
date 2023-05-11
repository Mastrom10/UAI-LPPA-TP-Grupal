using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias SQL
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace DAL
{
    public class Acceso
    {
        private SqlConnection ConectarBD = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ToString());
        private SqlTransaction Transaction;
        private SqlCommand Cmd;

        public string TestConnection()
        {
            ConectarBD.Open();
            if (ConectarBD.State == ConnectionState.Open)
            {
                return "Conexion a la BD OK";
            }
            else
            {
                return "No se pudo conectar a la BD, que pacho???";
            }
        }

        public DataTable Leer(string Consulta, Hashtable Hdatos)
        {
            DataTable Dt = new DataTable();
            SqlDataAdapter Da;

            try
            {
                //paso la consulta y el objeto conection en el constructor
                Cmd = new SqlCommand(Consulta, ConectarBD);
                Cmd.CommandType = CommandType.StoredProcedure;
                Da = new SqlDataAdapter(Cmd);

                if ((Hdatos != null))
                {
                    //si la hashtable no esta vacia, y tiene el dato q busco 
                    foreach (string dato in Hdatos.Keys)
                    {
                        //cargo los parametros que le estoy pasando con la Hash
                        Cmd.Parameters.AddWithValue(dato, Hdatos[dato]);
                    }
                }
            }

            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Da.Fill(Dt);
            return Dt;

        }

        public bool Escribir(string consulta, Hashtable Hdatos)
        {

            if (ConectarBD.State == ConnectionState.Closed)
            {
                ConectarBD.ConnectionString = ConfigurationManager.ConnectionStrings["CadenaConexionSQL"].ToString();
                ConectarBD.Open();
            }
            try
            {
                Transaction = ConectarBD.BeginTransaction();

                Cmd = new SqlCommand(consulta, ConectarBD, Transaction);

                Cmd.CommandType = CommandType.StoredProcedure;

                if ((Hdatos != null))
                {
                    //si la hashtable no esta vacia, y tiene el dato q busco 
                    foreach (string dato in Hdatos.Keys)
                    {
                        //cargo los parametros que le estoy pasando con la Hash
                        Cmd.Parameters.AddWithValue(dato, Hdatos[dato]);
                    }
                }

                int respuesta = Cmd.ExecuteNonQuery();
                Transaction.Commit();
                return true;

            }

            catch (SqlException ex)
            {
                Transaction.Rollback();
                return false;
                throw ex;
            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                return false;
                throw ex;
            }
            finally
            { ConectarBD.Close(); }

        }

        public bool LeerScalar(string Consulta, Hashtable Hdatos)
        {
            ConectarBD.Open();
            //uso el constructor del objeto Command al instanciar el objeto
            Cmd = new SqlCommand(Consulta, ConectarBD);
            Cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if ((Hdatos != null))
                {
                    //si la hashtable no esta vacia, y tiene el dato q busco 
                    foreach (string dato in Hdatos.Keys)
                    {
                        //cargo los parametros que le estoy pasando con la Hash
                        Cmd.Parameters.AddWithValue(dato, Hdatos[dato]);
                    }
                }

                int Respuesta = Convert.ToInt32(Cmd.ExecuteScalar());
                ConectarBD.Close();
                if (Respuesta > 0)
                { return true; }
                else
                { return false; }
            }
            catch (SqlException ex)
            { throw ex; }
        }

    }
}