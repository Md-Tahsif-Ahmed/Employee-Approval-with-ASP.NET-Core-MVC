using Microsoft.AspNetCore.Mvc;
using project2.Models;
using System.Diagnostics;

namespace project2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; 
        }


        public IActionResult AdminDashboard()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            int? userRole = HttpContext.Session.GetInt32("UserRole");

            if (userId == null || userRole != 1)  // Ensure the user is an admin
            {
                return RedirectToAction("Login", "Account");
            }

            return View();  // Render the Admin dashboard
        }


        public IActionResult Index()
        {
            var data = _context.Companies.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult EmployeeView()
        {
            // Fetch the list of employees from the database
            var data = _context.Employees
                    .ToList();

            // Pass the data (list of employees) to the view
            return View("Employee", data);  // "Employee" is the name of the view and 'data' will be the model
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}