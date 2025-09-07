using CArch_V1.Interface;
using CArch_V1.Models;
using Microsoft.EntityFrameworkCore;

namespace CArch_V1.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly DbContexCArch2025 _context;
        public PortfolioRepository(DbContexCArch2025 context)
        {
            _context = context;
        }
        public async Task Create(Tm_Portfolio data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var data = GetById(id);
            if (data == null)
            {
                return false;
            }
            _context.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Tm_Portfolio>> GetAll()
        {
            try
            {
                return _context.Tm_Portfolio.ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Tm_Portfolio> GetById(int id)
        {
            return await _context.Tm_Portfolio.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tm_Portfolio> Update(Tm_Portfolio data)
        {
            _context.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }

      
    }
}
