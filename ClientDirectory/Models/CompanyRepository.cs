using Microsoft.EntityFrameworkCore;

namespace ClientDirectory.Models
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Company>> GetCompaniesWithCityAsync()
        {
            return await _dbSet.Include(c => c.City)
                               .ToListAsync();
        }
    }
}
