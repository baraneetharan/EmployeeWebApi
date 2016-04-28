using System.Collections.Generic;
using EmployeeWebApi.Models;

namespace EmployeeWebApi.Repositories.Repository
{


    public interface IDataEventRecordRepository
    {
        
      IEnumerable<EmployeeMasters> GetAll();
        void Post(EmployeeMasters dataEventRecord);
        void Delete(long id);
        
    }
}