using System.Collections.Generic;
using EmployeeWebApi.Models;
using EmployeeWebApi.Repositories.Repository;
using Microsoft.AspNet.Mvc;

namespace EmployeeWebApi.Controllers
{
    

    [Route("api/DataEventRecordsController")]
    public class DataEventRecordsController : Controller
    {
        private readonly IDataEventRecordRepository _dataEventRecordRepository;

        public DataEventRecordsController(IDataEventRecordRepository dataEventRecordRepository)
        {
            _dataEventRecordRepository = dataEventRecordRepository;
        }

        [HttpGet]
        public IEnumerable<EmployeeMasters> Get()
        {
            return _dataEventRecordRepository.GetAll();
        }

       
        [HttpPost]
        public void Post([FromBody]EmployeeMasters value)
        {
            _dataEventRecordRepository.Post(value);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _dataEventRecordRepository.Delete(id);
        }

    }
}
