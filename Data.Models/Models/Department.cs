using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Models
{
    public class Department:BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> employees { get; set; } = new List<Employee>(); 
    }
}
