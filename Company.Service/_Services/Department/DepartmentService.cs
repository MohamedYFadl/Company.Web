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
        private readonly DepartmentRepository _departmentRepository;

        public DepartmentService(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void Add(Department department)
        {
            _departmentRepository.Add(department);
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

        public Department GetById(int id)
        {
           return _departmentRepository.GetById(id);
        }

        public void Update(Department department)
        {
            _departmentRepository.Update(department);
        }
    }
}
