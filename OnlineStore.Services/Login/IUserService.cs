using OnlineStore.Core;

namespace OnlineStore.Services.Login;

public interface IUserService
{
    User Login(string username, string password);
    
    User Register(string username, string password, string role);
}