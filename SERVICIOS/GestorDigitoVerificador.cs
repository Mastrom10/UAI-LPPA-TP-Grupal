using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class GestorDigitoVerificador
    {
        public static string CalcularDigitoVerificadorHorizontal(object entity)
        {
            Type t = entity.GetType();
            string dvh = string.Empty;
            var props = t.GetProperties();

            foreach (var item in props)
            {
                var atributos = item.GetCustomAttributes();
                var verificable = atributos.FirstOrDefault(i => i.GetType().Equals(typeof(PropiedadVerificable)));

                if (verificable != null)
                {
                    if (item.PropertyType.FullName.Equals(typeof(DateTime).FullName))
                    {
                        DateTime a = (DateTime)item.GetValue(entity);
                        dvh += a.ToString("ddmmyyyyhhmmss");
                    }
                    else
                    {
                        dvh += item.GetValue(entity).ToString();
                    }
                }
            }

            return Encripcion.Hash(dvh);
        }
    }
}
