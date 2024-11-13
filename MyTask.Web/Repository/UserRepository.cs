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
            var query = context.Users.AsQueryable();
            //return await context.Users.ToListAsync();
            var skipResults = (pageNumber - 1) * pageSize;
            query=query.Skip(skipResults).Take(pageSize);

            return await query.ToListAsync();

        }
    }
}
