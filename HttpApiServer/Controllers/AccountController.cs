using HttpModels;
using Microsoft.AspNetCore.Mvc;

namespace HttpApiServer.Controllers;

[Route("account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly AccountService _service;

    public AccountController(AccountService service)
    {
        _service = service;
    }

    [HttpPost("add_account")]
    public async Task<ActionResult> AddAccount(Account account)
    {
        if (await _service.IsEmailExist(account.Email))
            return new ContentResult()
            {
                StatusCode = 500,
                Content = "Пользователь с таким email уже существует"
            };

        if (await _service.IsLoginExist(account.Login))
            return new ContentResult()
            {
                StatusCode = 500,
                Content = "Пользователь с таким логином уже существует"
            };

        await _service.AddAccount(account);
        return Ok();
    }
}