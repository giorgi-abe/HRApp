using ApplicationDatabaseModels;
using ApplicationDatabaseModels.User;
using ApplicationDtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<User, UserDto>()
                .ForMember(o => o.Employees, d => d.MapFrom(a => a.Employees))
                .ReverseMap();
        }
    }
}