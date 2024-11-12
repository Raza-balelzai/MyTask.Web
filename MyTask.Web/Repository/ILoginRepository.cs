using MyTask.Web.Models.Domain;
using MyTask.Web.Models.ViewModels;

namespace MyTask.Web.Repository
{
    public interface ILoginRepository
    {
        Task<User> FindUserAsync(LoginViewModel loginViewModel);
    }
}
