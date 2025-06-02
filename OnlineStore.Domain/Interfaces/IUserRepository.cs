using OnlineStore.Core.Common;

namespace OnlineStore.Core.Interfaces;

public interface IUserRepository
{
    public Task<OperationResult<User>> GetUserById(int id);

    public Task<OperationResult<User>> CreateUser(User user, User? creator = null);
    
    public Task<OperationResult<User>> UpdateUser(User user, User creatorUser);
    
    public Task<OperationResult> DeleteUser(int id);
    
    public Task<OperationResult<User>> Authorize(string email, string password);
    
    public Task<OperationResult<List<UserRole>>> GetRoles();
}