using EasyDeals.Data.Models;

namespace EasyDeals.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
