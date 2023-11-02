
using BankAPI.Data;
using BankAPI.Data.BanksModals;
using Microsoft.EntityFrameworkCore;


namespace BankAPI.Services;
public class ClientService
{
    private readonly BankContext _context;
    public ClientService(BankContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAll()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client?> GetById(int id)
    {
        return await _context.Clients.FindAsync(id);
        
    }

    public async Task<Client> Create(Client client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();

        return client;
    }

    public async Task Update(Client client)
    {
        
        var ExistingClient = await GetById(client.Id);
        if (ExistingClient is not null)
        {
        ExistingClient.Name = client.Name;
        ExistingClient.PhoneNumber = client.PhoneNumber;
        ExistingClient.Email = client.Email;
        _context.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var ExistingClient = await GetById(id);
        if (ExistingClient is not null)
        {
            _context.Clients.Remove(ExistingClient);
           await  _context.SaveChangesAsync();
        }
    }
}