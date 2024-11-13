using Microsoft.AspNetCore.Mvc;
using MyTask.Web.Models;
using MyTask.Web.Models.ViewModels;
using MyTask.Web.Repository;
using System.Diagnostics;

namespace MyTask.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository userRepository;

        public HomeController(ILogger<HomeController> logger,IUserRepository userRepository)
        {
            _logger = logger;
            this.userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index( int pageSize = 3,int pageNumber=1)
        {
            var totalRecords=await userRepository.CountAsync();
            var totalPages = Math.Ceiling((decimal)totalRecords / pageSize);
            ViewBag.TotalPages=totalPages;
            if (HttpContext.Session.GetString("UserKey") != null) {

                var users=await userRepository.GetAllUsersAsync(pageNumber,pageSize);
                var userViewModel=new List<UsersListViewModel>();
                foreach (var user in users) 
                {
                    userViewModel.Add(new UsersListViewModel 
                    {
                        UserName = user.UserName,
                        UserEmail = user.Email
                    });
                }
                return View(userViewModel);
            }
            return RedirectToAction("Login","Account");
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
