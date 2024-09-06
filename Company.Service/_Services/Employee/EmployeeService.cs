using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service._Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service._Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Employee employee)
        {
            var MappedEmployee = new Employee
            {
              Email = employee.Email,
              Name = employee.Name,
              Address = employee.Address,
              Age = Convert.ToInt32((DateTime.Now - employee.HiringDate).TotalDays / 365),
              HiringDate = employee.HiringDate,
              Salary = employee.Salary,
              CreateAt = DateTime.Now,
              DepartmentId = employee.DepartmentId,
              ImageURL = employee.ImageURL,
              PhoneBook = employee.PhoneBook,
            };
            _unitOfWork.EmployeeRepository.Add(MappedEmployee);
            _unitOfWork.Complete();
        }

        public void Delete(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            return employees;
        }

        public Employee GetById(int? id)
        {
            if (id is null)
                return null;
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (employee == null)
                return null;

            return employee;
        }

        public void Update(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.Complete();

        }
    }
}
