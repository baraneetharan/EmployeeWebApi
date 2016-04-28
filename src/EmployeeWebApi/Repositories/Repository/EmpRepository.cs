using EmployeeWebApi.Models;
using EmployeeWebApi.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace EmployeeWebApi.Repositories.Repository
{
    public class EmpRepository : GenericRepository<EmployeeMasters>, IEmpRepository
    {
        public EmpRepository(EmployeeDbContext context)
           : base(context)
       {

       }

       // public Boolean Delete(int id)
        // {

        //    // EmployeeMasters existing = _dbset.Where(x => x.EmpID == id).FirstOrDefault();
        //    // _dbset.RemoveRange(existing);
        //    // Save();
        //    var entity = from a in _entities.Employees where a.EmpID == 1 select a;
         
        //    Debug.WriteLine("DELETE EMPLOYEE REPO:::"+entity);
        //    Console.WriteLine("DELETE EMPLOYEE REPO:::"+entity);
        //    _entities.Employees.RemoveRange(entity);
        //    // _entities.Entry(emp).State = Microsoft.Data.Entity.EntityState.Deleted;
        //    _entities.SaveChanges();
        //     Debug.WriteLine("REMOVE");
        //     Console.WriteLine("REMOVE");
        //    // Save();
        //     return true;

        // }
        public Boolean Delete(EmployeeMasters emp){
            _dbset.Remove(emp);
            Save();
            return true;
        }

        public EmployeeMasters GetById(int id)
        {
            return _dbset.Where(x => x.EmpID == id).FirstOrDefault();
        }
        
         public IEnumerable<EmployeeMasters> SelectAllEmp()
        {
            var users = from a in _entities.Employees select a;
            Debug.WriteLine("EMPLOYESSSS::"+users);
            return users;
        }

        public Boolean InsertEmployee(EmployeeMasters obj)
        {
            Debug.WriteLine("DATA REPO:::"+obj.ToString());
           _entities.Employees.Add(obj);
            Debug.WriteLine("DATA REPO:::");
            _entities.SaveChangesAsync();
            return true;
        }

    }
}
