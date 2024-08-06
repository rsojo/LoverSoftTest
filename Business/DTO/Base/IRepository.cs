using Business.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO.Base
{
    public interface IRepository<T> where T : new()
    {
        BusinessResponse<T> Get(int id);
        BusinessResponse<T> GetAll();
        BusinessResponse<T> Set(T entity);
        BusinessResponse<T> Update(T entity);
        BusinessResponse<T> Delete(T entity);
    }
}
