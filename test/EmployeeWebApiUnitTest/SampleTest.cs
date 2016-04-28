using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeWebApi.Services.Interface;
using LightMock;
using Xunit;

namespace EmployeeWebApiUnitTest
{
    // see example explanation on xUnit.net website:
    // https://xunit.github.io/docs/getting-started-dnx.html
    public class SampleTest
    {
        public  readonly MockContext<IEmpService> _mock;
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
