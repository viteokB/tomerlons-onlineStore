using System.Formats.Asn1;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Core;
using OnlineStore.Core.Common;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;
using OnlineStore.Repository.Models;

namespace OnlineStore.Repository.Repository;

public class UserRepository : IUserRepository
{
    private readonly OnlineStoreDbContext _dbContext;

    public UserRepository(OnlineStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<OperationResult<User>> GetUserByIdAsync(int id)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            return OperationResult<User>.Fail($"Пользователь с ID:{id} не найден")!;

        return OperationResult<User>.Success(DatabaseUser.Map(user));
    }

    public async Task<OperationResult<User>> CreateUserAsync(User user, User? creator = null)
    {
        var roleResult = TryCreateRole(user, creator!);

        if (!roleResult.IsSuccess)
        {
            return OperationResult<User>.Fail(roleResult.Message)!;
        }
        
        var userExisit = await GetUserByEmailAsync(user.Email);

        if (userExisit.IsSuccess)
        {
            return OperationResult<User>.Fail($"Пользователь с таким email уже существует")!;
        }
        
        try
        {
            await _dbContext.Users.AddAsync(new DatabaseUser()
            {
                Email = user.Email,
                Role = roleResult.Data,
                HashedPassword = user.HashedPassword,
                CreatedDate = DateTime.Now,
            });

            await _dbContext.SaveChangesAsync();

            return OperationResult<User>.Success(user);
        }
        catch (Exception ex)
        {
            return OperationResult<User>.Fail(ex.Message)!;
        }
    }

    public async Task<OperationResult<User>> UpdateUserAsync(User user, User creatorUser)
    {
        var dbUser = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == user.Id);
        var roleResult = TryCreateRole(user, creatorUser);
        
        if (dbUser == null)
        {
            return OperationResult<User>.Fail("Пользователь для обновления не найден")!;
        }
        if (!roleResult.IsSuccess)
        {
            return OperationResult<User>.Fail(roleResult.Message)!;
        }
        
        dbUser.Email = user.Email;
        dbUser.HashedPassword = user.HashedPassword;
        dbUser.Role = roleResult.Data;
        
        await _dbContext.SaveChangesAsync();
        
        return OperationResult<User>.Success(DatabaseUser.Map(dbUser));
    }

    public async Task<OperationResult> DeleteUserAsync(int id)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(u => u!.Id == id);
        
        if (user == null!)
        {
            return OperationResult.Fail("Такого пользователя не существует");
        }
        try
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Fail(ex.Message);
        }
    }

    public async Task<OperationResult<User>> AuthorizeAsync(string email, string password)
    {
        var dbUser = await _dbContext.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u!.Email == email);

        if (dbUser == null)
        {
            return OperationResult<User>.Fail("Ошибка авторизации");
        }

        if (dbUser!.HashedPassword == password)
        {
            return OperationResult<User>.Success(DatabaseUser.Map(dbUser));
        }

        return OperationResult<User>.Fail("Ошибка авторизации");
    }

    public async Task<OperationResult<List<UserRole>>> GetRolesAsync()
    {
        var roles = await _dbContext.Roles
            .AsNoTracking()
            .OrderBy(r => r.Name)
            .Select(r => new UserRole()
            {
                Id = r.Id,
                Name = r.Name,
            })
            .ToListAsync();

        return OperationResult<List<UserRole>>.Success(roles);
    }

    public async Task<OperationResult<User>> GetUserByEmailAsync(string email)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Email == email);

        if (user == null)
            return OperationResult<User>.Fail($"Пользователь с ID:{email} не найден")!;

        return OperationResult<User>.Success(DatabaseUser.Map(user));
    }

    #region HelpersMethods
    
    private bool CheckIsAdmin(DatabaseUser user)
    {
        return user.Role.Name != "админ";
    }

    private OperationResult<DatabaseRole> TryCreateRole(User user, User creator)
    {
        var role = _dbContext.Roles
            .FirstOrDefault(u => u.Name == user.Role.Name);

        if (role == null)
        {
            return OperationResult<DatabaseRole>.Fail("Несуществующая роль")!;
        }
        if (role!.Name != "клиент")
        {
            if (creator == null!)
            {
                return OperationResult<DatabaseRole>.Fail(
                    "Невозможно выполнить операцию. Нужен администратор")!;
            }
            
            var dbCreator = _dbContext.Users
                .FirstOrDefault(u => u.Id == user.Id);

            if (dbCreator == null)
            {
                return OperationResult<DatabaseRole>.Fail("Такой администратор не существует")!;
            }
                
            if (!CheckIsAdmin(dbCreator!))
            {
                return OperationResult<DatabaseRole>.Fail("Не хватает прав для выполнения операции")!;
            }
        }
        
        return OperationResult<DatabaseRole>.Success(role);
    }
    
    #endregion
}