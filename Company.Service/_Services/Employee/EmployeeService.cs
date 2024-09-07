using AutoMapper;
using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service._Interfaces;
using Company.Service._Services.Employee.Dto;
using Company.Service.Helper;


namespace Company.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(EmployeeDTO employeeDto)
        {
            //Manual Mapping
            //Employee MappedEmployee = new Employee
            //{
            //  Address = employeeDto.Address,
            //  Age = Convert.ToInt32((DateTime.Now - employeeDto.HiringDate).TotalDays / 365),
            //  DepartmentId = employeeDto.DepartmentId,
            //  Email = employeeDto.Email,
            //  HiringDate = employeeDto.HiringDate,
            //  Name = employeeDto.Name,
            //  Salary = employeeDto.Salary,
            //  ImageURL = employeeDto.ImageURL,
            //  PhoneBook = employeeDto.PhoneBook,
            //};
            employeeDto.ImageURL = DocumentSettings.UploadFile(employeeDto.Image, "Images");
            Employee employee = _mapper.Map<Employee>(employeeDto);
            //Or => Employee employee = _mapper.Map<EmployeeDTO,Employee>(employeeDto);

            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Complete();
        }

        public void Delete(EmployeeDTO employeeDto)
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
            Employee employee = _mapper.Map<Employee>(employeeDto);

            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            //var MappedEmployees = employees.Select(x => new EmployeeDTO
            //{
            //    Address = x.Address,
            //    DepartmentId = x.DepartmentId,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    Name = x.Name,
            //    Salary = x.Salary,
            //    ImageURL = x.ImageURL,
            //    PhoneBook = x.PhoneBook,
            //    Age = Convert.ToInt32((DateTime.Now - x.HiringDate).TotalDays / 365),
            //    Id = x.Id,
            //    CreateAt = x.CreateAt,


            //});
            IEnumerable<EmployeeDTO> MappedEmployees = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);

            return MappedEmployees; 
        }

        public EmployeeDTO GetById(int? id)
        {
            if (id is null)
                return null;
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (employee == null)
                return null;
            //EmployeeDTO employeeDto = new EmployeeDTO
            //{
            //    Address = employee.Address,
            //    Age = Convert.ToInt32((DateTime.Now - employee.HiringDate).TotalDays / 365),
            //    DepartmentId = employee.DepartmentId,
            //    Email = employee.Email,
            //    HiringDate = employee.HiringDate,
            //    Name = employee.Name,
            //    Salary = employee.Salary,
            //    ImageURL = employee.ImageURL,
            //    PhoneBook = employee.PhoneBook,
            //};
            EmployeeDTO employeeDto = _mapper.Map<EmployeeDTO>(employee);

            return employeeDto;
        }

        public IEnumerable<EmployeeDTO> GetEmployeeByName(string name)
        {

            var employees =  _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            //var MappedEmployees = employees.Select(x => new EmployeeDTO
            //{
            //    Address = x.Address,
            //    DepartmentId = x.DepartmentId,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    Name = x.Name,
            //    Salary = x.Salary,
            //    ImageURL = x.ImageURL,
            //    PhoneBook = x.PhoneBook,
            //    Age = Convert.ToInt32((DateTime.Now - x.HiringDate).TotalDays / 365),
            //    Id = x.Id,
            //    CreateAt = x.CreateAt,


            //});
            IEnumerable<EmployeeDTO> MappedEmployees = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);

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
