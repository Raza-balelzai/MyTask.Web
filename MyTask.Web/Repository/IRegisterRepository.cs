using MyTask.Web.Models.Domain;

namespace MyTask.Web.Repository
{
    public interface IRegisterRepository
    {
        Task<User> AddUserAsync(User user);
    }
}
