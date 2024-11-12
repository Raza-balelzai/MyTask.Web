using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyTask.Web.Data;
using MyTask.Web.Models.Domain;
using MyTask.Web.Models.ViewModels;

namespace MyTask.Web.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext context;

        public LoginRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<User> FindUserAsync(LoginViewModel loginViewModel)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == loginViewModel.UserEmail);

            if (user != null)
            {
                var PH = new PasswordHasher<User>();
                var output = PH.VerifyHashedPassword(user, user.Password, loginViewModel.Password);
                if (output == PasswordVerificationResult.Success)
                {
                    return user;  
                }
            }
            return null;
        }
    }
}
