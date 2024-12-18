using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace project2.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(string name, string password)
        {
            // Fetch the user from the database (check if the username and password match)
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Name == name && u.Password == password); // In production, hash the password!

            if (user != null)
            {
                // Store user data in session
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetInt32("UserRole", user.Role);

                // Redirect based on user role
                if (user.Role == 1)  // Admin role
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (user.Role == 2)  // User role
                {
                    return RedirectToAction("EmployeeView", "Home");
                }
            }

            // If login fails
            ViewData["Error"] = "Invalid username or password";
            return View();
        }

        // Logout action to clear session
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();  // Clear the session on logout
            return RedirectToAction("Login", "Account");
        }
    }
}
