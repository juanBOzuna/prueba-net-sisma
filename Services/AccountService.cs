
using BankAPI.Data;
using BankAPI.Data.BanksModals;
using Microsoft.EntityFrameworkCore;

using BankAPI.Data.DTOs;


namespace BankAPI.Services;
public class AccountService
{
    private readonly BankContext _context;
    public AccountService(BankContext context) 
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

    public async Task<Account> Create(AccountDTO account)
    {
        var acc = new Account();
        
        acc.AccountType = account.AccountTypeId;
        acc.Balance= account.Balance;
        acc.ClientId = account.ClientId;

        _context.Accounts.Add(acc);
        await _context.SaveChangesAsync();

        return acc;
    }

    public async Task Update(AccountDTO account)
    {

        var ExistingAccount = await GetById(account.Id);
        if (ExistingAccount is not null)
        {
            ExistingAccount.AccountType = account.AccountTypeId;
            ExistingAccount.ClientId = account.ClientId;
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