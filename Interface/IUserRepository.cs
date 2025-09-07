using CArch_V1.Models;

namespace CArch_V1.Interface
{
    public interface IUserRepository
    {
        Task<List<Tm_User>> GetAll();
        Task<Tm_User> GetById(int id);
        Task<Tm_User> Create(Tm_User user);
        Task<Tm_User> Update(Tm_User user);
        Task <bool> Delete(int id);

    }
}
