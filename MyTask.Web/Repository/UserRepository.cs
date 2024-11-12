using Microsoft.EntityFrameworkCore;
using MyTask.Web.Data;
using MyTask.Web.Models.Domain;

namespace MyTask.Web.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CountAsync()
        {
            return await context.Users.CountAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(int pageNumber = 1,int pageSize=100)
        {
            //return await context.Users.ToListAsync();
            var query = context.Users.AsQueryable();
            var skipResults = (pageNumber - 1) * pageSize;
            var users = await context.Users.Skip(skipResults).Take(pageSize).ToListAsync();

            return (users);

        }
    }
}
