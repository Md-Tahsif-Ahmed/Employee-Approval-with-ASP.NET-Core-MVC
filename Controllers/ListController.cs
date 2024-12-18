using Microsoft.AspNetCore.Mvc;
using project2.Models;

namespace project2.Controllers
{
    public class ListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCompany()
        {
            var companies = _context.Companies.Select(c => new { c.Id, c.Name }).ToList();
            return Json(companies);
        }

        // Get departments for a specific company
        public IActionResult GetDepartment(int id)
        {
            var departments = _context.Departments
                                      .Where(d => d.CompanyId == id)
                                      .Select(d => new { d.Id, d.Name })
                                      .ToList();
            return Json(departments);
        }
    }
}
