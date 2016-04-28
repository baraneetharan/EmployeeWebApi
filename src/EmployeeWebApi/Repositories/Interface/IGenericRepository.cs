using System;
using System.Collections.Generic;

namespace EmployeeWebApi.Repositories.Interface
{


    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> SelectAll();
        //T SelectByID(object id);
        Boolean Insert(T obj);
        Boolean Update(T obj);
        //void Delete(object id);
        void Save();
    }


}
