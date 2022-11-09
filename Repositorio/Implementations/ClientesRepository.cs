using Microsoft.EntityFrameworkCore;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using upd8_webApi.Data;
using upd8_webApi.DTO.Solicitação;
using upd8_webApi.Models;

namespace Repositorio.Implementations
{
    public class ClientesRepository : IClientesRepository
    {
        private upd8_webApiContext _context;

        public ClientesRepository(upd8_webApiContext context)
        {
            _context = context;
        }

        public async Task<Cliente> GetCliente(int clienteId)
        {
            return await _context.Cliente.Include(x => x.CIDADE).Include(x => x.ESTADO).FirstOrDefaultAsync(x => x.ClienteId == clienteId);
        }

        public bool ClienteExists(int id)
        {
            return _context.Cliente.Any(c => c.ClienteId == id);
        }

        public async Task<ICollection<Cliente>> GetClientes(ClienteSolicitacaoDto clientesQuery)
        {
            List<Cliente> clienteLista = new List<Cliente>();

            using (var context = _context)
            {
                IQueryable<Cliente> clienteConsulta = context.Cliente.Include(x => x.CIDADE).Include(x => x.ESTADO);

                if (!string.IsNullOrEmpty(clientesQuery.searchByName) || !string.IsNullOrEmpty(clientesQuery.searchByCPF) || !string.IsNullOrEmpty(clientesQuery.searchByDate) || !string.IsNullOrEmpty(clientesQuery.searchBySexo) || !string.IsNullOrEmpty(clientesQuery.searchByAddress) || !string.IsNullOrEmpty(clientesQuery.Estados) || !string.IsNullOrEmpty(clientesQuery.Cidades))
                {
                    if (!string.IsNullOrEmpty(clientesQuery.searchByName))
                    {
                        clienteConsulta = clienteConsulta.Where(x => x.ClienteName == clientesQuery.searchByName);
                    }
                    if (!string.IsNullOrEmpty(clientesQuery.searchByCPF))
                    {
                        clienteConsulta = clienteConsulta.Where(x => x.CPF == clientesQuery.searchByCPF);
                    }
                    if (!string.IsNullOrEmpty(clientesQuery.searchByDate))
                    {
                        clienteConsulta = clienteConsulta.Where(x => x.Birth == DateTime.Parse(clientesQuery.searchByDate));
                    }
                    if (!string.IsNullOrEmpty(clientesQuery.searchBySexo))
                    {
                        clienteConsulta = clienteConsulta.Where(x => x.Sexo == clientesQuery.searchBySexo);
                    }

                    if (!string.IsNullOrEmpty(clientesQuery.searchByAddress))
                    {
                        clienteConsulta = clienteConsulta.Where(x => x.Endereco == clientesQuery.searchByAddress);
                    }

                    if (!string.IsNullOrEmpty(clientesQuery.Estados))
                    {
                        clienteConsulta = clienteConsulta.Where(x => x.EstadoId == int.Parse(clientesQuery.Estados));
                    }

                    if (!string.IsNullOrEmpty(clientesQuery.Cidades))
                    {
                        clienteConsulta = clienteConsulta.Where(x => x.CidadeId == int.Parse(clientesQuery.Cidades));
                    }

                }
                return await clienteConsulta.ToListAsync();
            }
        }

        public bool UpdateCliente(Cliente cliente)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _context.Update(cliente);
            return Save();
        }

        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateCliente(Cliente cliente)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _context.Add(cliente);
            return Save();
        }

        public async Task<bool> DeleteCliente(int clienteId)
        {
            var cliente = await _context.Cliente.Where(x => x.ClienteId == clienteId).FirstOrDefaultAsync();

            if (cliente == null) return false;

            _context.Cliente.Remove(cliente);
            return Save();
        }
    }
}
