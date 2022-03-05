using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BenchmarkMapper.Domains;

namespace BenchmarkMapper
{
    public static class AutoMapperDemo
    {
        private static MapperConfiguration _mapperConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<Employee, EmployeeDto>();
        });

        public static IList<EmployeeDto> MapEmployees(IList<Employee> employees)
        {
            var _mapper = new Mapper(_mapperConfig);
            IList<EmployeeDto> employeeDtos = new List<EmployeeDto>();

            foreach (var emp in employees)
            {
                employeeDtos.Add(_mapper.Map<EmployeeDto>(emp));
            }

            return employeeDtos;
        }
    }
}
