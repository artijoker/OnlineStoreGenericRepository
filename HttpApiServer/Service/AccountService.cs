using HttpModels;

namespace HttpApiServer;

public class AccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task AddAccount(Account account)
    {

        account.Id = Guid.NewGuid();
        await _accountRepository.Add(account);
    }

    public Task<bool> IsEmailExist(string email)
    {
        return _accountRepository.IsEmailExist(email);
    }

    public Task<bool> IsLoginExist(string login)
    {
        return _accountRepository.IsLoginExist(login);
    }
}