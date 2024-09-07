using Company.Service._Services.Employee.Dto;

namespace Company.Service._Services.Department.Dto
{
    public class DepartmentDpo
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public ICollection<EmployeeDTO> employees { get; set; } = new List<EmployeeDTO>();
    }
}
