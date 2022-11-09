using AutoMapper;
using upd8_webApi.DTO.Resposta;
using upd8_webApi.DTO.Solicitação;
using upd8_webApi.Models;
using upd8_webApi.Repository.Interfaces;
using upd8_webApi.Services.Interfaces;

namespace upd8_webApi.Services.Implementations
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IMapper _mapper;
        public CidadeService(ICidadeRepository cidadeRepository, IMapper mapper)
        {
            _cidadeRepository = cidadeRepository;
            _mapper = mapper;
        }


        public async Task<ICollection<CidadeDTO>> GetCidades()
        {
            var completeCidades = await _cidadeRepository.GetCidades();

             var cidades = _mapper.Map<List<CidadeDTO>>(completeCidades);

            return cidades;

        }
        public async Task<CidadeDTO> GetCidade(int cidadeId)
        {
            var completeCidade = await _cidadeRepository.GetCidades(cidadeId);

            if (completeCidade == null) return null;

            var cidade = _mapper.Map<CidadeDTO>(completeCidade);

            return cidade;             
        }

        public bool UpdateCidade(CidadeDTO cidade)
        {
            var cidadeMap = _mapper.Map<Cidade>(cidade);

            return _cidadeRepository.UpdateCidade(cidadeMap);
        }

        public bool CidadeExists(int cidadeId)
        {
            return _cidadeRepository.CidadeExists(cidadeId);
        }

        public bool CreateCidade(CidadeSolicitacaoDto cidade)
        {
            var cidadeMap = _mapper.Map<Cidade>(cidade);

            return _cidadeRepository.CreateCidade(cidadeMap);
        }
        public async Task<bool> DeleteCidade(int cidadeId)
        {
            return await _cidadeRepository.DeleteCidade(cidadeId);
        }


    }
}
