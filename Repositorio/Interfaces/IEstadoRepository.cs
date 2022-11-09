using upd8_webApi.Models;

namespace upd8_webApi.Repository.Interfaces
{
    public interface IEstadoRepository
    {
        Task<ICollection<Estado>> GetEstados();
        Task<Estado> GetEstados(int estadoId);
        bool EstadoExists(int estadoId);
        bool UpdateEstado(Estado estado);
        bool CreateEstado(Estado estado);
        Task<bool> DeleteEstado(int estadoId);
    }
}
