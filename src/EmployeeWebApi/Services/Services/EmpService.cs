using EmployeeWebApi.Models;
using EmployeeWebApi.Repositories.Interface;
using EmployeeWebApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EmployeeWebApi.Services.Services
{
    public class EmpService : EntityService<EmployeeMasters>, IEmpService
    {
        IUnitOfWorks _unitOfWork;
        IEmpRepository _empRepository;

        public EmpService(IUnitOfWorks unitOfWork, IEmpRepository empRepository)
          : base(unitOfWork, empRepository)
      {
            _unitOfWork = unitOfWork;
            _empRepository = empRepository;
        }

        public EmployeeMasters GetById(int Id)
        {
            return _empRepository.GetById(Id);
        }

        public Boolean DeleteEmployee(EmployeeMasters emp)
        {
            //return  _empRepository.Delete(Id);
            return  _empRepository.Delete(emp);
        }

        public IEnumerable<EmployeeMasters> seletAllEmp()
        {
            Debug.WriteLine("EMPLOYEES::::::"+_empRepository.SelectAllEmp());
            Console.WriteLine("EMPLOYEES::::::"+_empRepository.SelectAllEmp());
            return _empRepository.SelectAllEmp();
        }

        public bool InsertEmployee(EmployeeMasters obj)
        {
             Debug.WriteLine("DATA SERVICE :::"+obj.ToString());
            return _empRepository.InsertEmployee(obj);
        }
    }
}
