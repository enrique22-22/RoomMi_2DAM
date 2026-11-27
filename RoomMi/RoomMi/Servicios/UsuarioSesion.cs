using RoomMi.Modelos;

namespace RoomMi.Servicios
{
    public sealed class UsuarioSesion
    {
        public Usuario? UsuarioActual { get; set; }

        public bool EstaAutenticado => UsuarioActual is not null;

        public void IniciarSesion(Usuario usuario)
        {
            UsuarioActual = usuario ?? throw new ArgumentNullException(nameof(usuario));
        }

        public void CerrarSesion()
        {
            UsuarioActual = null;
        }
    }
}
