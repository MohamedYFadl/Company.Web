using Company.Service._Services.Employee.Dto;

namespace Company.Service._Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDTO GetById(int? id);
        IEnumerable<EmployeeDTO> GetAll();
        void Add(EmployeeDTO employee);
        void Update(EmployeeDTO employee);
        void Delete(EmployeeDTO employee);
        public IEnumerable<EmployeeDTO> GetEmployeeByName(string name);

    }
}
