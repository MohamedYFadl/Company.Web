using Company.Service._Services.Department.Dto;

namespace Company.Service._Interfaces
{
    public interface IDepartmentService
    {
        DepartmentDpo GetById(int? id);
        IEnumerable<DepartmentDpo> GetAll();
        void Add(DepartmentDpo department);
        void Update(DepartmentDpo department);
        void Delete(DepartmentDpo department);
    }
}
