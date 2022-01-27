using Biblioteca.BL;
using Biblioteca.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    { 
        [HttpPost]
        [Route("RegistrarLibro")]
        public async Task<object> Post([FromBody] Libros pLibro)
         {
            var response = new Result<Libros>();
            try
            {
                response = await LibrosBL.InsertarLibro(pLibro);
                return response;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("ObtenerTodosLosLibros")]
        public async Task<object> ObtenerTodosLosLibros()
        {
            var response = new Result<List<Libros>>();
            try
            {
                var result = await LibrosBL.ObtenerLibros();

                response.Resultado = result;
                response.Codigo = "00";
                response.Mensaje = "Transaccion Exitosa";
                return response;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }    
}
