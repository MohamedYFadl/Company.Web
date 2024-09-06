using Company.Data.Entities;


namespace Company.Repository.Interfaces
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        //Employee GetById(int id);
        //IEnumerable<Employee> GetAll();
        //void Add(Employee employee);
        //void Update(Employee employee);
        //void Delete(Employee employee);
        IEnumerable<Employee> GetEmployeeByName (string name);
        IEnumerable<Employee> GetAllEmployeesByAddress (string address);
    }
}
