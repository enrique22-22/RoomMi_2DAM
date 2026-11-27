using RoomMi.Datos.Repositorios;
using RoomMi.Modelos;
using RoomMi.Servicios.Interfaces;

namespace RoomMi.Servicios
{
    public class UsuarioServicio : ServicioGenerico<Usuario>, IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio)
            : base(usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio ?? throw new ArgumentNullException(nameof(usuarioRepositorio));
        }

        public async Task<Usuario?> LoginAsync(string username, string password)
        {
            var usuario = await _usuarioRepositorio.GetUsuarioByUserNameAsync(username);
            if (usuario != null && usuario.Contraseña != password)
            {
                usuario = null;
            }
            return usuario;
        }
    }
}
