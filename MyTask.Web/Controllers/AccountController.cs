using Microsoft.AspNetCore.Mvc;
using MyTask.Web.Models.Domain;
using MyTask.Web.Models.ViewModels;
using MyTask.Web.Repository;
using Microsoft.AspNetCore.Identity;

namespace MyTask.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRegisterRepository registerRepository;
        private readonly ILoginRepository loginRepository;

        public AccountController(IRegisterRepository registerRepository,ILoginRepository loginRepository)
        {
            this.registerRepository = registerRepository;
            this.loginRepository = loginRepository;
        }
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.RegisterSuccess = TempData["RegisterSuccess"];
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.Invalid = "Sorry, Invalid credentials!";
        //        return View();
        //    }
        //    var userFound = await loginRepository.FindUserAsync(loginViewModel);
        //    if (userFound != null)
        //    {
        //        if (userFound.Password == loginViewModel.Password)
        //        {
        //            HttpContext.Session.SetString("UserKey", loginViewModel.UserEmail);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            ViewBag.Invalid = "Sorry, Incorrect password!";
        //        }
        //    }
        //    else
        //    {

        //        ViewBag.RegisterFirst = "Sorry, You are not Registered";
        //    }
        //    return View();
        //}
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Invalid = "Sorry, Invalid credentials!";
                return View();
            }
            var userFound = await loginRepository.FindUserAsync(loginViewModel);
            if (userFound != null)
            {
                var PH = new PasswordHasher<User>();
                var Output = PH.VerifyHashedPassword(userFound, userFound.Password, loginViewModel.Password);
                if (Output == PasswordVerificationResult.Success)
                {
                    HttpContext.Session.SetString("UserKey", loginViewModel.UserEmail);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Invalid = "Sorry, Incorrect password!";
                }
            }
            else
            {
                ViewBag.RegisterFirst = "Sorry, You are not registered!";
            }

            return View();
        }
        [HttpPost]
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserKey") != null)
            {
                HttpContext.Session.Remove("UserKey");
            }
            return RedirectToAction("Login", "Account"); 
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Register(RegisterPostViewModel register)
        {
            if (!ModelState.IsValid) 
            {
                return View();
            }
            //-------------password hashingLine added Here--------------
            var passwordHasher = new PasswordHasher<User>();
            User DomainUser = new User()
            {
                Email = register.Email,
                //Password = register.Password,
                Password = passwordHasher.HashPassword(null, register.Password),
                UserName = register.UserName,
            };
            await registerRepository.AddUserAsync(DomainUser);
            TempData["RegisterSuccess"] = "Registered successfully, now you can log in.";
            return RedirectToAction("Login");
        }
    }
}
