using Biblioteca.DAL;
using Biblioteca.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BL
{
    public class LibrosBL
    {
        public static async Task<Result<Libros>> InsertarLibro(Libros pLibro)
        {
            Result<Libros> Respuesta = new Result<Libros>();
            try
            {
                var result = await LibrosDAL.InsertarLibro(pLibro);

                return result;
            }
            catch (Exception _ex)
            {
                Respuesta.Mensaje = "Error en logica de negocio" + _ex.Message;
                Respuesta.Codigo = "02";
                return Respuesta;
            }
        }

        public static async Task<List<Libros>> ObtenerLibros()
        {
            try
            {
                var result = await LibrosDAL.ObtenerLibros();
                return result;
            }
            catch (Exception _ex)
            {
                return new List<Libros>();
            }
        }
    }   
}
