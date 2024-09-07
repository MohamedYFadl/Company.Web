using System.ComponentModel.DataAnnotations;

namespace Company.Data.Entities
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneBook { get; set; }
        public DateTime HiringDate { get; set; }
        public string ImageURL { get; set; }
        public Department Department { get; set; }
        public int? DepartmentId { get; set; }

    }
}
