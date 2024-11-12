using MyTask.Web.Models.Domain;
using System.Drawing.Printing;

namespace MyTask.Web.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync(int pageNumber = 1,int pageSize=100);
        Task<int> CountAsync();
    }
}
