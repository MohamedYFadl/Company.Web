﻿using Company.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service._Interfaces
{
    public interface IEmployeeService
    {
        Employee GetById(int id);
        IEnumerable<Employee> GetAll();
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
    }
}