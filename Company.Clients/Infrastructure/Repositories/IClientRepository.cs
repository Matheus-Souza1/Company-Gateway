using Company.Clients.Entities;

namespace Company.Clients.Infrastructure.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetById(Guid id);
        Task AddClient(Client client);
        Task UpdateClient(Client client);
        Task DeleteClient(Guid id);
    }
}
