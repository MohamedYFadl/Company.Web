using Company.Service._Services.Department.Dto;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Company.Service._Services.Employee.Dto
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneBook { get; set; }
        public DateTime HiringDate { get; set; }
        public IFormFile Image { get; set; }
        public string ImageURL { get; set; }
        public DepartmentDpo Department { get; set; }
        public DateTime CreateAt { get; set; }
        public int? DepartmentId { get; set; }
    }
}
