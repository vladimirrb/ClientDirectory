using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ClientDirectory.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public Guid CityId { get; set; }
        public City? City { get; set; }
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }
    }

    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid CityId { get; set; }
        public City? City { get; set; }
        public ICollection<Client> Clients { get; set; } = new List<Client>();
    }

    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public ICollection<Company> Companies { get; set; } = new List<Company>();
        public ICollection<Client> Clients { get; set; } = new List<Client>();
    }


}
