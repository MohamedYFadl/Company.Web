 using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Repository.Repositories;
using Company.Service._Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service._Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void Add(Department department)
        {
            var MappedDepartments = new Department { 
            Name = department.Name,
            Code = department.Code,
            CreateAt = DateTime.Now,
            };
            _departmentRepository.Add(MappedDepartments);
        }

        public void Delete(Department department)
        {

            _departmentRepository.Delete(department);
        }

        public IEnumerable<Department> GetAll()
        {
            var departments = _departmentRepository.GetAll();
            return departments;
        }

        public Department GetById(int? id)
        {
            if (id is null)
                return null;
            var department = _departmentRepository.GetById(id.Value);
            if (department == null)
                return null;

            return department;
        }

        public void Update(Department department)
        {
            _departmentRepository.Update(department);
        }
    }
}
