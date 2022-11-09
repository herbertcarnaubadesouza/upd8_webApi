using AutoMapper;
using Repositorio.Interfaces;
using Servicos.Interfaces;
using upd8_webApi.DTO.Resposta;
using upd8_webApi.DTO.Solicitação;
using upd8_webApi.Models;

namespace Servicos.Implementations
{
    public class ClienteService : IClientesService
    {
        private readonly IClientesRepository _clientesRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClientesRepository clientesRepository, IMapper mapper)
        {
            _clientesRepository = clientesRepository;
            _mapper = mapper;
        }        

        public async Task<ICollection<Cliente>> GetClientes(ClienteSolicitacaoDto clientesQuery)
        {
            return await _clientesRepository.GetClientes(clientesQuery);
        }

        public async Task<Cliente> GetCliente(int clienteId)
        {
            return await _clientesRepository.GetCliente(clienteId);
        }

        public bool ClienteExists(int clienteId)
        {
            return _clientesRepository.ClienteExists(clienteId);
        }

        public bool UpdateCliente(Cliente cliente)
        {
            return _clientesRepository.UpdateCliente(cliente);
        }

        public bool CreateCliente(Cliente cliente)
        {
            return _clientesRepository.CreateCliente(cliente);
        }

        public Task<bool> DeleteCliente(int clienteId)
        {
            return _clientesRepository.DeleteCliente(clienteId);
        }
    }
}
