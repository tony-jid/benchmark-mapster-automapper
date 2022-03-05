using System;
using System.Collections.Generic;
using System.Text;
using Mapster;
using BenchmarkMapper.Domains;
using BenchmarkMapper.Domains.CodeGen;

namespace BenchmarkMapper
{
    public static class MapsterDemo
    {
        private static TypeAdapterConfig _adapterConfig;

        public static void InitConfig()
        {
            _adapterConfig = new TypeAdapterConfig();
            _adapterConfig.NewConfig<Employee, EmployeeCodeGenDto>();
        }

        public static IList<EmployeeDto> MapEmployees(IList<Employee> employees)
        {
            IList<EmployeeDto> employeeDtos = new List<EmployeeDto>();

            foreach (var emp in employees)
            {
                employeeDtos.Add(emp.Adapt<EmployeeDto>());
            }

            return employeeDtos;
        }

        public static IList<EmployeeCodeGenDto> MapEmployees_WithConfig(IList<Employee> employees)
        {
            IList<EmployeeCodeGenDto> employeeDtos = new List<EmployeeCodeGenDto>();
            if (_adapterConfig == null) InitConfig();

            foreach (var emp in employees)
            {
                employeeDtos.Add(emp.Adapt<EmployeeCodeGenDto>(_adapterConfig));
            }

            return employeeDtos;
        }

        public static IList<EmployeeCodeGenDto> MapEmployees_WithCodeGenMapper(IList<Employee> employees)
        {
            IList<EmployeeCodeGenDto> employeeDtos = new List<EmployeeCodeGenDto>();

            foreach (var emp in employees)
            {
                employeeDtos.Add(emp.AdaptToCodeGenDto());
            }

            return employeeDtos;
        }
    }
}
