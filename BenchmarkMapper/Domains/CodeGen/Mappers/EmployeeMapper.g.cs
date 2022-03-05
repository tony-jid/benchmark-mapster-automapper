using BenchmarkMapper.Domains;
using BenchmarkMapper.Domains.CodeGen;

namespace BenchmarkMapper.Domains.CodeGen
{
    public static partial class EmployeeMapper
    {
        public static EmployeeCodeGenDto AdaptToCodeGenDto(this Employee p1)
        {
            return p1 == null ? null : new EmployeeCodeGenDto()
            {
                Name = p1.Name,
                Department = p1.Department,
                Salary = p1.Salary
            };
        }
        public static EmployeeCodeGenDto AdaptTo(this Employee p2, EmployeeCodeGenDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            EmployeeCodeGenDto result = p3 ?? new EmployeeCodeGenDto();
            
            result.Name = p2.Name;
            result.Department = p2.Department;
            result.Salary = p2.Salary;
            return result;
            
        }
    }
}