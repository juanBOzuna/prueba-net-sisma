
using BankAPI.Data;
using BankAPI.Data.BanksModals;
using Microsoft.EntityFrameworkCore;


namespace BankAPI.Services;
public class TypeAccountService()
{
    private readonly BankContext _context;
    public TypeAccountService(BankContext context) : this()
    {
        _context = context;
    }

    public async Task<IEnumerable<AccountType>> GetAll()
    {
        return await _context.AccountTypes.ToListAsync();
    }

    public async Task<AccountType?> GetById(int id)
    {
        return await _context.AccountTypes.FindAsync(id);

    }

    
}