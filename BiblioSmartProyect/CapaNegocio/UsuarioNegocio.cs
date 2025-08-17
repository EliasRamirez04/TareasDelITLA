using System.Collections.Generic;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class UsuarioNegocio
    {
        private UsuarioDatos datos = new UsuarioDatos();
        public List<Usuario> ObtenerUsuarios() => datos.ObtenerUsuarios();
        public void AgregarUsuario(Usuario usuario) => datos.AgregarUsuario(usuario);
        public void EliminarUsuario(int id) => datos.EliminarUsuario(id);
        public Usuario ObtenerUsuarioPorId(int id) => datos.ObtenerPorId(id);
    }
}
