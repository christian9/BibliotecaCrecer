using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Entities
{
    public class Libros
    {
        public int IdAutor { get; set; }
        public int IdEditorial { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
    }
}
