using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountingSystem.Domain.Interfaces
{
    public interface IBaseRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetRecordList();
        Task<T> GetRecord(int id);
        Task Create(T item);
        void Update(T item);
        void Delete(T item);
        Task Save();
    }
}
