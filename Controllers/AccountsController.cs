//using Microsoft.AspNetCore.Mvc;
//using BankAPI.Services;
//using BankAPI.Data.BanksModals;
//using BankAPI.Data.DTOs;
//namespace BankAPI.Controllers;


//[ApiController]
//[Route("[controller]")]
//public class AccountsController : ControllerBase
//{
//    private readonly AccountService _service;
//    private readonly ClientService clientService;
//    private readonly TypeAccountService typeAccountService;

//    public AccountsController(AccountService accountService, ClientService clientService, TypeAccountService typeAccountService) 
//    {
//        _service = accountService;
//        this.clientService = clientService;
//        this.typeAccountService = typeAccountService;
//    }

//    [HttpGet]
//    public async Task<IEnumerable<Account>> Get()
//    {
//        return await _service.GetAll();
//    }

//    [HttpGet("{id}")]
//    public async Task<ActionResult<Account>> GetById(int id)
//    {
//        var account = await _service.GetById(id);
//        if (account is null) return AccountNotFound(id);
//        return account;
//    }

//    [HttpPost]
//    public async Task<IActionResult> Create(AccountDTO account)
//    {
//        string validationAccount = await validateAccount(account);


//        if (!validationAccount.Equals("Valid"))
//        {
//            return BadRequest(new { message = validationAccount });
//        }

//        var newAccount = await _service.Create(account);
//        return CreatedAtAction(nameof(GetById), new { id = newAccount.Id }, newAccount);
//    }

//    [HttpPut("{id}")]
//    public async Task<IActionResult> Update(int id, AccountDTO account)
//    {
//        if (id != account.Id)
//        {
//            return BadRequest(new { message = $"el ID({id}) De la url no coincide con el id({account.Id}) del cuerpo de la solicitud" });
//        }

//        string validationAccount = await validateAccount(account);


//        if (!validationAccount.Equals("Valid"))
//        {
//            return BadRequest(new { message = validationAccount });
//        }

//        //TO DO verificar codigo duplicado
//        var accountToUpdate = await _service.GetById(id);

//        if (accountToUpdate is not null) { 
//            await _service.Update(account);
//            return NoContent();
//        }
//        else return AccountNotFound(id);


//        return NoContent();
//    }

//    [HttpDelete("{id}")]
//    public async Task<IActionResult> Delete(int id)
//    {


//        var accountToDelete = await _service.GetById(id);

//        if (accountToDelete is not null)
//        {
//            await _service.Delete(id);
//            return Ok();
//        }
//        else return AccountNotFound(id);
//    }
//    [NonAction]
//    public NotFoundObjectResult AccountNotFound(int id)
//    {
//        return NotFound(new { message = $"La cuenta con id = {id} no existe" });
//    }
//    [NonAction]
//    public async Task<string> validateAccount(AccountDTO account)
//    {

//        string result = "Valid";

//        var accType = await typeAccountService.GetById(account.AccountTypeId);

//        if (accType is null)
//        {
//            result = $"El tipo de cuenta {account.AccountTypeId} no existe";
//        }

//        var clientID = account.ClientId.GetValueOrDefault();
//        var client = await clientService.GetById(clientID);

//        if (client is null)
//            result = $"el cliente {clientID} no existe";
//        return result;
//    }



//}