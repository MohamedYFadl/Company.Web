using Company.Data.Contexts;
using Company.Data.Entities;
using Company.Repository.Interfaces;


namespace Company.Repository.Repositories
{
    public class DepartmentRepository :GenericRepository<Department>, IDepartmentRepository
    {
        //private readonly CompanyDbContext _context;

        public DepartmentRepository(CompanyDbContext context):base(context)  
        {
            //_context = context;
        }
        //public void Add(Department department)
        //    => _context.departments.Add(department);
        

        //public void Delete(Department department)
        //    => _context.departments.Remove(department);


        //public IEnumerable<Department> GetAll()
        //     => _context.departments.ToList();
        //public Department GetById(int id)
        //    => _context.departments.Find(id);


        //public void Update(Department department)
        //  => _context.departments.Update(department);


    }
}
