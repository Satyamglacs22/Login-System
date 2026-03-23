using BCrypt.Net;
using LoginformAspCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using System.Diagnostics;

namespace LoginformAspCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserDBContext _context;

        public HomeController(UserDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return RedirectToAction("DashBoard");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserTable user)
        {
            ModelState.Remove("Name");
            ModelState.Remove("Gender");
            ModelState.Remove("Age");

            if (ModelState.IsValid)
            {
                var existingUser = _context.Users
                    .FirstOrDefault(x => x.Email.ToLower() == user.Email.ToLower());

                if (existingUser == null)
                {
                    ViewBag.error = "No account found with this email.";
                }
                else if (!BCrypt.Net.BCrypt.Verify(user.Password, existingUser.Password))
                {
                    ViewBag.error = "Invalid password.";
                }
                else
                {
                    HttpContext.Session.SetString("username", existingUser.Name!);
                    HttpContext.Session.SetInt32("userid", existingUser.Id);
                    return RedirectToAction("DashBoard");
                }
            }

            return View();
        }

        public IActionResult DashBoard()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                ViewBag.MyUser = HttpContext.Session.GetString("username");
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult SignUp()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return RedirectToAction("DashBoard");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(UserTable user)
        {
            if (ModelState.IsValid)
            {
                
                bool emailExists = _context.Users
                    .Any(x => x.Email.ToLower() == user.Email.ToLower());

                if (emailExists)
                {
                    ModelState.AddModelError("Email", "An account with this email already exists.");
                    return View(user);
                }

               
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                _context.Users.Add(user);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Account created successfully! Please sign in.";
                return RedirectToAction("Login");
            }
            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}