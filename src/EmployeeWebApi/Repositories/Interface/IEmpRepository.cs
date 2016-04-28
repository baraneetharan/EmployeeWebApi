using EmployeeWebApi.Models;
using System;
using System.Collections.Generic;

namespace EmployeeWebApi.Repositories.Interface
{
    public interface IEmpRepository : IGenericRepository<EmployeeMasters>
    {
        EmployeeMasters GetById(int id);
        //Boolean Delete(int id);
        Boolean Delete(EmployeeMasters emp);
        
        IEnumerable<EmployeeMasters> SelectAllEmp();
        Boolean InsertEmployee(EmployeeMasters obj);
    }
}
