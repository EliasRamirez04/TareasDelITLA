using System.Collections.Generic;
using CapaEntidades;
using System.Linq;

namespace CapaDatos
{
    public class LibroDatos
    {
        private List<Libro> libros = new List<Libro>();
        private int nextId = 1;

        public List<Libro> ObtenerLibros() => libros;

        public void AgregarLibro(Libro libro)
        {
            libro.Id = nextId++;
            libros.Add(libro);
        }

        public void EliminarLibro(int id)
        {
            var libro = libros.FirstOrDefault(l => l.Id == id);
            if (libro != null) libros.Remove(libro);
        }

        public Libro ObtenerPorId(int id)
        {
            return libros.FirstOrDefault(l => l.Id == id);
        }
    }
}
