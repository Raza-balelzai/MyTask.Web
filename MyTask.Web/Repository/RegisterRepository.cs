using MyTask.Web.Data;
using MyTask.Web.Models.Domain;

namespace MyTask.Web.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly AppDbContext context;

        public RegisterRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}
