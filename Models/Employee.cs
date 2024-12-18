using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace project2.Models
{
    public class Employee
    {
        public int? EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? CompanyId { get; set; }  // Foreign Key to Company
        public int? DepartmentId { get; set; }  // Foreign Key to Department
        public int? Status { get; set; }
    }
}
