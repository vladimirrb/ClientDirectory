using Microsoft.EntityFrameworkCore;

namespace ClientDirectory.Models
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Client>> GetClientsWithDetailsAsync()
        {
            return await _dbSet.Include(c => c.City)
                               .Include(c => c.Company)
                               .ToListAsync();
        }
    }
}
