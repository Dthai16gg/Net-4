using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_Application.Models;

namespace Web_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var content = HttpContext.Session.GetString("Key");
            ViewData["content"] = content;
            return View();
        }

        public IActionResult TransferData()
        {
            /*
             * Ngoai cach truyen truc tiep obj model thi chung ta co the truyen du lieu thong qua cac cach sau
             * cach 1 : su dung view data :truyen du lieu dua theo viewdata theo dang key-value moi mot view data la mot
             * ten key coa the luu tru duoc mot kieu du lieu (generic)
             */
            //example 
            List<string> test_string = new List<string>()
            {
                "a","b","c","D"
            };
            ViewData["STRING"] = test_string;
            //cach 2 
            /*
             *Viewbag khong can khoi tao ma co the dat tenn luon cho thanh phan vi do la abstract du lieu trong viewbag la dynamic
             */
            /*
             *cach 3 du dung session(Phien lam viec)
             * De su dung session can phai cau hinh o program.cs
             */
            double[] marks = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0.1, 2.3 };
            ViewBag.Marks = marks;
            string message = "a-----------b------------c--------------d";
            //Day du lieu vao session
            HttpContext.Session.SetString("Key", message);
            //Lay du lieu ra
            var content = HttpContext.Session.GetString("Key");
            ViewData["content"] = content;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}