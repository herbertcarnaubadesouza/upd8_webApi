using upd8_webApi.Models;

namespace upd8_webApi.Repository.Interfaces
{
    public interface ICidadeRepository
    {
        Task<ICollection<Cidade>> GetCidades();
        Task<Cidade> GetCidades(int cidadeId);
        bool CidadeExists(int cidadeId);
        bool UpdateCidade(Cidade cidade);
        bool CreateCidade(Cidade cidade);
        Task<bool> DeleteCidade(int cidadeId);
    }
}
