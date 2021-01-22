using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointments.Repository
{
    public interface IRepository<T,ID>
    {
        IEnumerable<T> FindAll();
        T FindById(ID id);
        void Save(T entity);
        void SaveAll(IEnumerable<T> entities);
        bool DeleteById(ID id);

    }
}
