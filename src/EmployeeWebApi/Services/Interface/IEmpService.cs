using EmployeeWebApi.Models;
using System;
using System.Collections.Generic;

namespace EmployeeWebApi.Services.Interface
{
    public interface IEmpService : IEntityService<EmployeeMasters>
    {
        EmployeeMasters GetById(int Id);
        //Boolean DeleteEmployee(int Id);
        Boolean DeleteEmployee(EmployeeMasters emp);
        
        IEnumerable<EmployeeMasters> seletAllEmp();
        Boolean InsertEmployee(EmployeeMasters obj);
    }
}
