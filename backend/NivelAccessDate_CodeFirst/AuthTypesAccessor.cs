using LibrarieModele;
using Microsoft.EntityFrameworkCore;
using Repository_CodeFirst;

namespace NiveAccessDate_CodeFirst;

public class AuthTypesAccessor
{
    public List<AuthType> GetAuthTypes()
    {
        using (var context = new ForumContext())
        {
            return context.AuthTypes.ToList();
        }
    }
}
