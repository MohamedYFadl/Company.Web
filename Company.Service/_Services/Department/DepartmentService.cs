 using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Repository.Repositories;
using Company.Service._Interfaces;
using Company.Service._Services.Department.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service._Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(DepartmentDpo department)
        {
            var MappedDepartments = new DepartmentDpo
            { 
            Name = department.Name,
            Code = department.Code,
            CreateAt = DateTime.Now,
            };
            _unitOfWork.DepartmentRepository.Add(MappedDepartments);
            _unitOfWork.Complete();

        }

        public void Delete(DepartmentDpo department)
        {

            _unitOfWork.DepartmentRepository.Delete(department);
            _unitOfWork.Complete();
        }

        public IEnumerable<DepartmentDpo> GetAll()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            return departments;
        }

        public DepartmentDpo GetById(int? id)
        {
            if (id is null)
                return null;
            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            if (department == null)
                return null;

            return department;
        }

        public void Update(DepartmentDpo department)
        {
            _unitOfWork.DepartmentRepository.Update(department);
            _unitOfWork.Complete();

        }
    }
}
