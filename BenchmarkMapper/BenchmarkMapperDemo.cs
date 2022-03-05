using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkMapper.Domains;

namespace BenchmarkMapper
{
    [MemoryDiagnoser]
    public class BenchmarkMapperDemo
    {
        private static readonly string[] Names = new[]
        {
            "Tony", "Tom", "Sandy", "Peter", "Mark", "Bob"
        };

        private static readonly string[] Departments = new[]
        {
            "IT", "HR", "ACT", "FNC", "MRK", "ORG"
        };

        int _loopCount = 1000;

        IList<Employee> _employees;

        public BenchmarkMapperDemo()
        {
            _employees = GetDummyEmployees();
            MapsterDemo.InitConfig();
        }

        [Benchmark]
        public void AutoMapper_MapEmployees()
        {
            AutoMapperDemo.MapEmployees(_employees);
        }

        [Benchmark]
        public void Mapster_MapEmployees()
        {
            MapsterDemo.MapEmployees(_employees);
        }

        [Benchmark]
        public void Mapster_MapEmployees_WithConfig()
        {
            MapsterDemo.MapEmployees_WithConfig(_employees);
        }

        [Benchmark]
        public void Mapster_MapEmployees_WithCodeGenMapper()
        {
            MapsterDemo.MapEmployees_WithCodeGenMapper(_employees);
        }

        public IList<Employee> GetDummyEmployees()
        {
            Random random = new Random();
            IList<Employee> emps = new List<Employee>();
            for (int i = 0; i < _loopCount; i++)
            {
                emps.Add(new Employee()
                {
                    Name = Names[random.Next(Names.Length)],
                    Department = Departments[random.Next(Departments.Length)],
                    Salary = random.Next(10000, 50000)
                });
            }

            return emps;
        }
    }
}
