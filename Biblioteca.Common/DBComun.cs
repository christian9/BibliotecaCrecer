using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Common
{
    public class DBComun
    {
        public static string ObtenerConexionSQL()
        {
            string cadena = "Data Source=.;Initial Catalog=Bicblioteca;Integrated Security=True";
            if (!string.IsNullOrWhiteSpace(cadena))
            {
                return cadena;
            }
            throw new Exception("No se ha detectencontrado la cadena de conexion");
        }
    }
}
