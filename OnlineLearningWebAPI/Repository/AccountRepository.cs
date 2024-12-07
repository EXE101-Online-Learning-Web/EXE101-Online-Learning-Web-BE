using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly OnlineLearningDbContext _context;

        public AccountRepository(OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Account entity)
        {
            await _context.Accounts.AddAsync(entity);
        }

        public void Delete(Account entity)
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts.Include(a => a.Role).ToListAsync();
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            return await _context.Accounts.Include(a => a.Role).FirstOrDefaultAsync(a => a.AccountId == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Account entity)
        {
            _context.Accounts.Update(entity);
        }
    }
}
