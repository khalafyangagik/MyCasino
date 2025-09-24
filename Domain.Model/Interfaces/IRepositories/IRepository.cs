using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Core.Interfaces.IRepositories
{
    public interface IRepository<T>
    {
        Task Create(T entity);
        Task<T> Get(int id);
        Task Delete(int id);
        Task Update(T entity);
    }
}
