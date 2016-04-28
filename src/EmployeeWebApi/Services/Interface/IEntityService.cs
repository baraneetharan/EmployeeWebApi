using System;
using System.Collections.Generic;

namespace EmployeeWebApi.Services.Interface
{
    public interface IEntityService<T> : IService
      where T : class
    {
        Boolean Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        Boolean Update(T entity);
    }
}
