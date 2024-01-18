using LibrarieModele;

namespace NiveAccessDate_CodeFirst;

public interface IUsersAccessor
{
  List<User> GetUsers();
  User? GetUserById(int id);
  void CreateUser(User user);
  List<Role> GetRoles();
  void RemoveUser(int userId);
}
