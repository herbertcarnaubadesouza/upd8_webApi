using Microsoft.EntityFrameworkCore;
using upd8_webApi.Data;
using upd8_webApi.Models;
using upd8_webApi.Repository.Interfaces;

namespace upd8_webApi.Repository.Implementations
{
    public class EstadosRepository : IEstadoRepository
    {
        private upd8_webApiContext _context;

        public EstadosRepository(upd8_webApiContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Estado>> GetEstados()
        {
            return await _context.Estado.ToListAsync();
        }

        public async Task<Estado> GetEstados(int estadoId)
        {
            return await _context.Estado.FirstOrDefaultAsync(x => x.EstadoId == estadoId);
        }

        public bool EstadoExists(int id)
        {
            return _context.Estado.Any(c => c.EstadoId == id);
        }

        public bool UpdateEstado(Estado Estado)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _context.Update(Estado);
            return Save();
        }

        public bool CreateEstado(Estado Estado)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _context.Add(Estado);
            return Save();
        }

        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<bool> DeleteEstado(int EstadoId)
        {
            var pedido = await _context.Estado.Where(x => x.EstadoId == EstadoId).FirstOrDefaultAsync();

            if (pedido == null) return false;

            _context.Estado.Remove(pedido);
            return Save();

        }
    }
}
