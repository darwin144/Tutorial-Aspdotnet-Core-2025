using CArch_V1.Interface;
using CArch_V1.Models;
using Microsoft.EntityFrameworkCore;



namespace CArch_V1.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContexCArch2025 _context;
        public UserRepository(DbContexCArch2025 context) { 
        
            _context = context;
        }
        public async Task<Tm_User> Create(Tm_User data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> Delete(int id)
        {
            var data = GetById(id);
            if (data == null) {
                return false;
            }            
            _context.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Tm_User>> GetAll()
        {
            try
            {
                return  _context.Tm_User.ToList();
                
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Tm_User> GetById(int id)
        {
            return await _context.Tm_User.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tm_User> Update(Tm_User data)
        {
            _context.Update(data);
            await _context.SaveChangesAsync();
            return data;            
        }


       
    }
}
