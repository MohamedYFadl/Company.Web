using Company.Data.Contexts;
using Company.Data.Entities;
using Company.Repository.Interfaces;

namespace Company.Repository.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>,IEmployeeRepository
    {
        private readonly CompanyDbContext _context;

        public EmployeeRepository(CompanyDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployeesByAddress(string address)
        {
            return _context.employees.Where(x => x.Address == address).ToList();
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
                => _context.employees.Where(x=>
                x.Name.Trim().ToLower().Contains(name.Trim().ToLower())||
                x.Email.Trim().ToLower().Contains(name.Trim().ToLower())||
                x.PhoneBook.Trim().ToLower().Contains(name.Trim().ToLower())
                ).ToList();


        //public void Add(Employee employee)
        //    => _context.Add(employee);

        //public void Delete(Employee employee)
        //    =>  _context.Remove(employee);
        //public IEnumerable<Employee> GetAll()
        //    => _context.employees.ToList();
        //public Employee GetById(int id)
        //    => _context.employees.Find(id);

        //public void Update(Employee employee)
        //    => _context.employees.Update(employee);

    }
}
