using Microsoft.EntityFrameworkCore;
using upd8_webApi.Data;
using upd8_webApi.Models;
using upd8_webApi.Repository.Interfaces;

namespace upd8_webApi.Repository.Implementations
{
    public class CidadesRepository : ICidadeRepository
    {
        private upd8_webApiContext _context;

        public CidadesRepository(upd8_webApiContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Cidade>> GetCidades()
        {
            return await _context.Cidade.ToListAsync();
        }

        public async Task<Cidade> GetCidades(int cidadeId)
        {
            return await _context.Cidade.FirstOrDefaultAsync(x => x.CidadeId == cidadeId);
        }

        public bool CidadeExists(int id)
        {
            return _context.Cidade.Any(c => c.CidadeId == id);
        }

        public bool UpdateCidade(Cidade cidade)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _context.Update(cidade);
            return Save();
        }

        public bool CreateCidade(Cidade cidade)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _context.Add(cidade);
            return Save();
        }

        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<bool> DeleteCidade(int cidadeId)
        {
            var pedido = await _context.Cidade.Where(x => x.CidadeId == cidadeId).FirstOrDefaultAsync();

            if (pedido == null) return false;

            _context.Cidade.Remove(pedido);
            return Save();

        }
    }
}
