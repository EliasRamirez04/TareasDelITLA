using System.Collections.Generic;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class PrestamoNegocio
    {
        private PrestamoDatos datos = new PrestamoDatos();
        public List<Prestamo> ObtenerPrestamos() => datos.ObtenerPrestamos();
        public void AgregarPrestamo(Prestamo p) => datos.AgregarPrestamo(p);
        public void DevolverLibro(int id) => datos.DevolverLibro(id);
    }
}
