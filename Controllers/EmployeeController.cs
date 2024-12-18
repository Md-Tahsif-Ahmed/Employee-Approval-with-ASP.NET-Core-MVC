using Microsoft.AspNetCore.Mvc;
using project2.Models;

namespace project2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("SaveAllEmployees")]
        public async Task<IActionResult> SaveAllEmployees([FromBody] List<Employee> employees)
        {
            if (employees == null || !employees.Any())
            {
                return BadRequest("No employees provided.");
            }

            try
            {
                await _context.Employees.AddRangeAsync(employees);
                await _context.SaveChangesAsync();

                // Return a simple direct response as a string
                return Ok("All employees have been saved successfully.");
            }
            catch (Exception ex)
            {
                // Return the error message directly
                return StatusCode(500, $"Error saving employees: {ex.Message}");
            }
        }

        // Get Employees
        public IActionResult GetEmployees()
        {
            var employees = _context.Employees
                                    .Select(e => new
                                    {
                                        e.EmployeeId,
                                        e.Name,
                                        e.Phone,
                                        e.Address,
                                        e.Status  // Include the Status field
                                    })
                                    .ToList();

            return Json(employees);
        }

        // Approve Employee
        [HttpPost]
        public IActionResult ApproveEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            // Set the Status to 1 (approved)
            employee.Status = 1;

            // Save changes to the database
            _context.SaveChanges();

            // Return the updated employee status
            return Json(new { success = true, employeeId = id, status = employee.Status });
        }




        // Delete Employee
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            // Return a success response
            return Json(new { success = true, employeeId = id });
        }



    }
}
