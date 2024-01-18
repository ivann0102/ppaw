using LibrarieModele;
using Microsoft.EntityFrameworkCore;
using Repository_CodeFirst;

namespace NiveAccessDate_CodeFirst;

public class UsersAccessor : IUsersAccessor
{

  private readonly ForumContext context;
  public UsersAccessor(ForumContext context)
  {
    this.context = context;
  }
  public List<User> GetUsers()
  {
    return context.Users.Include(user => user.AuthType).Include(user => user.Role).ToList();
  }

  public User? GetUserById(int id)
  {
    return context.Users
      .Include(u => u.Role)
      .Include(u => u.AuthType)
      .FirstOrDefault(user => user.UserId == id);
  }

  public void CreateUser(User user)
  {
    context.Users.Add(user);
    context.SaveChanges();
  }
  public List<Role> GetRoles()
  {
    return context.Roles.ToList();
  }

  public void RemoveUser(int userId)
  {
    User? user = context.Users.FirstOrDefault(u => u.UserId == userId);
    if (user != null)
    {
      context.Users.Remove(user);
      context.SaveChanges();
    }
  }

}
