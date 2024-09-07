using AutoMapper;
using Company.Data.Entities;
using Company.Service._Services.Employee.Dto;

namespace Company.Service.Mapping
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
