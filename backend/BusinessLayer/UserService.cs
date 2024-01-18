using NiveAccessDate_CodeFirst;
using LibrarieModele;


namespace BusinessLayer;

public class UserService : IUserService
{
  private readonly IUsersAccessor usersAccessor;
  private readonly ICache cacheManager;
  public UserService(IUsersAccessor usersAccessor, ICache cacheManager)
  {
    this.usersAccessor = usersAccessor;
    this.cacheManager = cacheManager;
  }

  public List<User> Get()
  {
    return usersAccessor.GetUsers();
  }

  public void Create(User user)
  {
    usersAccessor.CreateUser(user);
  }

  public void Delete(int userId)
  {
    usersAccessor.RemoveUser(userId);
    var key = "user" + $"_{userId}";
    cacheManager.Remove(key);
  }

  public User? GetUser(int userId)
  {

    var key = "user_" + $"{userId}";
    if (cacheManager.IsSet(key))
    {
      return cacheManager.Get<User>(key);
    }
    User? user = usersAccessor.GetUserById(userId);
    if (user != null)
    {
      cacheManager.Set(key, user);
    }
    return user;
  }
  public string GetUserRole(int userId)
  {
    var key = "user_role" + $"{userId}";
    if (cacheManager.IsSet(key))
    {
      return cacheManager.Get<string>(key)!;
    }

    User? user = GetUser(userId);
    if (user != null)
    {
      cacheManager.Set(key, user.Role.RoleName);
      return user.Role.RoleName;
    }
    return "";
  }
  public string GetUserAuthType(int userId)
  {
    var key = "user_auth_type" + $"{userId}";
    if (cacheManager.IsSet(key))
    {
      return cacheManager.Get<string>(key)!;
    }

    User? user = GetUser(userId);
    if (user != null)
    {
      cacheManager.Set(key, user.AuthType.AuthTypeName);
      return user.AuthType.AuthTypeName;
    }
    return "";
  }
}
