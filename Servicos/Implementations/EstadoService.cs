using AutoMapper;
using upd8_webApi.DTO.Resposta;
using upd8_webApi.DTO.Solicitação;
using upd8_webApi.Models;
using upd8_webApi.Repository.Interfaces;
using upd8_webApi.Services.Interfaces;

namespace upd8_webApi.Services.Implementations
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly IMapper _mapper;
        public EstadoService(IEstadoRepository estadoRepository, IMapper mapper)
        {
            _estadoRepository = estadoRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<EstadoDTO>> GetEstados()
        {
            var completeEstados = await _estadoRepository.GetEstados();

            var estados = _mapper.Map<List<EstadoDTO>>(completeEstados);

            return estados;

        }
        public async Task<EstadoDTO> GetEstado(int estadoId)
        {
            var completeEstado = await _estadoRepository.GetEstados(estadoId);

            if (completeEstado == null) return null;

            var estado = _mapper.Map<EstadoDTO>(completeEstado);

            return estado;
        }

        public bool UpdateEstado(EstadoDTO estado)
        {
            var estadoMap = _mapper.Map<Estado>(estado);

            return _estadoRepository.UpdateEstado(estadoMap);
        }

        public bool EstadoExists(int estadoId)
        {
            return _estadoRepository.EstadoExists(estadoId);
        }

        public bool CreateEstado(EstadoSolicitacaoDto estado)
        {
            var estadoMap = _mapper.Map<Estado>(estado);

            return _estadoRepository.CreateEstado(estadoMap);
        }
        public async Task<bool> DeleteEstado(int estadoId)
        {
            return await _estadoRepository.DeleteEstado(estadoId);
        }
    }
}
