using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service._Interfaces;
using Company.Service._Services.Employee.Dto;


namespace Company.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(EmployeeDTO employeeDto)
        {
            //Manual Mapping
            Employee MappedEmployee = new Employee
            {
              Address = employeeDto.Address,
              Age = Convert.ToInt32((DateTime.Now - employeeDto.HiringDate).TotalDays / 365),
              DepartmentId = employeeDto.DepartmentId,
              Email = employeeDto.Email,
              HiringDate = employeeDto.HiringDate,
              Name = employeeDto.Name,
              Salary = employeeDto.Salary,
              ImageURL = employeeDto.ImageURL,
              PhoneBook = employeeDto.PhoneBook,
            };
            _unitOfWork.EmployeeRepository.Add(MappedEmployee);
            _unitOfWork.Complete();
        }

        public void Delete(EmployeeDTO employeeDto)
        {
            Employee MappedEmployee = new Employee
            {
                Address = employeeDto.Address,
                Age = Convert.ToInt32((DateTime.Now - employeeDto.HiringDate).TotalDays / 365),
                DepartmentId = employeeDto.DepartmentId,
                Email = employeeDto.Email,
                HiringDate = employeeDto.HiringDate,
                Name = employeeDto.Name,
                Salary = employeeDto.Salary,
                ImageURL = employeeDto.ImageURL,
                PhoneBook = employeeDto.PhoneBook,
            };
            _unitOfWork.EmployeeRepository.Delete(MappedEmployee);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            var MappedEmployees = employees.Select(x => new EmployeeDTO
            {
                Address = x.Address,
                DepartmentId = x.DepartmentId,
                Email = x.Email,
                HiringDate = x.HiringDate,
                Name = x.Name,
                Salary = x.Salary,
                ImageURL = x.ImageURL,
                PhoneBook = x.PhoneBook,
                Age = Convert.ToInt32((DateTime.Now - x.HiringDate).TotalDays / 365),
                Id = x.Id,
                CreateAt = x.CreateAt,


            });
            return MappedEmployees; 
        }

        public EmployeeDTO GetById(int? id)
        {
            if (id is null)
                return null;
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (employee == null)
                return null;
            EmployeeDTO employeeDto = new EmployeeDTO
            {
                Address = employee.Address,
                Age = Convert.ToInt32((DateTime.Now - employee.HiringDate).TotalDays / 365),
                DepartmentId = employee.DepartmentId,
                Email = employee.Email,
                HiringDate = employee.HiringDate,
                Name = employee.Name,
                Salary = employee.Salary,
                ImageURL = employee.ImageURL,
                PhoneBook = employee.PhoneBook,
            };
            return employeeDto;
        }

        public IEnumerable<EmployeeDTO> GetEmployeeByName(string name)
        {

            var employees =  _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            var MappedEmployees = employees.Select(x => new EmployeeDTO
            {
                Address = x.Address,
                DepartmentId = x.DepartmentId,
                Email = x.Email,
                HiringDate = x.HiringDate,
                Name = x.Name,
                Salary = x.Salary,
                ImageURL = x.ImageURL,
                PhoneBook = x.PhoneBook,
                Age = Convert.ToInt32((DateTime.Now - x.HiringDate).TotalDays / 365),
                Id = x.Id,
                CreateAt = x.CreateAt,


            });
            return MappedEmployees;
        }
        

        public void Update(EmployeeDTO employeeDto)
        {
            //Employee MappedEmployee = new Employee
            //{
            //    Address = employeeDto.Address,
            //    Age = Convert.ToInt32((DateTime.Now - employeeDto.HiringDate).TotalDays / 365),
            //    DepartmentId = employeeDto.DepartmentId,
            //    Email = employeeDto.Email,
            //    HiringDate = employeeDto.HiringDate,
            //    Name = employeeDto.Name,
            //    Salary = employeeDto.Salary,
            //    ImageURL = employeeDto.ImageURL,
            //    PhoneBook = employeeDto.PhoneBook,
            //};
            //_unitOfWork.EmployeeRepository.Update(MappedEmployee);
            _unitOfWork.Complete();

        }
    }
}
