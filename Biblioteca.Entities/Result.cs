using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Entities
{
    public class Result<T>
    {
        public T Resultado { get; set; }
        public string Mensaje { get; set; }
        public string Codigo { get; set; }
    }
}
