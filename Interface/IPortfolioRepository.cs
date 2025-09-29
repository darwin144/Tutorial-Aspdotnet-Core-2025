
using EntityData.Models;

namespace CArch_V1.Interface
{
    public interface IPortfolioRepository
    {
        Task<List<Tm_Portfolio>> GetAll();
        Task<Tm_Portfolio> GetById(int id);
        Task Create(Tm_Portfolio obj);
        Task<Tm_Portfolio> Update(Tm_Portfolio obj);
        Task<bool> Delete(int id);
    }
}
