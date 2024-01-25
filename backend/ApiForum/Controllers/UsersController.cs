using BusinessLayer;
using LibrarieModele;
using Microsoft.AspNetCore.Mvc;
using NiveAccessDate_CodeFirst;

namespace ApiForum;

[ApiController]
[Route("/api/[controller]")]
public class UsersController : Controller
{
  private IUserService userService;

  public UsersController(IUserService userService)
  {
    this.userService = userService;
  }

  [HttpGet()]
  public IEnumerable<UserViewModel> Get()
  {
    List<User> users = userService.Get();
    var usersModels = users.Select(u => new UserViewModel(u)).ToList();
    return usersModels;
  }

  [HttpPost()]
  public void Create(UserViewModel user)
  {
    List<User> users = userService.Get();
    var usersModels = users.Select(u => new UserViewModel(u)).ToList();
    userService.Create(
        new User()
        {
          UserName = user.UserName,
          AuthTypeId = (int)user.AuthTypeId,
          RoleId = (int)user.RoleId,
          Email = user.Email,
          ImageLink = user.ImageLink,
          PasswordHash = user.PasswordHash,
        });
  }

  [HttpDelete("{userId:int}")]
  public void DeleteUser(int userId)
  {
    userService.Delete(userId);
  }

  [HttpPost("login")]
  public UserViewModel? Login(LoginViewModel user)
  {
    if(userService.IsValidUser(user.UserName, user.Password)){
      return new UserViewModel(userService.GetUserByName(user.UserName));
    }
    return null;
  }


}

