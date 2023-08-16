using Registration.Model;
using static UserService;

namespace Registration.Services
{
    public interface IUserService
    {
        Task<string> Register(RegisterModel registerModel);
        Task<User> Login(LoginModel loginModel);
    }

    
}
