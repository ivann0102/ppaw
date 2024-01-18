using LibrarieModele;

namespace ApiForum;
public class UserViewModel
{
  public int UserId { get; set; }

  public string? UserName { get; set; }

  public string? Email { get; set; }

  public string? ImageLink { get; set; }

  public string? AuthType { get; set; }

  public string? Role { get; set; }

  public string? PasswordHash { get; set; }

  public int? AuthTypeId { get; set; }

  public int? RoleId { get; set; }



  public UserViewModel(User user)
  {
    UserId = user.UserId;
    UserName = user.UserName;
    Email = user.Email != null ? user.Email : "";
    ImageLink = user.ImageLink != null ? user.ImageLink : "";
    AuthType = user.AuthType.AuthTypeName;
    Role = user.Role.RoleName;
  }
  public UserViewModel() { }
}
