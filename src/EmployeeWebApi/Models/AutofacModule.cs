using Autofac;
using EmployeeWebApi.Repositories.Interface;
using EmployeeWebApi.Repositories.Repository;
using EmployeeWebApi.Services.Interface;
using EmployeeWebApi.Services.Services;

namespace EmployeeWebApi.Models
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmpService>()
                .As<IEmpService>()
                .InstancePerDependency();
            builder.RegisterType<EmpRepository>()
                .As<IEmpRepository>()
                .InstancePerDependency();
            builder.RegisterType<UnitOfWorks>()
                .As<IUnitOfWorks>()
                .InstancePerDependency();
            builder.RegisterType<EmployeeDbContext>()
                           .As<EmployeeDbContext>()
                           .InstancePerDependency();
            builder.RegisterType<DataEventRecordRepository>()
                           .As<IDataEventRecordRepository>()
                           .InstancePerDependency();


        }
    }
}
