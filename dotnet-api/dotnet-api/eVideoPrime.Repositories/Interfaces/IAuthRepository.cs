
using eVideoPrime.Core.Entities;
using eVideoPrime.Models;

namespace eVideoPrime.Core.Interfaces
{
    public interface IAuthRepository
    {
        UserModel ValidateUser(string Email, string Password);
        bool CreateUser(User user, string Role);
    }
}
