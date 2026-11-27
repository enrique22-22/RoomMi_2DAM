using RoomMi.Servicios.Interfaces;
using RoomMi.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMi.Servicios.Interfaces
{
    public interface IUsuarioServicio : IServicioGenerico<Usuario>
    {
        Task<Usuario?> LoginAsync(string username, string password);
    }
}
