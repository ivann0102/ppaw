using LibrarieModele;
namespace BusinessLayer;
public interface IUserService
{
  void Create(User user);
  void Delete(int userId);
  List<User> Get();
  User? GetUser(int userId);
  string GetUserRole(int userId);
  string GetUserAuthType(int userId);
  bool IsValidUser(string username, string password);
  User? GetUserByName(string username);
}

