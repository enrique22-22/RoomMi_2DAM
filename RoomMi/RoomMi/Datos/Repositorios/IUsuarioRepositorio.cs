using RoomMi.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomMi.Datos.Repositorios
{
    public interface IUsuarioRepositorio : IGenericRepository<Usuario>
    {
        Task<Usuario?> GetUsuarioByUserNameAsync(string username, CancellationToken cancellationToken = default);
    }
}
