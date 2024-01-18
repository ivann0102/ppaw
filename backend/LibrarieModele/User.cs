using System;
using System.Collections.Generic;

namespace LibrarieModele;

public class User
{
    public int UserId { get; set; }

    public string UserName { get; set; }

    public int AuthTypeId { get; set; }

    public int RoleId { get; set; }

    public string? Email { get; set; }

    public string? ImageLink { get; set; }

    public string PasswordHash { get; set; }

    public AuthType AuthType { get; set; }

    public ICollection<Post> Posts { get; set; } = new List<Post>();

    public Role Role { get; set; }

    public bool IsDeleted { get; set; }
}
