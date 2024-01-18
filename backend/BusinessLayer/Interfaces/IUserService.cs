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

}

