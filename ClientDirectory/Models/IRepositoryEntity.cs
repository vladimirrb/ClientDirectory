namespace ClientDirectory.Models
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<IEnumerable<Client>> GetClientsWithDetailsAsync();
    }

    public interface ICityRepository : IRepository<City>
    {
        Task<IEnumerable<City>> GetCitiesWithCompaniesAsync();
    }

    public interface ICompanyRepository : IRepository<Company>
    {
        Task<IEnumerable<Company>> GetCompaniesWithCityAsync();
    }
}
