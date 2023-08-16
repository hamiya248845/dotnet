using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Registration.Data;
using Registration.Model;
using Registration.Services;

public class UserService : IUserService
{
    private readonly DbContextClass _dbContext;

    public UserService(DbContextClass dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> Register(RegisterModel registerModel)
    {
        // Check if the email is already registered
        if (await _dbContext.Users.AnyAsync(u => u.Email == registerModel.Email))
        {
            return "Email already registered.";
        }

        var newUser = new User
        {
            Email = registerModel.Email,
            Password = registerModel.Password
        };

        _dbContext.Users.Add(newUser);
        await _dbContext.SaveChangesAsync();

        return "Registration successful.";
    }

    public async Task<User> Login(LoginModel loginModel)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == loginModel.Email);

        if (user == null || user.Password != loginModel.Password)
        {
            return null;
        }

        return user;
    }

    public class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
