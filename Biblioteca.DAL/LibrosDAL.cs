using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Biblioteca.Common;
using Biblioteca.Entities;

namespace Biblioteca.DAL
{
    public class LibrosDAL
    {
        public static async Task<Result<Libros>> InsertarLibro(Libros pLibro)
        {
            Result<Libros> Respuesta = new Result<Libros>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DBComun.ObtenerConexionSQL()))
                {
                    SqlCommand cmd = new SqlCommand("InsertarLibro", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idAutor", pLibro.IdAutor);
                    cmd.Parameters.AddWithValue("@idEditorial", pLibro.IdEditorial);
                    //cmd.Parameters.AddWithValue("@idCategoria", pLibro.IdCategoria);
                    cmd.Parameters.AddWithValue("@Nombre", pLibro.Nombre);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Respuesta.Codigo = "00";
                    Respuesta.Mensaje = "Libro registrado exitosamente";
                    return Respuesta;
                }

            }
            catch (Exception _ex)
            {
                Respuesta.Codigo = "01";
                Respuesta.Mensaje = _ex.Message;
                return Respuesta;
            }
        }

        public static async Task<List<Libros>> ObtenerLibros()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBComun.ObtenerConexionSQL()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ObtenerLibros";

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Libros> listaLibros = new List<Libros>();
                        Libros tmpLista = new Libros();

                        while (reader.Read())
                        {
                            tmpLista = new Libros();
                            tmpLista.IdAutor = Convert.ToInt32(reader["idAutor"]);
                            tmpLista.IdEditorial = Convert.ToInt32(reader["idEditorial"]);
                            tmpLista.Nombre = reader["Nombre"].ToString();

                            listaLibros.Add(tmpLista);
                        }
                        return listaLibros;

                    }
                }
            }
            catch (Exception ex)
            {               
                return new List<Libros>();
            }
        }
    }
}
