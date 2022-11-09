using upd8_webApi.DTO.Solicitação;
using upd8_webApi.Models;

namespace Repositorio.Interfaces
{
    public interface IClientesRepository
    {
        Task<ICollection<Cliente>> GetClientes(ClienteSolicitacaoDto clientesQuery);
        Task<Cliente> GetCliente(int clienteId);
        bool ClienteExists(int clienteId);
        bool UpdateCliente(Cliente cliente); 
        bool CreateCliente(Cliente cliente);
        Task<bool> DeleteCliente(int clienteId);
    }
}
