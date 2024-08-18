using Microsoft.EntityFrameworkCore;

namespace ClientDirectory.Models
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<City>> GetCitiesWithCompaniesAsync()
        {
            return await _dbSet.Include(c => c.Companies)
                               .ToListAsync();
        }
    }
}
