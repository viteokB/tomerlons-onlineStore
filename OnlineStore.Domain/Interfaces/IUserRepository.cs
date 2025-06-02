using OnlineStore.Core.Common;

namespace OnlineStore.Core.Interfaces;

public interface IUserRepository
{
    public Task<OperationResult<User>> GetUserByIdAsync(int id);

    public Task<OperationResult<User>> GetUserByEmailAsync(string email);

    public Task<OperationResult<User>> CreateUserAsync(User user, User? creator = null);
    
    public Task<OperationResult<User>> UpdateUserAsync(User user, User creatorUser);
    
    public Task<OperationResult> DeleteUserAsync(int id);
    
    public Task<OperationResult<User>> AuthorizeAsync(string email, string password);
    
    public Task<OperationResult<List<UserRole>>> GetRolesAsync();
}