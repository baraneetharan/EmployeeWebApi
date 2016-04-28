
namespace EmployeeWebApi.Repositories.Repository
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using EmployeeWebApi.Models;
    using Microsoft.AspNet.Mvc;
    using Microsoft.Extensions.Logging;

    public class DataEventRecordRepository : IDataEventRecordRepository
    {
        private readonly EmployeeDbContext _context;

        private readonly ILogger _logger;

        public DataEventRecordRepository(EmployeeDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("IDataEventRecordResporitory");          
        }

        public IEnumerable<EmployeeMasters> GetAll()
        {
            _logger.LogCritical("Getting a the existing records");
            IEnumerable<EmployeeMasters> users = from a in _context.Employees select a;
            Debug.WriteLine("EMPLOYESSSS::"+users);
            return users;
            //return _context.DataEventRecords.ToList();
        }

       

        [HttpPost]
        public void Post(EmployeeMasters dataEventRecord )
        {
            _context.Employees.Add(dataEventRecord);
            _context.SaveChangesAsync();
        }
        
         public void Delete(long id)
        {
            _logger.LogCritical("DELETE:::>>>>>>>>>"+id);
            int i = 2;
            IEnumerable<EmployeeMasters> users = from a in _context.Employees where a.EmpID.Equals(i) select a;
            _logger.LogCritical("DELETE:::>>>>>>>>>"+users);
            EmployeeMasters entity = users.First(t => t.EmpID.Equals(2));
            // foreach(var emp in users){
            //     _logger.LogCritical("DELETE:::>>>>>>>>>"+emp);
            // }
                
                
           
            
           // _context.Employees.Remove(entity);
          //  _context.SaveChanges();
        }

       
    }
}
