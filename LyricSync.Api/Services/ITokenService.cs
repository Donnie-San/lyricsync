using LyricSync.Models;

namespace LyricSync.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
