using System.Collections.Generic;
using EmployeeWebApi.Controllers;
using EmployeeWebApi.Models;
using EmployeeWebApi.Services.Interface;
using LightMock;
using Xunit;

namespace EmployeeWebApiUnitTest.Controller
{
    public class EmployeeMasterTestController
    {
        private readonly MockContext<IEmpService> mockEmpService;
        private readonly EmployeeMastersController employeeController;
        EmployeeMasters empMaster = new EmployeeMasters(0, "reka", "dev", "reka.v@gfsl.com", "12586", "CBE");
        List<EmployeeMasters> list = new List<EmployeeMasters>();
        public EmployeeMasterTestController(){
            
            mockEmpService = new MockContext<IEmpService>();
            //mockEmpService.Arrange(x=>x.Create(empMaster)).Return(true);
            list.Add(empMaster);
        }
        [Fact]
        public void createEmployeeMasterTest(){
            mockEmpService.Arrange(m => m.seletAllEmp()).Returns(list);
            
        }

        
    }
}