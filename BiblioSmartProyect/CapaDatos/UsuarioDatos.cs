using System.Collections.Generic;
using System.Linq;
using CapaEntidades;

namespace CapaDatos
{
    public class UsuarioDatos
    {
        private List<Usuario> usuarios = new List<Usuario>();
        private int nextId = 1;

        public List<Usuario> ObtenerUsuarios() => usuarios;

        public void AgregarUsuario(Usuario usuario)
        {
            usuario.Id = nextId++;
            usuarios.Add(usuario);
        }

        public void EliminarUsuario(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null) usuarios.Remove(usuario);
        }

        public Usuario ObtenerPorId(int id)
        {
            return usuarios.FirstOrDefault(u => u.Id == id);
        }
    }
}
