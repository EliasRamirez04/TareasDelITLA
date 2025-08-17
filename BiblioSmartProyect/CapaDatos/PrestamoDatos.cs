using System.Collections.Generic;
using System.Linq;
using CapaEntidades;
using System;

namespace CapaDatos
{
    public class PrestamoDatos
    {
        private List<Prestamo> prestamos = new List<Prestamo>();
        private int nextId = 1;

        public List<Prestamo> ObtenerPrestamos() => prestamos;

        public void AgregarPrestamo(Prestamo prestamo)
        {
            prestamo.Id = nextId++;
            prestamos.Add(prestamo);
        }

        public void DevolverLibro(int idPrestamo)
        {
            var p = prestamos.FirstOrDefault(pr => pr.Id == idPrestamo);
            if (p != null)
                p.FechaDevolucion = DateTime.Now;
        }
    }
}
