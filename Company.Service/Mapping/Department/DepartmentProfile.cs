using AutoMapper;
using Company.Data.Entities;
using Company.Service._Services.Department.Dto;

namespace Company.Service.Mapping
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department,DepartmentDpo>().ReverseMap();
        }
    }
}
