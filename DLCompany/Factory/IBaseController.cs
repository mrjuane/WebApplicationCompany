using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLCompany.Factory
{
    public interface IBaseController<T> : IDisposable
    {
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T GetEntity(int Id);
        IEnumerable<T> GetEntities();
    }
}
