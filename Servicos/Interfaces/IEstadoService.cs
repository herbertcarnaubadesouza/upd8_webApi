using upd8_webApi.DTO.Resposta;
using upd8_webApi.DTO.Solicitação;

namespace upd8_webApi.Services.Interfaces
{
    public interface IEstadoService
    {
        Task<ICollection<EstadoDTO>> GetEstados();
        Task<EstadoDTO> GetEstado(int estadoId);
        bool EstadoExists(int estadod);
        bool UpdateEstado(EstadoDTO estado);
        bool CreateEstado(EstadoSolicitacaoDto estado);
        Task<bool> DeleteEstado(int estadoId);
    }
}
