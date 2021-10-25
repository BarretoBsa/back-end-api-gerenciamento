using System;
using System.Collections;
using System.Threading.Tasks;
using API.Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Insert(T item);
        Task<T> Update(T item);
        Task<bool> Delete(int Id);
        Task<IEnumerable> List();
        Task<T> Get(int Id);
    }
}
