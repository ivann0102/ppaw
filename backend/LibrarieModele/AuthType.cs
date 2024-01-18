using System;
using System.Collections.Generic;

namespace LibrarieModele;

public class AuthType
{
    public int AuthTypeId { get; set; }

    public string AuthTypeName { get; set; }

    public int Limitation { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
    
}
