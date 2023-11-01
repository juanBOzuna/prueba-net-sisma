
using BankAPI.Data;
using BankAPI.Data.BanksModals;
using Microsoft.EntityFrameworkCore;


namespace BankAPI.Services;
public class AccountService()
{
    private readonly BankContext _context;
    public AccountService(BankContext context) : this()
    {
        _context = context;
    }

    public async Task<IEnumerable<Account>> GetAll()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task<Account?> GetById(int id)
    {
        return await _context.Accounts.FindAsync(id);

    }

    public async Task<Account> Create(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();

        return account;
    }

    public async Task Update(Account account)
    {

        var ExistingAccount = await GetById(account.Id);
        if (ExistingAccount is not null)
        {
            ExistingAccount.AccountType = account.AccountType;
            ExistingAccount.ClientId= account.ClientId;
            ExistingAccount.Balance = account.Balance;
            _context.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var ExistingAccount = await GetById(id);
        if (ExistingAccount is not null)
        {
            _context.Accounts.Remove(ExistingAccount);
            await _context.SaveChangesAsync();
        }
    }
}