using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Application.IServices;
using Web_Application.Models;
using Web_Application.Services;

namespace Web_Application.Controllers
{
    public class UserController : Controller
    {
        private IUserServices _userServices;

        public UserController()
        {
            _userServices = new UserServices();
        }
        public IActionResult ShowListUser()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult SearchByUsername()
        {
            return View();
        }
        public IActionResult GetByID()
        {
            return View();
        }
        public IActionResult MyAccount()
        {
            return View();
        }
        //login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            IEnumerable<User> User = _userServices.GetAllUsers().Where(p => p.Username == user.Username);
            if (User.Count() != 0)
            {
                if (User.First().Password == user.Password)
                {
                    return View("_Layout");
                }
            }
            return View("Login");
        }
    }
}
