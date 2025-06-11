using OnlineStore.Core;
using OnlineStore.Core.Common;
using OnlineStore.Core.Models;

namespace OnlineStore.Services.Login;

public interface IUserService
{
    Task<OperationResult<User>> Login(string email, string password);
    
    Task<OperationResult<User>> Register(string email, string password, string role);
    
    Task<OperationResult<List<UserRole>>> GetUserRoles();
}