using upd8_webApi.DTO.Resposta;
using upd8_webApi.DTO.Solicitação;

namespace upd8_webApi.Services.Interfaces
{
    public interface ICidadeService
    {
        Task<ICollection<CidadeDTO>> GetCidades();
        Task<CidadeDTO> GetCidade(int cidadeId);
        bool CidadeExists(int cidadeId);
        bool UpdateCidade(CidadeDTO cidade);
        bool CreateCidade(CidadeSolicitacaoDto cidade);
        Task<bool> DeleteCidade(int cidadeId);

    }
}
