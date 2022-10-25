using Company.Clients.Entities;
using Company.Clients.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Company.Clients.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientDbContext _context;

        public ClientRepository(ClientDbContext context)
        {
            _context = context;
        }

        public async Task AddClient(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClient(Guid id)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(c => c.Id == id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetById(Guid id)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(c => c.Id == id);
            return client;
        }

        public async Task UpdateClient(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }
    }
}
