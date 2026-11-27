using RoomMi.Datos.Repositorios;


namespace RoomMi.Servicios.Interfaces
{
    public interface IServicioGenerico<T> : IGenericRepository<T>
        where T : class
    {
    }
}
