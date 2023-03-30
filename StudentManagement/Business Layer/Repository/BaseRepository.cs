using StudentManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Business_Layer.Repository
{
  
    public class BaseRepository : IBaseRepository
    {
        private readonly AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }

        public virtual T1 Create<T1>(T1 model) where T1 : class
        {
            try
            {
                context.Set<T1>().Add(model);
                context.SaveChanges();
                return model;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public virtual T1 Update<T1>(T1 model) where T1 : class
        {
            try
            {
                context.Set<T1>().Update(model);
                //context.T1.Add(model);
                context.SaveChanges();
                return model;
            }
            catch (Exception)
            {

                return null;
            }

        }
        public virtual async Task<T1> GetDataById<T1>(int Id) where T1 : class
        {
            return context.Set<T1>().Find(Id);
        }

        public virtual async Task<T1> Delete<T1>(T1 model) where T1 : class
        {
            //var model = await GetDataById<T1>(model);
            context.Set<T1>().Remove(model);
            context.SaveChanges();
            return model;
        }

        public virtual IQueryable<T1> GetAllData<T1>() where T1 : class
        {
            return context.Set<T1>();
        }
    }
}
