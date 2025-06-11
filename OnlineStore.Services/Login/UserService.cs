using OnlineStore.Core;
using OnlineStore.Core.Common;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;

namespace OnlineStore.Services.Login;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<OperationResult<User>> Login(string email, string password)
    {
        return await _repository.AuthorizeAsync(email, password);
    }

    public async Task<OperationResult<User>> Register(string email, string password, string role)
    {
        return await _repository.CreateUserAsync(new User()
        {
            Email = email,
            Role = new UserRole()
            {
                Name = role
            },
            HashedPassword = password
        });
    }

    public async Task<OperationResult<List<UserRole>>> GetUserRoles()
    {
        return await _repository.GetRolesAsync();
    }
}