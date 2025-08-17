using System.Collections.Generic;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class LibroNegocio
    {
        private LibroDatos datos = new LibroDatos();
        public List<Libro> ObtenerLibros() => datos.ObtenerLibros();
        public void AgregarLibro(Libro libro) => datos.AgregarLibro(libro);
        public void EliminarLibro(int id) => datos.EliminarLibro(id);
        public Libro ObtenerLibroPorId(int id) => datos.ObtenerPorId(id);
    }
}
