using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkMapper.Domains
{
    [AdaptTo("[name]CodeGenDto"), GenerateMapper]
    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
    }
}
