using AutoMapper;
using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service._Interfaces;
using Company.Service._Services.Department.Dto;

namespace Company.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(DepartmentDpo departmentDto)
        {
            //var MappedDepartments = new DepartmentDpo
            //{ 
            //Name = department.Name,
            //Code = department.Code,
            //CreateAt = DateTime.Now,
            //};
            var MappedDepartments = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Add(MappedDepartments);
            _unitOfWork.Complete();

        }

        public void Delete(DepartmentDpo departmentDto)
        {
            var MappedDepartments = _mapper.Map<Department>(departmentDto);

            _unitOfWork.DepartmentRepository.Delete(MappedDepartments);
            _unitOfWork.Complete();
        }

        public IEnumerable<DepartmentDpo> GetAll()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            var MappedDepartments = _mapper.Map<IEnumerable<DepartmentDpo>>(departments);
            return MappedDepartments;
        }

        public DepartmentDpo GetById(int? id)
        {
            if (id is null)
                return null;
            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            if (department == null)
                return null;
            var MappedDepartments = _mapper.Map<DepartmentDpo>(department);

            return MappedDepartments;
        }

        public void Update(DepartmentDpo department)
        {
            //_unitOfWork.DepartmentRepository.Update(department);
            //_unitOfWork.Complete();

        }
    }
}
