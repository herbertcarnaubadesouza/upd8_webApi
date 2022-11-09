using upd8_webApi.DTO.Resposta;
using upd8_webApi.DTO.Solicitação;
using upd8_webApi.Models;

namespace Servicos.Interfaces
{
    public interface IClientesService
    {
        Task<ICollection<Cliente>> GetClientes(ClienteSolicitacaoDto clientesQuery);
        Task<Cliente> GetCliente(int clienteId);
        bool ClienteExists(int clienteId);
        bool UpdateCliente(Cliente cliente);
        bool CreateCliente(Cliente cliente);    
        Task<bool> DeleteCliente(int clienteId);
    }
}
