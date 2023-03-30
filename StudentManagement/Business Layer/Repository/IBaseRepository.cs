using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Business_Layer.Repository
{
    public interface IBaseRepository
    {
        T1 Create<T1>(T1 model) where T1 : class;
        T1 Update<T1>(T1 model) where T1 : class;
 
        Task<T1> GetDataById<T1>(int Id) where T1 : class;
        IQueryable<T1> GetAllData<T1>() where T1 : class;
        Task<T1> Delete<T1>(T1 model) where T1 : class;
    }
}
