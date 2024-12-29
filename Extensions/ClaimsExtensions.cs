using System.Security.Claims;

namespace EasyDeals.Extensions;

public static class ClaimsExtensions
{
    private const string Value = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname";

    public static string GetUsername(this ClaimsPrincipal user)
    {
        return user.Claims.SingleOrDefault(x => x.Type.Equals(Value))!.Value;
    }
}
